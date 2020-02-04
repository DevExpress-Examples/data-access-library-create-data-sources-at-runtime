Imports DevExpress.DataAccess.DataFederation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace FederationDataSourceSnippets
	Public Class Code
		Private Sub CreateFederationDataSource()
			Dim sqlDataSource = SqlDataSourceSnippets.Code.CreateSqlDataSource()
			Dim excelDataSource = ExcelDataSourceSnippets.Code.CreateExcelDataSource()
			' Create the federated query's SQL and Excel sources.
			Dim sqlSource As New Source(sqlDataSource.Name, sqlDataSource, "Categories")
			Dim excelSource As New Source(excelDataSource.Name, excelDataSource, "")

			' Create a federated query.
			Dim selectNode = sqlSource.From().Select("CategoryName").Join(excelSource, "[Excel_Products.CategoryID] = [Sql_Categories.CategoryID]").Select("CategoryID", "ProductName", "UnitPrice").Build("CategoriesProducts")
				' Select the "CategoryName" column from the SQL source.
				' Join the SQL source with the Excel source based on the "CategoryID" key field.
				' Select columns from the Excel source.
				' Specify the query's name and build it. 

			' Create a federated data source and add the federated query to the collection.
			Dim federationDataSource = New FederationDataSource()
			federationDataSource.Queries.Add(selectNode)
			' Build the data source schema to display it in the Field List.
			federationDataSource.RebuildResultSchema()
		End Sub

	End Class
End Namespace
