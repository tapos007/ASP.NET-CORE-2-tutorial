using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solution.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Get all products
        /// </summary> 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductInformation.Products;
        }

        /// <summary>
        /// Get a single product
        /// </summary>
        /// <param name="id"></param> 
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return ProductInformation.SingleProduct(id);
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Product product)
        {
            return ProductInformation.AddProduct(product);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Product product)
        {
            return ProductInformation.UpdateProduct(id, product);
        }


        /// <summary>
        /// Deletes a specific Product.
        /// </summary>
        /// <param name="id"></param> 
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return ProductInformation.DeleteProduct(id);
        }
    }
}
