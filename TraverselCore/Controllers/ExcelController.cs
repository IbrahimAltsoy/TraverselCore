using BusiinessLayer.Abstract;
using ClosedXML.Excel;
using BusiinessLayer;
using DocumentFormat.OpenXml.Office2010.Ink;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraverselCore.Models;

namespace TraverselCore.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            
            

            return View();
        }
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels= new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City= x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,                                      
                    Capacity= x.Capacity

                }).ToList();
            }
            return destinationModels;
        }
        public IActionResult StaticExcelReport()
        {

            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
            //using (var workbook = new XLWorkbook())// Xlmbook kütüphanesini nugetten yüklemesini sağladık.
            //{
            //    var worksheet = workbook.Worksheets.Add("Tur listesi");
            //    worksheet.Cell(1, 1).Value = "Şehir";
            //    worksheet.Cell(1, 2).Value = "Konaklama Süresi";
            //    worksheet.Cell(1, 3).Value = "Ücret";
            //    worksheet.Cell(1, 4).Value = "Kapasite";
            //    int rowCount = 2;
            //    foreach (var item in DestinationList())
            //    {
            //        worksheet.Cell(rowCount, 1).Value = item.City;
            //        worksheet.Cell(rowCount, 2).Value = item.DayNight;
            //        worksheet.Cell(rowCount, 3).Value = item.Price;
            //        worksheet.Cell(rowCount, 4).Value = item.Capacity;
            //        rowCount++;

            //    }
            //    using (var strteam = new MemoryStream())
            //    {
            //        workbook.SaveAs(strteam);
            //        var content = strteam.ToArray();
            //        return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ("Static_"+DateTime.Now.ToShortTimeString()+".xlsx"));
            //    }
            //}
        }
        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())// Xlmbook kütüphanesini nugetten yüklemesini sağladık.
            {
                var worksheet = workbook.Worksheets.Add("Tur listesi");
                worksheet.Cell(1,1).Value= "Şehir";
                worksheet.Cell(1,2).Value= "Konaklama Süresi";
                worksheet.Cell(1,3).Value= "Ücret";
                worksheet.Cell(1,4).Value= "Kapasite";
                int rowCount = 2;
                foreach(var item in DestinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;

                }
                using(var strteam = new MemoryStream())
                {
                    workbook.SaveAs(strteam);
                    var content = strteam.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ("Destination_" + DateTime.Now.ToShortTimeString() + ".xlsx"));
                }
            }
          
        }
    }
}
