using Lab7_Identity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_Identity.Controllers
{
    [AuthAction]
    public class FITController : Controller
    {
        // GET: FIT
        [Authorize(Roles = "Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIT_IS()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIT_PI()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIT_ID()
        {
            return View();
        }
    }
}