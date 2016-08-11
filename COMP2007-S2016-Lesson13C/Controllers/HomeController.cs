using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMP2007_S2016_Lesson13C.Models;

namespace COMP2007_S2016_Lesson13C.Controllers
{
    public class HomeController : Controller
    {
        MVCMusicStoreContext db = new MVCMusicStoreContext();

        // GET: /Home/Index or /
        public ActionResult Index()
        {
            ViewBag.Title = "Genre List";

            return View();
        }
    }
}
