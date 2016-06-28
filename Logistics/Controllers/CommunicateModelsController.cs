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

        public ActionResult CreateBooking()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking(CommunicateModel model)
        {

            model.BookingModel.BookStartTime = System.DateTime.Now;
            return View();
        }
    }
}