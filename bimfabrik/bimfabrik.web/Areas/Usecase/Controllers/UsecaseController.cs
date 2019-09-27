using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace bimfabrik.Areas.Auth.Controllers
{
    [Area("Usecase")]
    public class UsecaseController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly HttpClient _httpClient;

        public UsecaseController(IHttpClientFactory client, IHostingEnvironment hostingEnvironment)
        {
            _httpClient = client.CreateClient();
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
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
    }
}
