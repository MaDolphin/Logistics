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
    public class DispatchesController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Dispatches
        public ActionResult Index()
        {
            return View(db.Dispatch.ToList());
        }

        // GET: Dispatches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            return View(dispatch);
        }

        // GET: Dispatches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dispatches/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DispatchNo,PackNo,CourierNo,PackName,ToName,DispatchTime,DispatchStatus")] Dispatch dispatch)
        {
            if (ModelState.IsValid)
            {
                db.Dispatch.Add(dispatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dispatch);
        }

        // GET: Dispatches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            return View(dispatch);
        }

        // POST: Dispatches/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DispatchNo,PackNo,CourierNo,PackName,ToName,DispatchTime,DispatchStatus")] Dispatch dispatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dispatch);
        }

        // GET: Dispatches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispatch dispatch = db.Dispatch.Find(id);
            if (dispatch == null)
            {
                return HttpNotFound();
            }
            return View(dispatch);
        }

        // POST: Dispatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispatch dispatch = db.Dispatch.Find(id);
            db.Dispatch.Remove(dispatch);
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
