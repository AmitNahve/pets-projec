using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Validators;

namespace WebApplicationPetsShop.Models
{
    public class Animal
    {
        
        public int AnimalId { get; set; }
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Please enter a name")]
        [AllLettersValidation(ErrorMessage = "Only letters allowed.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter only positive number")]
        [Range(0,100 , ErrorMessage = "please enter number between 1 to 100")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter img src")]
        public string? PictureSrc { get; set; }
        [Required(ErrorMessage = "Please write a description")]
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
