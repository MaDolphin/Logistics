﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logistics.Models;

namespace Logistics.Controllers
{
    public class NetWorkModelsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: NetWorkModels
        public ActionResult Index()
        {
            return View();
        }



        //查询收货信息
        // GET: Network/LogisticInfo
        public ActionResult DeliveryInfo()
        {
            var temp=from b in db.Delivery select b;
            return View(temp.ToList());
        }
    


        //发货
        // GET: Network/Delivering
        public ActionResult Delivering()
        {
            return View();
        }

        // POST: Network/Delivering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delivering([Bind(Include = "PackNo,DeliveryClass")] Delivery delivery)
        {
            int account=(int)Session["Account"];
            String city="上海";
            if (account == 2)
                city = "北京";
            DateTime date=System.DateTime.Now;
            LogDetail log = db.LogDetail.Find(delivery.PackNo);
            if(log==null)
                return Content("<script >alert('货物尚未揽件，不能发货！');history.go(-1)</script >", "text/html");
            else if(!log.FromCity.Equals(city))
                return Content("<script >alert('货物不在本城市，不能发货！');history.go(-1)</script >", "text/html");


            //创建发货单
            delivery.Network = account;
            delivery.DeliveryTime = System.DateTime.Now;
            delivery.DeliveryStorage = 8;
            delivery.DeliveryStatus = 0;
            db.Delivery.Add(delivery);
            db.SaveChanges();


            //创建流程单
            Process check = db.Process.Find(delivery.PackNo);
            if(check!=null)//查询退件
                if(check.Status==1)
                    return RedirectToAction("Delivering");

            Process pro = new Process();
            pro.PackNo = (int)delivery.PackNo;
            pro.DeliveryNo=delivery.DeliveryNo;
            pro.DeliveryTime = date;
            pro.Network = (String)Session["UserName"];
            pro.UpdateTime = date;
            pro.Location = (String)Session["UserName"];
            pro.Status = 0;
            db.Process.Add(pro);
            db.SaveChanges();

            return RedirectToAction("Delivering");
            
        }



    }
}