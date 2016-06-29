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
    public class UsersController : Controller
    {
        private ModelContext db = new ModelContext();

        public ActionResult Login([Bind(Include = "Account,Password")] User user)
        {
            var result = from v in db.User
                         where v.Account == user.Account && v.Password == user.Password
                         select v;
            if (result.FirstOrDefault() != null)
            {
                User resUser = db.User.Find(user.Account);
                if (Session["Account"] != "")
                {
                    this.Session["Account"] = resUser.Account;
                    this.Session["UserName"] = resUser.UserName;
                    this.Session["Authority"] = resUser.Permissions;
                }
                Session.Timeout = 30;
                return RedirectToAction("../Home/ManagerIndex");
            }
            else
            {
                return Content("<script >alert('账号或密码有误！');history.go(-1)</script >", "text/html");
            }
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["UserName"] = null;
            Session["Authority"] = null;
            return RedirectToAction("../Home/Login");
        }
    }
}
