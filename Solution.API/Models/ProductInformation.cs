using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.Models
{
    public class ProductInformation
    {

        public  static List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Java how to program",
                Description = "it a good book"
            },
            new Product()
            {
                Id = 2,
                Name = "pro asp.net mvc5",
                Description = "it a good book"
            },
            new Product()
            {
                Id = 3,
                Name = "php lora thomson",
                Description = "it a good book"
            },
            new Product()
            {
                Id = 4,
                Name = "I love nodejs",
                Description = "it a good book"
            }
        };

        public static Product SingleProduct(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public static string AddProduct(Product product)
        {
            Products.Add(product);
            return "product insert successfully";
        }

        public static string DeleteProduct(int id)
        {
            return "product delete successfully";
        }

        public static string UpdateProduct(int id,Product product)
        {
            return "product update successfully";
        }

        


    }
}
