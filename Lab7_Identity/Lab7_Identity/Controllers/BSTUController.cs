using Lab7_Identity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_Identity.Controllers
{
    [AuthAction]
    public class BSTUController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Administrator")]
        public ActionResult Config()
        {
            return View();
        }
    }
}