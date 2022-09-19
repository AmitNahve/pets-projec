using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationPetsShop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        [ForeignKey("Animal")]
        public int  AnimalId { get; set; }

    }
}
