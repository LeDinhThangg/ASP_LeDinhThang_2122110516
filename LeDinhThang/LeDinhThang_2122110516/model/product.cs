﻿using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class Product
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }

}
