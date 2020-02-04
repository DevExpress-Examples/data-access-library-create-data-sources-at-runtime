Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace JsonDataSourceSnippets
	Public Class Code
		Private Sub GenerateJsonDataSource()
			Dim jsonDataSource As New DevExpress.DataAccess.Json.JsonDataSource()
			Dim sourceUri As New Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json")
			jsonDataSource.JsonSource = New DevExpress.DataAccess.Json.UriJsonSource(sourceUri)
			jsonDataSource.Fill()
		End Sub
	End Class
End Namespace
