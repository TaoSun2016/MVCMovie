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

        public string Welcome(string name, int id = 1)
        {
            return HttpUtility.HtmlEncode("Hello, "+name+"! Your ID is "+id);
        }
    }
}