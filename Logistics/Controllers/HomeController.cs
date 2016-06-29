using Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logistics.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Filter.Filter.LoginFilter]
        public ActionResult ManagerIndex()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [Filter.Filter.LoginFilter]
        public ActionResult Error()
        {
            return View();
        }

    }
}