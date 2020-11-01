using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskRestAPI.Models
{
    public class PostModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
}
