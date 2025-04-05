namespace LeDinhThang_2122110516.model
{
    public class Product  // ✅ Đúng PascalCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } // Giá nên dùng kiểu decimal
        public string Image { get; set; }  // Nếu là đường dẫn ảnh, nên dùng string

        
       

       
    }
}
