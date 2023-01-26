using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace TraverselCore.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            ExcelPackage package = new ExcelPackage();
            var workShet = package.Workbook.Worksheets.Add("Sayfa_");
            workShet.Cells[1, 1].Value = "Rota";
            workShet.Cells[1, 2].Value = "Rehber";
            workShet.Cells[1, 3].Value = "Kontenjan";
            workShet.Cells[2, 1].Value = "Güneydoğu Turu";
            workShet.Cells[2, 2].Value = "Selami Toparslan";
            workShet.Cells[2, 3].Value = "27";
            workShet.Cells[3, 1].Value = "Karadeniz Turu";
            workShet.Cells[3, 2].Value = "Faruk Bayat";
            workShet.Cells[3, 3].Value = "60";

            var bytee = package.GetAsByteArray();

            return File(bytee, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
        }
    }
}
