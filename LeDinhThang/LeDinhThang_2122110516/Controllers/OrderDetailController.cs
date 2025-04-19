using LeDinhThang_2122110516.data;
using LeDinhThang_2122110516.DTO;
using LeDinhThang_2122110516.model;
using LeDinhThang_2122110516.model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeDinhThang_2122110516.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetOrderDetails()
        {
            var orderDetails = await _context.OrderDetails
                .Include(od => od.Product)  // Nếu muốn lấy thông tin sản phẩm, có thể dùng Include
                .Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    ProductName = od.Product.ProductName, // Lấy tên sản phẩm
                    Quantity = od.Quantity,
                    Price = od.Price
                })
                .ToListAsync();

            return Ok(orderDetails);
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDTO>> GetOrderDetail(int id)
        {
            var orderDetail = await _context.OrderDetails
                .Include(od => od.Product)
                .Where(od => od.Id == id)
                .Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    ProductName = od.Product.ProductName,
                    Quantity = od.Quantity,
                    Price = od.Price
                })
                .FirstOrDefaultAsync();

            if (orderDetail == null)
                return NotFound();

            return Ok(orderDetail);
        }

        // POST: api/OrderDetail
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> CreateOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
                Quantity = orderDetailDTO.Quantity,
                Price = orderDetailDTO.Price
            };

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Id }, orderDetail);
        }

        // PUT: api/OrderDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailDTO orderDetailDTO)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
                return NotFound();

            orderDetail.OrderId = orderDetailDTO.OrderId;
            orderDetail.ProductId = orderDetailDTO.ProductId;
            orderDetail.Quantity = orderDetailDTO.Quantity;
            orderDetail.Price = orderDetailDTO.Price;

            _context.Entry(orderDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
                return NotFound();

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
