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
    public class CourierModelsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: CourierModels
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPackage()
        {
            int account = (int)Session["Account"];
            var list = from a in db.Booking where a.CourierNo == account orderby a.Status, a.BookGetTime ascending select a;
            CourierModel model = new CourierModel();
            model.BookingModel = list.ToList();
            return View(model);
        }

        public ActionResult GetPackageMethod(int? id)
        {
            Booking booking = db.Booking.Find(id);
            booking.Status = 1;
            db.Entry(booking).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("GetPackage");
        }

        [HttpGet]
        public ActionResult AddPackageInfo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackageInfo(CourierModel model)
        {
            String fromer = model.LogDetailModel.FromName;
            DateTime datetime = System.DateTime.Now;
            model.LogDetailModel.CreateTime = datetime;
            model.LogDetailModel.Status = 0;
            model.LogDetailModel.getter = (int)Session["Account"];
            db.LogDetail.Add(model.LogDetailModel);
            db.SaveChanges();
            int packno = model.LogDetailModel.PackNo;
            return Content("<script>alert('快递单号为：" + packno + "  请牢记！');location.href='../CourierModels/AddPackageInfo';</script>");
            //return Content("<script >alert(快递单号为："+ packno + "，请牢记！);history.go(-1)</script >", "text/html");
        }

        public ActionResult SendPackage()
        {
            int account = (int)Session["Account"];
            var list = from a in db.Dispatch where a.CourierNo == account orderby a.DispatchStatus, a.DispatchTime ascending select a;
            CourierModel model = new CourierModel();
            model.DispatchtModel = list.ToList();
            return View(model);
        }

        public ActionResult AccpetSendPackageMethod(int? id)
        {
            //派送单信息修改
            Dispatch dispatch = db.Dispatch.Find(id);
            dispatch.DispatchStatus = 1;
            db.Entry(dispatch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("SendPackage");
        }

        public ActionResult FinishSendPackageMethod(int? id)
        {
            //派送单信息修改
            Dispatch dispatch = db.Dispatch.Find(id);
            dispatch.DispatchStatus = 2;
            db.Entry(dispatch).State = EntityState.Modified;
            db.SaveChanges();

            //流程信息单修改
            Process process = db.Process.Find(dispatch.PackNo);
            process.Status = 2;
            db.Entry(process).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SendPackage");
        }

        public ActionResult BackSendPackageMethod(int? id)
        {
            //派送单信息修改
            Dispatch dispatch = db.Dispatch.Find(id);
            dispatch.DispatchStatus = 3;
            db.Entry(dispatch).State = EntityState.Modified;
            db.SaveChanges();

            //快递信息单修改
            LogDetail logDetail = db.LogDetail.Find(dispatch.PackNo);
            logDetail.Status = 1;
            db.Entry(logDetail).State = EntityState.Modified;
            db.SaveChanges();

            //流程信息单修改
            Process process = db.Process.Find(dispatch.PackNo);
            process.Status = 1;
            db.Entry(process).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("SendPackage");
        }
    }
}