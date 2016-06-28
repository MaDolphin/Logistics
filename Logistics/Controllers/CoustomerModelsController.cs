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

        // GET: Users/Complaint
        public ActionResult Complaint()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complaint([Bind(Include = "PackNo,ComplaintName,ComplaintTel,ComplaintContent")] Complaint comp)
        {
            if (ModelState.IsValid)
            {
                db.Complaint.Add(comp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comp);
        }



        // GET: Users/Process
        public ActionResult Process()
        {
            return View();
        }

       
    }
}