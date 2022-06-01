using Lab7_Identity.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_Identity.Controllers
{
    [AuthAction]
    public class FLTController : Controller
    {
        // GET: FLT
        [Authorize(Roles = "Guest,Employer")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FLT_LV()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIT_LU()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public ActionResult FIT_LZ()
        {
            return View();
        }
    }
}