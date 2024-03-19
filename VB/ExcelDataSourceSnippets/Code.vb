Imports DevExpress.DataAccess.Excel

Namespace ExcelDataSourceSnippets

    Public Class Code

        Private Sub ExcelDataSourceBindingToCSV()
            ' Create a new Excel data source.
            Dim excelDataSource As ExcelDataSource = New ExcelDataSource()
            excelDataSource.FileName = "Northwind.csv"
            ' Specify import settings.
            Dim csvSourceOptions As CsvSourceOptions = New CsvSourceOptions()
            csvSourceOptions.DetectEncoding = True
            csvSourceOptions.DetectNewlineType = True
            csvSourceOptions.DetectValueSeparator = True
            excelDataSource.SourceOptions = csvSourceOptions
        End Sub

        Private Sub ExcelDataSourceBindingToXLS()
            ' Create a new Excel data source.
            Dim excelDataSource As ExcelDataSource = New ExcelDataSource()
            excelDataSource.FileName = "Northwind.xlsx"
            ' Select a required worksheet.
            Dim excelWorksheetSettings As ExcelWorksheetSettings = New ExcelWorksheetSettings()
            excelWorksheetSettings.WorksheetName = "Sheet_Categories"
            ' Specify import settings.
            Dim excelSourceOptions As ExcelSourceOptions = New ExcelSourceOptions()
            excelSourceOptions.ImportSettings = excelWorksheetSettings
            excelSourceOptions.SkipHiddenRows = False
            excelSourceOptions.SkipHiddenColumns = False
            excelDataSource.SourceOptions = excelSourceOptions
        End Sub
    End Class
End Namespace
