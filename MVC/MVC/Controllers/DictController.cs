using Data.Dictionary;
using Data.Models;
using System;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DictController : Controller
    {
        private static string _errorMessage;
        private IPhoneDictionary<User> _phoneDictionary;

        public DictController(IPhoneDictionary<User> pd)
        {
            _phoneDictionary = pd;
        }

        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.getAll = JsonUserRepository.GetInstance().FindAll();
            //ViewBag.getAll = SqlUserRepository.GetInstance().FindAll();
            ViewBag.getAll = _phoneDictionary.FindAll();
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
            //Models.User user = JsonUserRepository.GetInstance().FindOne(id);
            //Models.User user = SqlUserRepository.GetInstance().FindOne(id);
            User user = _phoneDictionary.FindOne(id);
            if (user == null)
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
            //Models.User user = JsonUserRepository.GetInstance().FindOne(id);
            //Models.User user = SqlUserRepository.GetInstance().FindOne(id);
            User user = _phoneDictionary.FindOne(id);
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
                //JsonUserRepository.GetInstance().Add(new Models.User(Request.Params["name"], Request.Params["phone"]));
                //SqlUserRepository.GetInstance().Add(new Models.User(Request.Params["name"], Request.Params["phone"]));
                _phoneDictionary.Add(new User(Request.Params["name"], Request.Params["phone"]));
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
                //JsonUserRepository.GetInstance().Update(id, new Models.User(name, phone));
                //SqlUserRepository.GetInstance().Update(id, new Models.User(name, phone));
                _phoneDictionary.Update(id, new User(name, phone));
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
                //JsonUserRepository.GetInstance().Delete(id);
                //SqlUserRepository.GetInstance().Delete(id);
                _phoneDictionary.Delete(id);
            }
            return RedirectToAction("Index");
        }
    }
}