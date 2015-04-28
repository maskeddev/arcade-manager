using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArcadeManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewGame(string password)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadGame(string guid, string password)
        {
            return View();
        }
    }
}