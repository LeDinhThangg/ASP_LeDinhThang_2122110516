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
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    UserId = o.UserId,
                    PaymentId = o.PaymentId,
                    UserName = o.User.Username,  // Lấy tên người dùng
                    PaymentMethod = o.Payment.PaymentMethod,  // Lấy phương thức thanh toán
                   
                })
                .ToListAsync();

            return Ok(orders);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Where(o => o.Id == id)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    UserId = o.UserId,
                    PaymentId = o.PaymentId,
                    UserName = o.User.Username,
                    PaymentMethod = o.Payment.PaymentMethod,
                   
                })
                .FirstOrDefaultAsync();

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {
                OrderDate = orderDTO.OrderDate,
                UserId = orderDTO.UserId,
                PaymentId = orderDTO.PaymentId,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDTO)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            order.OrderDate = orderDTO.OrderDate;
            order.UserId = orderDTO.UserId;
            order.PaymentId = orderDTO.PaymentId;

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
