using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortUrl.Application.Contracts;
using ShortUrl.Application.HashBase;
using ShortUrl.Web.Models;
using System.Diagnostics;

namespace ShortUrl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IShortUrlService _shortUrlService;

        public HomeController(IShortUrlService shortUrlService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _shortUrlService = shortUrlService;
        }

        /// <summary>
        /// 短链接入口url
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        [Route("/{shortId:required}")]
        public IActionResult Go(string shortId)
        {
            var url = _shortUrlService.GetLongUrl(shortId);
            return Redirect(url);
        }

        /// <summary>
        /// 短链生成页面
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 短链生成页面
        /// </summary>
        /// <param name="shortId">短链接id</param>
        /// <returns></returns>
        [Route("/confrimgenerate")]
        public IActionResult Generate(string url)
        {
            // 生成id
            var shortId = _shortUrlService.Generate(url);
            var shortUrl = $"{Request.Scheme}://{Request.Host}/{shortId}";
            ViewBag.shortUrl = shortUrl;

            return View("Index");
        }

        /// <summary>
        /// 错误页
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}