using DevExpress.DataAccess.ObjectBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDataSourceSnippets
{
    public class BindingToParametrizedConstructor
    {
        void ObjectDataSourceInitialization()
        {
            ObjectDataSource objds = new ObjectDataSource();
            objds.Name = "ObjectDataSource1";
            objds.BeginUpdate();
            objds.DataMember = "Items";
            objds.DataSource = typeof(BusinessObject);
            objds.EndUpdate();
            //this line of code allows passing a parameter value to a parametrized constructor of an underlying data source object
            var parameter = new DevExpress.DataAccess.ObjectBinding.Parameter("p1", typeof(int), 3);
            objds.Constructor = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo(parameter);
        }
        public class BusinessObject
        {
            public SampleItems Items { get; set; }
            public BusinessObject(int p1)
            {
                Items = new SampleItems(p1);
            }
        }

        public class SampleItems : List<SampleItem>
        {
            public SampleItems() : this(10) { }
            public SampleItems(int itemNumber)
            {
                for (int i = 0; i < itemNumber; i++)
                {
                    Add(new SampleItem() { Name = i.ToString() });
                }
            }
        }
        public class SampleItem
        {
            public string Name { get; set; }
        }
    }


    public class BindingToMethod
    {
        void ObjectDataSourceInitialization()
        {
            DevExpress.DataAccess.ObjectBinding.ObjectDataSource objds = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            objds.Name = "ObjectDataSource1";

            objds.BeginUpdate();
            objds.DataMember = "GetData";
            objds.DataSource = typeof(SampleItem);
            objds.EndUpdate();

            var parameter = new DevExpress.DataAccess.ObjectBinding.Parameter("value", typeof(int), 3);
            objds.Parameters.Add(parameter);
            //this line of code is required to obtain the data source object schema
            objds.Fill();
        }

        public class SampleItem
        {
            public string Name { get; set; }

            public static List<SampleItem> GetData(int value)
            {
                List<SampleItem> items = new List<SampleItem>();
                for (int i = 0; i < value; i++)
                {
                    items.Add(new SampleItem() { Name = i.ToString() });
                }
                return items;
            }
        }
    }
}
