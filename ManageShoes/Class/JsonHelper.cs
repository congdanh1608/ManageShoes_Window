using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ManageShoes.Class
{
    static class JsonHelper
    {
        public static List<Product> loadProductsFromJson(String content)
        {
            Products products = JsonConvert.DeserializeObject<Products>(content);
            return products.products;
        }

        public static List<Order> loadOrdersFromJson(String content)
        {
            Orders orders = JsonConvert.DeserializeObject<Orders>(content);
            return orders.orders;
        }

        public static VersionUpload loadVersionUploadFromJson(String content)
        {
            VersionUpload versionUpload = JsonConvert.DeserializeObject<VersionUpload>(content);
            return versionUpload;
        }

        public static String ParseProductsToJson(List<Product> _products)
        {
            var pro = new Products
            {
                products = _products
            };
            var json = JsonConvert.SerializeObject(pro);
            return json;
        }

        public static string ParseOrdersToJson(List<Order> _orders)
        {
            var ord = new Orders
            {
                orders = _orders
            };
            var json = JsonConvert.SerializeObject(ord);
            return json;
        }

        public static string ParseVersionUploadToJson(VersionUpload versionUpload)
        {
            var json = JsonConvert.SerializeObject(versionUpload);
            return json;
        }
    }

    public class Products
    {
        public List<Product> products { get; set; }
    }

    public class Orders
    {
        public List<Order> orders { get; set; }
    }

    public class Versions_
    {
        public VersionUpload versions { get; set; }
    }
}
