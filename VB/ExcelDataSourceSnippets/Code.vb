Imports DevExpress.DataAccess.Excel
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace ExcelDataSourceSnippets
	Public Class Code

		Private Sub ExcelDataSourceBindingToCSV()
			' Create a new Excel data source.
			Dim excelDataSource As New ExcelDataSource()
			excelDataSource.FileName = "Northwind.csv"

			' Specify import settings.
			Dim csvSourceOptions As New CsvSourceOptions()
			csvSourceOptions.DetectEncoding = True
			csvSourceOptions.DetectNewlineType = True
			csvSourceOptions.DetectValueSeparator = True
			excelDataSource.SourceOptions = csvSourceOptions
		End Sub

		Private Sub ExcelDataSourceBindingToXLS()
			' Create a new Excel data source.
			Dim excelDataSource As New ExcelDataSource()
			excelDataSource.FileName = "Northwind.xlsx"

			' Select a required worksheet.
			Dim excelWorksheetSettings As New ExcelWorksheetSettings()
			excelWorksheetSettings.WorksheetName = "Sheet_Categories"

			' Specify import settings.
			Dim excelSourceOptions As New ExcelSourceOptions()
			excelSourceOptions.ImportSettings = excelWorksheetSettings
			excelSourceOptions.SkipHiddenRows = False
			excelSourceOptions.SkipHiddenColumns = False
			excelDataSource.SourceOptions = excelSourceOptions
		End Sub

		Public Shared Function CreateExcelDataSource() As ExcelDataSource
			Dim excelDataSource = New ExcelDataSource() With {.Name = "Excel_Products"}
			excelDataSource.FileName = "Products.xlsx"
			excelDataSource.SourceOptions = New ExcelSourceOptions() With {.ImportSettings = New ExcelWorksheetSettings("Sheet")}
			excelDataSource.RebuildResultSchema()
			Return excelDataSource
		End Function

	End Class
End Namespace
