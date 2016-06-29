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
    public class CoustomerModelsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: CoustomerModels
        public ActionResult Index()
        {
            return View();
        }

        // GET: Coustomer/Complaint
        public ActionResult Complaint()
        {
            return View();
        }

        // POST: Coustomer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complaint([Bind(Include = "PackNo,ComplaintName,ComplaintTel,ComplaintContent")] Complaint comp)
        {
            if (ModelState.IsValid)
            {
                db.Complaint.Add(comp);
                db.SaveChanges();
                return RedirectToAction("../Home/Index");
            }

            return View(comp);
        }



        // GET: Coustomer/Process
        public ActionResult Process(int? id)
        {
            Process pro = db.Process.Find(id);
            if (pro == null)
            {
                return Content("<script >alert('单号不存在！');history.go(-1)</script >", "text/html");
            }
            return View(pro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Process([Bind(Include = "PackNo")] Process process)
        {
            return RedirectToAction("Process", "CoustomerModels", new { id = process.PackNo });
        }

       
    }
}