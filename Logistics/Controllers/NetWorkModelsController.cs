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
    [Filter.Filter.LoginFilter]
    [Filter.Filter.NetWorkFilter]
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
            var temp = from b in db.Delivery select b;
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
            int account = (int)Session["Account"];
            String city = "上海";
            if (account == 7)
                city = "北京";
            DateTime date = System.DateTime.Now;
            LogDetail log = db.LogDetail.Find(delivery.PackNo);
            if (log == null)
                return Content("<script >alert('货物尚未揽件，不能发货！');history.go(-1)</script >", "text/html");
            else {
                if (log.Status == 0)
                {
                    if (!log.FromCity.Equals(city))
                        return Content("<script >alert('货物不在本城市，不能发货！');history.go(-1)</script >", "text/html");
                }
                if (log.Status == 1)
                {
                    if (!log.ToCity.Equals(city))
                        return Content("<script >alert('货物不在本城市，不能发货！');history.go(-1)</script >", "text/html");
                }
            }


            //创建发货单
            delivery.Network = account;
            delivery.DeliveryTime = System.DateTime.Now;
            delivery.DeliveryStorage = 8;
            delivery.DeliveryStatus = 0;
            db.Delivery.Add(delivery);
            db.SaveChanges();


            //创建流程单
            Process check = db.Process.Find(delivery.PackNo);
            if (check != null)//查询退件
                if (check.Status == 1)
                    return RedirectToAction("Delivering");

            Process pro = new Process();
            pro.PackNo = (int)delivery.PackNo;
            pro.DeliveryNo = delivery.DeliveryNo;
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
            int account = (int)Session["Account"];
            User user = db.User.Find(account);
            if (account == 6)
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
            dispatch.DispatchType = logDetail.Status;
            db.Dispatch.Add(dispatch);
            db.SaveChanges();
            int dispatchNo = dispatch.DispatchNo;

            //流程信息填写
            Process process = db.Process.Find(logDetail.PackNo);
            if (process.Status == 0)
            {
                process.DispatchNo = dispatchNo;
                process.DispatchTime = dispatch.DispatchTime;
                User sender = db.User.Find(RandKey);
                process.CourierNo = sender.UserName;
                process.Location = user.UserName;
                process.UpdateTime = System.DateTime.Now;
                db.Entry(process).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("../NetWorkModels/SendManager");
        }
    }
}