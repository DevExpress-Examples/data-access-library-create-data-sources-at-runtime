Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.DataAccess.EntityFramework

Namespace EFDataSourceSnippets
    Public Class Test
        Private Property DataSource() As EFDataSource
        Public Sub New()
            DataSource = InitializeEFDataSource()
        End Sub
        Private Function InitializeEFDataSource() As EFDataSource
            Return GenerateEFDataSource()
        End Function
        Private Const connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=pwd;MultipleActiveResultSets=True;Application Name=EntityFramework"
        Private Function GenerateEFDataSource() As EFDataSource
            Dim connectionParameters = New DevExpress.DataAccess.EntityFramework.EFConnectionParameters(GetType(NorthwindEntities), "EntityConnection", connectionString)
            Dim efDataSource = New DevExpress.DataAccess.EntityFramework.EFDataSource(connectionParameters)

            DirectCast(efDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
            efDataSource.StoredProcedures.Add(GetStoredProcedure())
            DirectCast(efDataSource, System.ComponentModel.ISupportInitialize).EndInit()
            Return efDataSource
        End Function
        Private Function GetStoredProcedure() As EFStoredProcedureInfo
            Dim efParameter1 = New DevExpress.DataAccess.EntityFramework.EFParameter("CustomerID", GetType(String), "ALFKI")
            Dim efStoredProc = New DevExpress.DataAccess.EntityFramework.EFStoredProcedureInfo("CustOrderHist", { efParameter1 })
            Return efStoredProc
        End Function
    End Class
End Namespace
