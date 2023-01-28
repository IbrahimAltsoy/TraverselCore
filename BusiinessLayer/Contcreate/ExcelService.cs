using BusiinessLayer.Abstract;
using OfficeOpenXml;

namespace BusiinessLayer.Contcreate
{
    public class ExcelService : IExcelService
    {
        public byte[] ExcelList<T>(List<T> list) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new ExcelPackage();
            var workSheet = package.Workbook.Worksheets.Add("Sayfa_1");
            workSheet.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light10);
            return package.GetAsByteArray();
            
        }
    }
}
