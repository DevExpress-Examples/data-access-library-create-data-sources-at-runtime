Imports DevExpress.DataAccess.EntityFramework

Namespace EFDataSourceSnippets

    Public Class Test

        Private Property DataSource As EFDataSource

        Public Sub New()
            DataSource = InitializeEFDataSource()
        End Sub

        Private Function InitializeEFDataSource() As EFDataSource
            Return GenerateEFDataSource()
        End Function

        Const connectionString As String = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=pwd;MultipleActiveResultSets=True;Application Name=EntityFramework"

        Private Function GenerateEFDataSource() As EFDataSource
            Dim connectionParameters = New EFConnectionParameters(GetType(NorthwindEntities), "EntityConnection", connectionString)
            Dim efDataSource = New EFDataSource(connectionParameters)
            CType(efDataSource, System.ComponentModel.ISupportInitialize).BeginInit()
            efDataSource.StoredProcedures.Add(GetStoredProcedure())
            CType(efDataSource, System.ComponentModel.ISupportInitialize).EndInit()
            Return efDataSource
        End Function

        Private Function GetStoredProcedure() As EFStoredProcedureInfo
            Dim efParameter1 = New EFParameter("CustomerID", GetType(String), "ALFKI")
            Dim efStoredProc = New EFStoredProcedureInfo("CustOrderHist", {efParameter1})
            Return efStoredProc
        End Function
    End Class
End Namespace
