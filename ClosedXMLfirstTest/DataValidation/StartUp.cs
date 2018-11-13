using ClosedXML.Excel;

namespace DataValidation
{
    public class StartUp
    {
        public static void Main()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Data validation");
            ws.CopyTo("hidden sheet");

            ws.Cell(1, 1).SetValue("123");
            var type = ws.Cell(1, 1).Value.GetType();
            wb.SaveAs("dataValidation.xlsx");


        }
    }
}
