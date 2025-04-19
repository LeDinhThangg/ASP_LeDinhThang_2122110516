using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class Brand
    {
       
        public int Id { get; set; }
        public string BrandName { get; set; }

        public List<Product> Products { get; set; }
    }

}
