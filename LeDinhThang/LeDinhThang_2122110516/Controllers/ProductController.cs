using LeDinhThang_2122110516.data;
using LeDinhThang_2122110516.model;
using LeDinhThang_2122110516.model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeDinhThang_2122110516.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    Image = p.Image,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    Image = p.Image,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId
                })
                .FirstOrDefaultAsync();

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                ProductName = productDTO.ProductName,
                Description = productDTO.Description,
                Quantity = productDTO.Quantity,
                Price = productDTO.Price,
                Image = productDTO.Image,
                BrandId = productDTO.BrandId,
                CategoryId = productDTO.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.ProductName = productDTO.ProductName;
            product.Description = productDTO.Description;
            product.Quantity = productDTO.Quantity;
            product.Price = productDTO.Price;
            product.Image = productDTO.Image;
            product.BrandId = productDTO.BrandId;
            product.CategoryId = productDTO.CategoryId;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
