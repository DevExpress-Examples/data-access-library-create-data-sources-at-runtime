Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql

Namespace SqlDataSourceSnippets
    Public Class Code
        Private Property DataSource() As SqlDataSource
        Private Sub SqlDataSourceInitialization()
            '1)
            Dim myConnectionName = "Northwind_Connection"
            Dim DataSource As New SqlDataSource(myConnectionName)
            '2)
            'MsSqlConnectionParameters connectionParameters = new MsSqlConnectionParameters(".", "NWind", null, null, MsSqlAuthorizationType.Windows);
            'SqlDataSource ds1 = new SqlDataSource(connectionParameters);
        End Sub
        Private Sub SelectQueryCreation()
            Dim query As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectColumn("CategoryName").GroupBy("CategoryName").Join("Products", "CategoryID").SelectColumn("ProductName", AggregationType.Count, "ProductCount").SortBy("ProductName", AggregationType.Count, System.ComponentModel.ListSortDirection.Descending).GroupFilter("[ProductCount] > 7").Build("Categories")
            DataSource.Queries.Add(query)

            QueryParameterInitialization(query)
        End Sub
        Private Sub StoredProcedureInitialization()
            Dim spQuery As New StoredProcQuery("StoredProcedure", "stored_procedure_name")
            spQuery.Parameters.Add(New QueryParameter("@First", GetType(Integer), 0))
            spQuery.Parameters.Add(New QueryParameter("@Second", GetType(String), "Value"))
            spQuery.Parameters.Add(New QueryParameter("@Third", GetType(String), "Value"))

            DataSource.Queries.Add(spQuery)
        End Sub
        Private Sub QueryParameterInitialization(ByVal query As SelectQuery)
            Dim parameter As New QueryParameter() With {.Name = "catID", .Type = GetType(DevExpress.DataAccess.Expression), .Value = New DevExpress.DataAccess.Expression("[Parameters.catID]", GetType(System.Int32))}
            query.Parameters.Add(parameter)
            query.FilterString = "CategoryID = ?catID"
        End Sub
        Private Sub CustomSqlQueryInitialization()
            Dim query As New CustomSqlQuery()
            query.Name = "CustomQuery"
            query.Sql = "Select top 10 * from Products"

            DataSource.Queries.Add(query)
        End Sub
        Private Sub RelationshipInitialization()
            Dim categories As SelectQuery = SelectQueryFluentBuilder.AddTable("Categories").SelectAllColumns().Build("Categories")
            Dim products As SelectQuery = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("Products")

            DataSource.Queries.AddRange(New SqlQuery() { categories, products })
            DataSource.Relations.Add(New MasterDetailInfo("Categories", "Products", "CategoryID", "CategoryID"))
        End Sub
    End Class
End Namespace
