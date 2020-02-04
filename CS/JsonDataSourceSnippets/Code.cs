using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataSourceSnippets
{
    public class Code
    {
        void GenerateJsonDataSource()
        {
            DevExpress.DataAccess.Json.JsonDataSource jsonDataSource = new DevExpress.DataAccess.Json.JsonDataSource();
            Uri sourceUri = new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json");
            jsonDataSource.JsonSource = new DevExpress.DataAccess.Json.UriJsonSource(sourceUri);
            jsonDataSource.Fill();
        }
    }
}
