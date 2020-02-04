using DevExpress.DataAccess.DataFederation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FederationDataSourceSnippets
{
    public class Code
    {
        void CreateFederationDataSource()
        {
            var sqlDataSource = SqlDataSourceSnippets.Code.CreateSqlDataSource();
            var excelDataSource = ExcelDataSourceSnippets.Code.CreateExcelDataSource();
            // Create the federated query's SQL and Excel sources.
            Source sqlSource = new Source(sqlDataSource.Name, sqlDataSource, "Categories");
            Source excelSource = new Source(excelDataSource.Name, excelDataSource, "");

            // Create a federated query.
            var selectNode = sqlSource.From()
                // Select the "CategoryName" column from the SQL source.
                .Select("CategoryName")
                // Join the SQL source with the Excel source based on the "CategoryID" key field.
                .Join(excelSource, "[Excel_Products.CategoryID] = [Sql_Categories.CategoryID]")
                // Select columns from the Excel source.
                .Select("CategoryID", "ProductName", "UnitPrice")
                // Specify the query's name and build it. 
                .Build("CategoriesProducts");

            // Create a federated data source and add the federated query to the collection.
            var federationDataSource = new FederationDataSource();
            federationDataSource.Queries.Add(selectNode);
            // Build the data source schema to display it in the Field List.
            federationDataSource.RebuildResultSchema();
        }

    }
}
