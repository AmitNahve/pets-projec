using System.ComponentModel.DataAnnotations;

namespace WebApplicationPetsShop.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        [Display(Name = " Name:")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public string? Password { get; set; }
        
    }
}
