using System.ComponentModel.DataAnnotations;

namespace LeDinhThang_2122110516.model
{
    public class User
    {
 
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
