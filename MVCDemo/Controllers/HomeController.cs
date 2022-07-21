using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home


        public ActionResult Index()
        {
            List<string> list = new List<string>() { "Hong Kong", "US", "UK", "Canada" };

            // Store the list of Countries in ViewBag.  
            ViewBag.Countries = list;

            // Store the list of Countries in ViewData.  
            ViewData["Countries"] = list;

            return View();

        }

        //public string Index(string id, string name)
        //{
        //    return "The value of Id = " + id + " and Name = " + name;

        //}

        //public string Index(string id)
        //{
        //    return "The value of Id = " + id + " and Name = " + Request.QueryString["name"];
        //}

        public string GetDetail(string id = "Hello MVC")
        {
            return id;
        }
    }
}