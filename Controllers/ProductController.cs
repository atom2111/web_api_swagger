using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiLessons.Data;
using WebApiLessons.Models;

namespace WebApiLessons.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public ActionResult<int> AddProduct(string name, string description, decimal price)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                if (storageContext.Products.Any(p => p.Name == name))
                {
                    return StatusCode(409);
                }
                var product = new Product() { Name = name, Descriptions = description, Price = price };
                storageContext.Products.Add(product);
                storageContext.SaveChanges();
                return Ok(product.Id);
            }
        }

        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            using(StorageContext storageContext = new StorageContext())
            {
                var list = storageContext.Products.Select(p => new Product {Name = p.Name, Descriptions = p.Descriptions, Price = p.Price }).ToList();
                return Ok(list);
            }
        }
    }
}
