using Microsoft.AspNetCore.Mvc;
using WebApiLessons.Dto;
using WebApiLessons.Models;

namespace WebApiLessons.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}