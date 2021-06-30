using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HMUniversity.Certification.Generator.AspNetMvcApp.Models;
using HMUniversity.Certification.Generator.Lib;

namespace HMUniversity.Certification.Generator.AspNetMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Certification")]
        public IActionResult Certification(CertModel cm)
        {
            ViewData["Owner"] = cm.Owner;
            ViewData["Degree"] = cm.Degree;
            if (string.IsNullOrEmpty(cm.Owner))
                return BadRequest("Owner is required!");
            ViewData["Date"] = Operator.GetDate();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}