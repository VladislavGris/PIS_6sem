using MVC.Utils.DB;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DictController : Controller
    {
        private static string _errorMessage;

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.getAll = JsonUserRepository.GetInstance().FindAll();
            ViewBag.errorMessage = _errorMessage;
            _errorMessage = "";
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            Guid id;
            if(!Guid.TryParse(Request.Params["id"], out id))
            {
                _errorMessage = "Incorrect id";
                return RedirectToAction("Index");
            }
            Models.User user = JsonUserRepository.GetInstance().FindOne(id);
            if(user == null)
            {
                _errorMessage = $"User with id {Request.Params["id"]} not found";
                return RedirectToAction("Index");
            }
            ViewBag.user = user;
            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            Guid id;
            if (!Guid.TryParse(Request.Params["id"], out id))
            {
                _errorMessage = "Incorrect id";
                return RedirectToAction("Index");
            }
            Models.User user = JsonUserRepository.GetInstance().FindOne(id);
            if (user == null)
            {
                _errorMessage = $"User with id {Request.Params["id"]} not found";
                return RedirectToAction("Index");
            }
            ViewBag.user = user;
            return View();
        }

        [HttpPost]
        public ActionResult AddSave()
        {
            if (String.IsNullOrEmpty(Request.Params["name"]) || String.IsNullOrEmpty(Request.Params["phone"]))
            {
                _errorMessage = "Incorrect params";
            }
            else
            {
                JsonUserRepository.GetInstance().Add(new Models.User(Request.Params["name"], Request.Params["phone"]));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateSave()
        {
            Guid id;
            string name = Request.Params["name"];
            string phone = Request.Params["phone"];
            if (!Guid.TryParse(Request.Params["id"], out id))
            {
                _errorMessage = "Incorrect id";
                return RedirectToAction("Index");
            }
            if(String.IsNullOrEmpty(name) || String.IsNullOrEmpty(phone))
            {
                _errorMessage = "Incorrect params";
            }
            else
            {
                JsonUserRepository.GetInstance().Update(id, new Models.User(name, phone));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteSave()
        {
            if(Request.Params["Answer"] == "Yes")
            {
                Guid id;
                if (!Guid.TryParse(Request.Params["id"], out id))
                {
                    _errorMessage = "Incorrect id";
                    return RedirectToAction("Index");
                }
                JsonUserRepository.GetInstance().Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}