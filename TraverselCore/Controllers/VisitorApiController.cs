using Azure;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
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
        public async Task<IActionResult> DeleteVisitor(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5276/api/Visitor/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5276/api/Visitor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<VisitorViewModel>(json);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var values = JsonConvert.SerializeObject(visitorViewModel);
            StringContent stringContent = new StringContent(values, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5276/api/Visitor/{visitorViewModel.Id}", stringContent);
         
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            //var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, brand);
            return View();
        }

    }
}
