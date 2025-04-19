using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class Order
    {
     
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }

}
