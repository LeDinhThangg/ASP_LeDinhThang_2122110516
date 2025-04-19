using LeDinhThang_2122110516.data;
using LeDinhThang_2122110516.model;
using LeDinhThang_2122110516.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeDinhThang_2122110516.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPayments()
        {
            var payments = await _context.Payments
                .Select(p => new PaymentDTO
                {
                    Id = p.Id,
                    PaymentMethod = p.PaymentMethod
                }).ToListAsync();

            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetPayment(int id)
        {
            var payment = await _context.Payments
                .Where(p => p.Id == id)
                .Select(p => new PaymentDTO
                {
                    Id = p.Id,
                    PaymentMethod = p.PaymentMethod
                })
                .FirstOrDefaultAsync();

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(PaymentDTO paymentDTO)
        {
            var payment = new Payment
            {
                PaymentMethod = paymentDTO.PaymentMethod
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDTO paymentDTO)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            payment.PaymentMethod = paymentDTO.PaymentMethod;

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
