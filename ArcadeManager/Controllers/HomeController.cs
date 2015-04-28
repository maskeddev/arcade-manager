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
        public ActionResult NewGame(string gameName)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadGame(string name)
        {
            return View();
        }
    }
}