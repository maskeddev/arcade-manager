using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcadeManager.Models;

namespace ArcadeManager.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index(string message = "")
        {
            if (new SessionManager().Exists())
                return RedirectToAction("Index", "Home");

            ViewData["Message"] = message;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection) 
        {
            var user = new DataManager().Login(formCollection["LoginEmail"], formCollection["LoginPassword"]);

            if (user == null)
                return RedirectToAction("Index", new { message = "Login failed" });

            new SessionManager().SaveSession(user);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            var user = new User
            {
                Name = formCollection["RegisterName"],
                Email = formCollection["RegisterEmail"],
                Password = formCollection["RegisterPassword"]
            };

            var errorMessage = new DataManager().CreateUser(user);

            if (!string.IsNullOrEmpty(errorMessage)) 
                return RedirectToAction("Index", new { message = errorMessage });

            new SessionManager().SaveSession(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
