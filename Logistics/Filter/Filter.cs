using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Logistics.Filter
{
    public class Filter
    {
        public class LoginFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                int? account = (int?)filterContext.HttpContext.Session["Account"];

                if (account == null || filterContext.HttpContext.Session.Mode == 0)
                {
                    filterContext.Result = new RedirectResult("../Home/Login");
                }
                return;
            }
        }

        public class CommunicateFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                int authority = (int)filterContext.HttpContext.Session["Authority"];

                if (authority != 1 || filterContext.HttpContext.Session.Mode == 0)
                {
                    filterContext.Result = new RedirectResult("../Home/Error");
                }
                return;
            }
        }

        public class CourierFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                int authority = (int)filterContext.HttpContext.Session["Authority"];

                if (authority != 2 || filterContext.HttpContext.Session.Mode == 0)
                {
                    filterContext.Result = new RedirectResult("../Home/Error");
                }
                return;
            }
        }

        public class NetWorkFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                int authority = (int)filterContext.HttpContext.Session["Authority"];

                if (authority != 3 || filterContext.HttpContext.Session.Mode == 0)
                {
                    filterContext.Result = new RedirectResult("../Home/Error");
                }
                return;
            }
        }

        public class StoragerFilter : AuthorizeAttribute, IAuthorizationFilter
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                int authority = (int)filterContext.HttpContext.Session["Authority"];

                if (authority != 4 || filterContext.HttpContext.Session.Mode == 0)
                {
                    filterContext.Result = new RedirectResult("../Home/Error");
                }
                return;
            }
        }
    }
}