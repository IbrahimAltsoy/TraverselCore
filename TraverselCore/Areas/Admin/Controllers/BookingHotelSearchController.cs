using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraverselCore.Areas.Admin.Models;

namespace TraverselCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]    
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?room_number=1&checkout_date=2023-08-19&dest_type=city&dest_id=-553173&adults_number=2&locale=en-gb&checkin_date=2023-08-18&order_by=popularity&filter_by_currency=EUR&units=metric&page_number=0&children_number=2&include_adjacency=true&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0"),
                Headers =
    {
        { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".", "");
                var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
        }
        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View();
            }
        }
    }
    
}
