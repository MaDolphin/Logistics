using System;
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
        public ActionResult LogisticInfo()
        {
            
            return View();
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
            DateTime date=System.DateTime.Now;
            //创建发货单
            delivery.Network = account;
            delivery.DeliveryTime = System.DateTime.Now;
            delivery.DeliveryStorage = 8;
            delivery.DeliveryStatus = 0;
            db.Delivery.Add(delivery);
            db.SaveChanges();


            //创建流程单
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

        public ActionResult SendManager()
        {
            int account = (int)Session["Account"];
            var list = from a in db.Storage where a.StorageNetwork == account  orderby a.Status, a.BookGetTime ascending select a;
            CourierModel model = new CourierModel();
            model.BookingModel = list.ToList();
            return View();
        }
    }
}