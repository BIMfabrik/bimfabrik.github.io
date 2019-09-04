

using bimfabrik.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            dynamic obj = new { Username = "test", Password = "test" };
            var myContent = JsonConvert.SerializeObject(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync("https://localhost:44316/api/Users/authenticate", byteContent);
            return View();
        }

        public IActionResult Usecase()
        {
            return View();
        }

        public IActionResult Platform()
        {
            return View();
        }

        public IActionResult eBKP()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetUsecaseJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/Usecase.json"));
        }

        [HttpGet]
        public IActionResult GetPlatformJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/platform.json"));
        }

        [HttpGet]
        public IActionResult GetEbkJson()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content(System.IO.File.ReadAllText(contentRootPath + "/Data/eBKP.json"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
