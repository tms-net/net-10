using System.ComponentModel.DataAnnotations;

namespace WebApp.MVC.Models
{
    public class PrivacyRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(".+@.+")]
        public string Email { get; set; }
    }
}
