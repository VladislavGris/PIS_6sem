using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_Identity.Filters
{
    public class AuthActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.IsAuth = filterContext.HttpContext.User.Identity.IsAuthenticated;
            filterContext.Controller.ViewBag.IsAdmin = filterContext.HttpContext.User.IsInRole("Administrator");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}