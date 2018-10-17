using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompiledView_WithControllers.Controllers
{
    public class CVWCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View("~/Views/CVWC_TEST.cshtml");
        }
    }
}
