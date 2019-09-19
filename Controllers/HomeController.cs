using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLogSample.Models;

namespace NLogSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            try {
                logger.LogInformation("HomeController.Index method called!!!");
                return View();
            }
            catch (Exception ex) {
                logger.LogError(ex,"Error found in Index method");
                return View();
            }
        }

        public IActionResult Privacy()
        {
            try {
               logger.LogWarning(string.Format("warning before use of Privacy"));
               return View();
            }
            catch (Exception ex) {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            logger.LogError("error found in HomeController.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
