﻿using System.Web.Mvc;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        [Route("", Name = "Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}