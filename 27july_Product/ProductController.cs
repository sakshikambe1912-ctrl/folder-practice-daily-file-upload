using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _27julyProduct.Models;

namespace _27julyProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id=1,
                Name="Laptop",
                Quantity= 1,
                Price=78000
            },
            new Product
            {
                Id=2,
                Name="Keyboard",
                Quantity= 8,
                Price=8000
            },
            new Product
            {
                Id=3,
                Name="Mouse",
                Quantity= 20,
                Price=200
            },
            new Product
            {
                Id=4,
                Name="Earphone",
                Quantity= 40,
                Price=2000
            }

        };
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(products);
        }
        [HttpGet("(id)")]
        public IActionResult GetProducts(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);

        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
            return CreatedAtAction(nameof(GetProducts),
                new { id = product.Id }, product);



        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product upadateproduct)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            product.Quantity = upadateproduct.Quantity;
            return NoContent();


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();
            products.Remove(product);
            return NoContent();
        }

    }
}
