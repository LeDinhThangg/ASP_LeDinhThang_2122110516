namespace LeDinhThang_2122110516.model.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }  // Thêm Id vào DTO
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
