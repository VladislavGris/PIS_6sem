using Lab7_Identity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_Identity.Controllers
{
    [AuthAction]
    public class FIEController : Controller
    {
        // GET: FIE
        [Authorize(Roles = "Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_TM()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UR()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UP()
        {
            return View();
        }
    }
}