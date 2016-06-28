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

        public ActionResult AddPackageInfo()
        {
            return View();
        }
    }
}