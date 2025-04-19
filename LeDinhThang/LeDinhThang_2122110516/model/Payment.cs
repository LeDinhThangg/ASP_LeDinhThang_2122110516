using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }

        public List<Order> Orders { get; set; }
    }

}
