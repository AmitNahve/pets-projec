namespace WebApplicationPetsShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        ICollection<Animal>? Animals { get; set; }
    }
}
