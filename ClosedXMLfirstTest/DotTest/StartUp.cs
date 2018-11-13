using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotTest
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("First");

            ws.FirstCell().Style.NumberFormat.Format = "@";
            var value = ws.FirstCell().Value = 156555.789;
            var type = ws.FirstCell().Value.GetType();
            wb.SaveAs("test.xlsx");
        }
    }
}