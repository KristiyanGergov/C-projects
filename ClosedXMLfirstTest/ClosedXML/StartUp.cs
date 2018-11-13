using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ClosedXML
{
    public class StartUp
    {
        public static void Main()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GetTable("Showcase.xlsx", out List<string> categories, out List<string> firstNames);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
        }

        private static void GetTable(string showcaseXlsx, out List<string> categories, out List<string> firstNames)
        {
            categories = new List<string>();
            const int coCategoryId = 1;
            const int coCategoryName = 2;

            var wb = new XLWorkbook(showcaseXlsx, XLEventTracking.Disabled);
            var ws = wb.Worksheet("Contacts");


            var firstRowUsed = ws.FirstRowUsed();

            var categoryRow = firstRowUsed.RowUsed();

            categoryRow = categoryRow.RowBelow();

            while (!categoryRow.Cell(coCategoryId).IsEmpty())
            {
                String categoryName = categoryRow.Cell(coCategoryName).GetString();
                categories.Add(categoryName);

                categoryRow = categoryRow.RowBelow();
            }
            categoryRow = categoryRow.RowBelow();
            var row = categoryRow.RowNumber();
            var firstPossibleAddress = ws.Row(categoryRow.RowNumber()).FirstCell().Address;
            var lastPossibleAddress = ws.LastCellUsed().Address;

            var companyRange = ws.Range(firstPossibleAddress, lastPossibleAddress).RangeUsed();

            var companyTable = companyRange.AsTable();

            var tesi = companyTable.LastCellUsed();

            firstNames = companyTable.DataRange
              .Rows(companyRow => 
                                    !companyRow.Field("Fifth").HasFormula && 
                                    !string.IsNullOrWhiteSpace(companyRow.Field("Fifth").GetValue<string>()))
              .Select(companyRow => companyRow.Field("Fifth").GetString())
              .ToList();
        }
        private static void InsertValues()
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Contacts");

            ws.Cell("A1").Value = "Contacts";

            ws.Cell("A2").Value = "FName";
            ws.Cell("A3").Value = "John";
            ws.Cell("A4").Value = "Hank";
            ws.Cell("A5").Value = "Dagny";

            ws.Cell("B2").Value = "LName";
            ws.Cell("B3").Value = "Galt";
            ws.Cell("B4").Value = "Rearden";
            ws.Cell("B5").SetValue("Taggart");

            ws.Cell("C2").Value = "Outcast";
            ws.Cell("C3").Value = true;
            ws.Cell("C4").Value = false;
            ws.Cell("C5").SetValue(false);

            // DateTime
            ws.Cell("D2").Value = "DOB";
            ws.Cell("D3").Value = new DateTime(1919, 1, 21);
            ws.Cell("D4").Value = new DateTime(1907, 3, 4);
            ws.Cell("D5").SetValue(new DateTime(1921, 12, 15)); // Another way to set the value

            // Numeric
            ws.Cell("E2").Value = "Income";
            ws.Cell("E3").Value = 2000;
            ws.Cell("E4").Value = 40000;
            ws.Cell("E5").SetValue(10000); // Another way to set the value
            //ranges
            var rngTable = ws.Range("A1:E5");
            var rngDates = rngTable.Range("D3:D5");
            var rngNumbers = rngTable.Range("E3:E5");

            rngDates.Style.NumberFormat.NumberFormatId = 15;
            rngNumbers.Style.NumberFormat.Format = "$ #,##0";

            rngTable.FirstCell().Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            rngTable.FirstRow().Merge();

            var rngHeaders = rngTable.Row(2);
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            var rngData = ws.Range("A2:E5");
            var excelTable = rngData.CreateTable();

            excelTable.ShowTotalsRow = true;
            excelTable.Field("Income").TotalsRowFunction = XLTotalsRowFunction.Average;
            excelTable.Field("DOB").TotalsRowLabel = "Average:";

            ws.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            ws.Columns().AdjustToContents();

            wb.SaveAs("Showcase.xlsx");
        }
    }
}