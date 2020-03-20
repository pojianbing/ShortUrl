using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortUrl.Web.Models;

namespace ShortUrl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 短链接入口url
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        [Route("/{shortId:required}")]
        public IActionResult Index(string shortId)
        {
            return View();
        }

        /// <summary>
        /// 短链生成页面
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        [Route("/generate")]
        public IActionResult Generate()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
