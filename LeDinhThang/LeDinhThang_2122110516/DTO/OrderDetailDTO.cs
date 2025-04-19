namespace LeDinhThang_2122110516.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Nếu cần trả về tên sản phẩm
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
