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
            var list = from a in db.Storage where a.StorageNetwork == account orderby a.StorageStatus, a.StorageTime ascending select a;
            NetWorkModel model = new NetWorkModel();
            model.StorageModel = list.ToList();
            return View(model);
        }

        public ActionResult SendManagerMethod(int? id)
        {
            int RandKey = 0;
            int account = (int)Session["Acccount"];
            User user = db.User.Find(account);
            if(account == 6)
            {
                Random ran = new Random();
                RandKey = ran.Next(2, 3);
            }
            if (account == 7)
            {
                Random ran = new Random();
                RandKey = ran.Next(4, 5);
            }
            Storage storage = db.Storage.Find(id);
            LogDetail logDetail = db.LogDetail.Find(storage.PackNo);

            //快递单信息更改
            logDetail.sender = RandKey;
            db.Entry(logDetail).State = EntityState.Modified;
            db.SaveChanges();

            //发货信息状态更改
            storage.StorageStatus = 1;
            db.Entry(storage).State = EntityState.Modified;
            db.SaveChanges();

            //派送信息填写
            Dispatch dispatch = new Dispatch();
            dispatch.PackNo = logDetail.PackNo;
            dispatch.PackName = logDetail.PackName;
            dispatch.ToName = logDetail.ToName;
            dispatch.ToTel = logDetail.ToTel;
            dispatch.ToAddresss = logDetail.ToAddress;
            dispatch.CourierNo = RandKey;
            dispatch.DispatchTime = System.DateTime.Now;
            dispatch.DispatchStatus = 0;
            db.Dispatch.Add(dispatch);
            db.SaveChanges();
            int dispatchNo = dispatch.DispatchNo;

            //流程信息填写
            Process process = db.Process.Find(logDetail.PackNo);
            process.DispatchNo = dispatchNo;
            process.DispatchTime = dispatch.DispatchTime;
            process.CourierNo = dispatch.CourierNo.ToString();
            process.Location = user.UserName;
            process.UpdateTime = System.DateTime.Now;
            db.Entry(process).State = EntityState.Modified;
            db.SaveChanges();

            return Content("<script>alert('操作成功！');location.href='../NetWorkModels/SendManager';</script>");
            //return RedirectToAction("SendManager");
        }
    }
}