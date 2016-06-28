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
    public class LogDetailsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: LogDetails
        public ActionResult Index()
        {
            return View(db.LogDetail.ToList());
        }

        // GET: LogDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogDetail logDetail = db.LogDetail.Find(id);
            if (logDetail == null)
            {
                return HttpNotFound();
            }
            return View(logDetail);
        }

        // GET: LogDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogDetails/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackNo,FromProvince,FromCity,FromStatue,FromAddress,FromName,FromTel,ToProvince,ToCity,ToStatue,ToAddress,ToName,ToTel,Pay,PackName,Weight,Momey,Status,CreateTime")] LogDetail logDetail)
        {
            if (ModelState.IsValid)
            {
                db.LogDetail.Add(logDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logDetail);
        }

        // GET: LogDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogDetail logDetail = db.LogDetail.Find(id);
            if (logDetail == null)
            {
                return HttpNotFound();
            }
            return View(logDetail);
        }

        // POST: LogDetails/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackNo,FromProvince,FromCity,FromStatue,FromAddress,FromName,FromTel,ToProvince,ToCity,ToStatue,ToAddress,ToName,ToTel,Pay,PackName,Weight,Momey,Status,CreateTime")] LogDetail logDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logDetail);
        }

        // GET: LogDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogDetail logDetail = db.LogDetail.Find(id);
            if (logDetail == null)
            {
                return HttpNotFound();
            }
            return View(logDetail);
        }

        // POST: LogDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogDetail logDetail = db.LogDetail.Find(id);
            db.LogDetail.Remove(logDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
