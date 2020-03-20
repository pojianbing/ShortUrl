using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortUrl.Common;
using ShortUrl.Core;
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
            Int64 num = 9176543210987654321L;
            var str = RadixConvert.To62Radix(num);
            var num2 = RadixConvert.From62Radix(str);

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
            var url = "https://u.geekbang.org/subject/fe/100044701?utm_source=frontend&utm_medium=message&utm_term=frontendmessage";
            var shortId = ShortUrlHelper.ToShrotId(url);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
