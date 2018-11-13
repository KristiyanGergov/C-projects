using ClosedXML.Excel;
using System;
using System.Diagnostics;
using System.Linq;

namespace ModifyingFiles
{
    public class StartUp
    {
        public static void Main()
        {
            var wb = new XLWorkbook("Showcase.xlsx");
            var ws = wb.Worksheet(1);
            Copy(wb, ws);
            wb.SaveAs("new.xlsx");
        }

        private static void ChangeStyle(IXLWorksheet ws)
        {
            var rngHeaders = ws.Range("B3:F3");
            rngHeaders.Style.Fill.BackgroundColor = XLColor.LightSalmon;

            var rngDates = ws.Range("E4:E6");
            rngDates.Style.NumberFormat.NumberFormatId = 14;

            var rngIncome = ws.Range("F4:F6");
        }

        public static void Delete(IXLWorksheet ws)
        {
            var firstDataCell = ws.Cell("B4");
            var lastDataCell = ws.LastCellUsed();
            var rng = ws.Range(firstDataCell.Address, lastDataCell.Address);

            using (var range = rng.Rows(r => !string.IsNullOrWhiteSpace(r.Cell(3).GetString()) && !r.Cell(3).GetBoolean()))
            {
                foreach (var item in range)
                {
                    item.Delete();
                }
            }
        }
        public static void Freeze(IXLWorksheet ws)
        {
            ws.SheetView.Freeze(3, 3);
        }
        public static void Copy(XLWorkbook wb, IXLWorksheet ws)
        {
            ws.CopyTo("Copy");
            var newWb = new XLWorkbook();
            wb.Worksheet(1).CopyTo(newWb, "copySheet");
            newWb.SaveAs("copy.xlsx");
        }
    }
}
