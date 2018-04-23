using DevExpress.DataAccess.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataSourceSnippets
{
    public class Code
    {

        void ExcelDataSourceBindingToCSV() {
            // Create a new Excel data source.
            ExcelDataSource excelDataSource = new ExcelDataSource();
            excelDataSource.FileName = "Northwind.csv";

            // Specify import settings.
            CsvSourceOptions csvSourceOptions = new CsvSourceOptions();
            csvSourceOptions.DetectEncoding = true;
            csvSourceOptions.DetectNewlineType = true;
            csvSourceOptions.DetectValueSeparator = true;
            excelDataSource.SourceOptions = csvSourceOptions;
        }

        void ExcelDataSourceBindingToXLS() {
            // Create a new Excel data source.
            ExcelDataSource excelDataSource = new ExcelDataSource();
            excelDataSource.FileName = "Northwind.xlsx";

            // Select a required worksheet.
            ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings();
            excelWorksheetSettings.WorksheetName = "Sheet_Categories";

            // Specify import settings.
            ExcelSourceOptions excelSourceOptions = new ExcelSourceOptions();
            excelSourceOptions.ImportSettings = excelWorksheetSettings;
            excelSourceOptions.SkipHiddenRows = false;
            excelSourceOptions.SkipHiddenColumns = false;
            excelDataSource.SourceOptions = excelSourceOptions;
        }
    }
}
