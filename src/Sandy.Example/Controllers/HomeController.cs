using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandy.Core;
using Sandy.Extensions;

namespace Sandy.Example.Controllers
{
    public class HomeController : Controller
    {
        private IJsonLogger requestLogger { get; set; }

        public HomeController(IJsonLogger logger)
        {
            this.requestLogger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            Request.LogInfo();
            Request.LogError("something went wrong");

            //requestLogger.LogInfo(this.Request, "logged in");
            //requestLogger.LogDebug(this.Request, "");
            requestLogger.LogFatal(Request, new Exception("something went wrong"), "my message");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
