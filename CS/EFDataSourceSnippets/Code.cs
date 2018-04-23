using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.DataAccess.EntityFramework;

namespace EFDataSourceSnippets
{
    public class Test
    {
        EFDataSource DataSource { get; set; }
        public Test()
        {
            DataSource = InitializeEFDataSource();
        }
        EFDataSource InitializeEFDataSource()
        {
            return GenerateEFDataSource();
        }
        const string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=pwd;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private EFDataSource GenerateEFDataSource()
        {
            var connectionParameters = new DevExpress.DataAccess.EntityFramework.EFConnectionParameters(typeof(NorthwindEntities), "EntityConnection", connectionString);
            var efDataSource = new DevExpress.DataAccess.EntityFramework.EFDataSource(connectionParameters);

            ((System.ComponentModel.ISupportInitialize)(efDataSource)).BeginInit();
            efDataSource.StoredProcedures.Add(GetStoredProcedure());
            ((System.ComponentModel.ISupportInitialize)(efDataSource)).EndInit();
            return efDataSource;
        }
        private EFStoredProcedureInfo GetStoredProcedure()
        {
            var efParameter1 = new DevExpress.DataAccess.EntityFramework.EFParameter("CustomerID", typeof(string), "ALFKI");
            var efStoredProc = new DevExpress.DataAccess.EntityFramework.EFStoredProcedureInfo("CustOrderHist", new[] { efParameter1 });
            return efStoredProc;
        }
    }
}
