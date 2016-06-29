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
            delivery.Network = (int)Session["Account"];
            delivery.DeliveryTime = System.DateTime.Now;
            db.Delivery.Add(delivery);
            db.SaveChanges();
            return RedirectToAction("Delivering");
        }
    }
}