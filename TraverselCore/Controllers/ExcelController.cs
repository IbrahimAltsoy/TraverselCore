using ClosedXML.Excel;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraverselCore.Models;

namespace TraverselCore.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            //ExcelPackage package = new ExcelPackage();
            //var workShet = package.Workbook.Worksheets.Add("Sayfa_");
            //workShet.Cells[1, 1].Value = "Rota";
            //workShet.Cells[1, 2].Value = "Rehber";
            //workShet.Cells[1, 3].Value = "Kontenjan";
            //workShet.Cells[2, 1].Value = "Güneydoğu Turu";
            //workShet.Cells[2, 2].Value = "Selami Toparslan";
            //workShet.Cells[2, 3].Value = "27";
            //workShet.Cells[3, 1].Value = "Karadeniz Turu";
            //workShet.Cells[3, 2].Value = "Faruk Bayat";
            //workShet.Cells[3, 3].Value = "60";

            //var bytee = package.GetAsByteArray();

            //return File(bytee, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
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
            using (var workbook = new XLWorkbook())// Xlmbook kütüphanesini nugetten yüklemesini sağladık.
            {
                var worksheet = workbook.Worksheets.Add("Tur listesi");
                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Konaklama Süresi";
                worksheet.Cell(1, 3).Value = "Ücret";
                worksheet.Cell(1, 4).Value = "Kapasite";
                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;

                }
                using (var strteam = new MemoryStream())
                {
                    workbook.SaveAs(strteam);
                    var content = strteam.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ("Static_"+DateTime.Now.ToShortTimeString()+".xlsx"));
                }
            }
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
