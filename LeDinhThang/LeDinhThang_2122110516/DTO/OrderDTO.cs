using System;

namespace LeDinhThang_2122110516.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        public int PaymentId { get; set; }

        // Có thể thêm nếu muốn hiển thị thông tin đơn giản
        public string? UserName { get; set; }
        public string? PaymentMethod { get; set; }

       
    }
}
