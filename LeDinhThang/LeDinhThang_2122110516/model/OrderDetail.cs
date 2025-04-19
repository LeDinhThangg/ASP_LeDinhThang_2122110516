using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class OrderDetail
    {
   
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
    }

}
