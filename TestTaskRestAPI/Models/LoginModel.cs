using System.ComponentModel.DataAnnotations;

namespace TestTaskRestAPI.Authorization
{
    public class LoginModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}