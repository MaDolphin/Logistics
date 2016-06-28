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
    }
}