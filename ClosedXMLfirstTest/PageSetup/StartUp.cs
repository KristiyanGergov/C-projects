using ClosedXML.Excel;

namespace RangeNames
{
    public class StartUp
    {
        public static void Main()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Example");
            ws.Range("Numbers");



        }
    }
}
