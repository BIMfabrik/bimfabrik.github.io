using bimfabrik.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

namespace bimfabrik.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHostingEnvironment hostingEnvironment, IHttpClientFactory clientFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Usecase()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Platform()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult eBKP()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsecaseJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/Usecase.json"));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPlatformJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/platform.json"));
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetEbkJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/eBKP.json"));
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
