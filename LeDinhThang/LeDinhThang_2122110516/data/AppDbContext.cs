using LeDinhThang_2122110516.model;
using Microsoft.EntityFrameworkCore;

namespace LeDinhThang_2122110516.data  // ✅ Sửa namespace thành "data"
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

       

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-B02KHN4\\THANG;Database=asp;Trusted_Connection=True;");
        //    }
        //}
    }
}
