using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class Category
    {
      
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }




}
