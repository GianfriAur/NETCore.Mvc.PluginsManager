using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AUR.NETCore.Mvc.PluginsManager.BaseExample.Models;

namespace AUR.NETCore.Mvc.PluginsManager.BaseExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult test()
        {
            return View("~/Views/CV_WithoutC.cshtml");
        }

        public IActionResult test2()
        {
            return View("~/Views/EVWC.cshtml");
        }

        public IActionResult test3()
        {
            return View("~/Views/EVWCFolder/EVWC.cshtml");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
