using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult<IEnumerable<ProductResponse>> GetProducts()
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var list = storageContext.Products.Select(p => new ProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Descriptions,
                    Price = p.Price
                }).ToList();
                return Ok(list);
            }
        }

        [HttpDelete("delete_product/{id}")]
        public ActionResult<DeleteResponse> DeleteProduct(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var product = storageContext.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new DeleteResponse { Success = false, Message = "Product not found" });
                }

                storageContext.Products.Remove(product);
                storageContext.SaveChanges();
                return Ok(new DeleteResponse { Success = true, Message = "Product deleted successfully" });
            }
        }

        [HttpDelete("delete_product_group/{id}")]
        public ActionResult<DeleteResponse> DeleteProductGroup(int id)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var productGroup = storageContext.ProductGroups.Find(id);
                if (productGroup == null)
                {
                    return NotFound(new DeleteResponse { Success = false, Message = "Product group not found" });
                }

                storageContext.ProductGroups.Remove(productGroup);
                storageContext.SaveChanges();
                return Ok(new DeleteResponse { Success = true, Message = "Product group deleted successfully" });
            }
        }

        [HttpPut("update_product_price/{id}")]
        public ActionResult<UpdatePriceResponse> UpdateProductPrice(int id, decimal newPrice)
        {
            using (StorageContext storageContext = new StorageContext())
            {
                var product = storageContext.Products.Find(id);
                if (product == null)
                {
                    return NotFound(new UpdatePriceResponse { Success = false, Message = "Product not found" });
                }

                product.Price = newPrice;
                storageContext.SaveChanges();
                return Ok(new UpdatePriceResponse { Success = true, Message = "Price updated successfully", NewPrice = newPrice });
            }
        }
    }
}
