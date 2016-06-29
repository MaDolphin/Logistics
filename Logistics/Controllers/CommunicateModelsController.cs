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
    public class CommunicateModelsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: CommunicateModels
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking(CommunicateModel model)
        {
            model.BookingModel.BookStartTime = System.DateTime.Now;

            model.BookingModel.CourierNo = 2;
            model.BookingModel.Status = 0;
            db.Booking.Add(model.BookingModel);
            db.SaveChanges();
            return RedirectToAction("../Home/ManagerIndex");
        }
    }
}