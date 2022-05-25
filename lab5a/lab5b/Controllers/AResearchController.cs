using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5b.Controllers
{
    public class AResearchController : Controller
    {
        // GET: AResearch
        public ActionResult Index()
        {
            return Content("GET:AResearch/Index\n");
        }

        [AAFilter]
        public ActionResult AA()
        {
            return Content("AA result\n");
        }

        [ARFilter]
        public ActionResult AR()
        {
            return Content($"AR result\n");
        }

        [AEFilter]
        public ActionResult AE()
        {
            int x = 0;
            int y = 8 / x;
            return Content($"AE worked right\n");
        }

        public class AAFilter : FilterAttribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:OnActionExecuting\n");
            }

            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:OnActionExecuted\n");
            }

        }

        public class ARFilter : FilterAttribute, IResultFilter
        {
            private Stopwatch timer;

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                timer = Stopwatch.StartNew();
            }

            public void OnResultExecuted(ResultExecutedContext filterContext)
            {
                timer.Stop();
                filterContext.HttpContext.Response.Write(
                        string.Format("<div>Время обработки результата: {0:F6}</div>",
                            timer.Elapsed.TotalSeconds));
            }
        }

        public class AEFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AE:Вызвано исключение\n");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}