using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraverselCore.Models;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IService<Destination> _destinationService;

        public CityController(IService<Destination> destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CityList()
        {
            var jsonCity =JsonConvert.SerializeObject(await _destinationService.GetAllAsync());
            return Json(jsonCity);
        }

        [HttpPost]
        public async Task<IActionResult> AddCityDestination(Destination destination)
        {
            destination.Statu = true;
            await _destinationService.AddAsync(destination);
            await _destinationService.SaveChangesAsync();
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var values =await _destinationService.FindAsync(id);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public async Task<IActionResult> DeleteCity(Guid id)
        {
            var values =await _destinationService.FindAsync(id);
            _destinationService.Delete(values);
            await _destinationService.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> UpdateCity(Destination destination)
        {
            _destinationService.Update(destination);
            await _destinationService.SaveChangesAsync();
            var value = JsonConvert.SerializeObject(destination);
            
            
            return Json(value);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};


    }
    //[Area("Admin")]
    //public class CityController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //    public IActionResult CityList()
    //    {
    //        var jsonCityInformation = JsonConvert.SerializeObject(Cities);
    //        return Json(jsonCityInformation);
    //    }
    //    public static List<City> Cities = new List<City>
    //    {

    //        new City
    //        {
    //            Id = Guid.Parse("5999739A-95E8-4D51-9168-F23831C6AB25"),
    //            Name= "Istanbul",
    //            Country ="Turkey"
    //        },
    //        new City
    //        {
    //            Id = Guid.Parse("6999739A-95E8-4D51-9168-F23831C6AB25"),
    //            Name= "Berlin",
    //            Country ="Almanya"
    //        },
    //        new City
    //        {
    //            Id = Guid.Parse("6999739A-95E8-4D51-9168-F23831C6AB23"),
    //            Name= "Sidney",
    //            Country ="Avustralya"
    //        }
    //    };
    //}
}
