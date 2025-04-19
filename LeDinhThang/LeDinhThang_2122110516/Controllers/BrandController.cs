using LeDinhThang_2122110516.data;
using LeDinhThang_2122110516.model;
using LeDinhThang_2122110516.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeDinhThang_2122110516.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetBrands()
        {
            var brands = await _context.Brands
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    BrandName = b.BrandName
                })
                .ToListAsync();

            return Ok(brands);
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrand(int id)
        {
            var brand = await _context.Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    BrandName = b.BrandName
                })
                .FirstOrDefaultAsync();

            if (brand == null)
                return NotFound();

            return Ok(brand);
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<ActionResult<BrandDTO>> CreateBrand(BrandDTO brandDTO)
        {
            var brand = new Brand
            {
                BrandName = brandDTO.BrandName
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            var createdBrand = new BrandDTO
            {
                Id = brand.Id,
                BrandName = brand.BrandName
            };

            return CreatedAtAction(nameof(GetBrand), new { id = brand.Id }, createdBrand);
        }

        // PUT: api/Brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandDTO brandDTO)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            brand.BrandName = brandDTO.BrandName;

            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
