using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HellowWorld
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "hello "+name;
            ViewBag.NumTimes = numTimes;
            return View();
        }
    }
}