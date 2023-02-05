using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraverselCore.Models;

namespace TraverselCore.Controllers
{
    
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5276/api/Visitor");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(json);
                return View(values);

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddVisitor()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();            
            var values = JsonConvert.SerializeObject(visitorViewModel);
            StringContent stringContent = new StringContent(values, Encoding.UTF8,"application/json");
            var response =await client.PostAsync("http://localhost:5276/api/Visitor", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
