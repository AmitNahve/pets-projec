using Microsoft.EntityFrameworkCore;
using WebApplicationPetsShop.Models;

namespace WebApplicationPetsShop.Data
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Admin>? Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Birds" },
                 new Category { CategoryId = 2, Name = "Invertebrates" },
                 new Category { CategoryId = 3, Name = "Fish" },
                  new Category { CategoryId = 4, Name = "Mammals" },
                   new Category { CategoryId = 5, Name = "Reptiles" },
                   new Category { CategoryId = 6, Name = "Amphibians" }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, AnimalId = 1, CommentText = "Good" },
                new Comment { CommentId = 2,AnimalId = 1, CommentText = "exellent" },
                new Comment { CommentId = 3,AnimalId = 2,CommentText = "Lovly" },
                new Comment { CommentId = 4,AnimalId = 3, CommentText = "Easy to care" },
                new Comment { CommentId = 5,AnimalId = 4, CommentText = "Easy to care" },
                new Comment { CommentId = 6,AnimalId = 5, CommentText = "Easy to care" },
                new Comment { CommentId = 7,AnimalId = 5, CommentText = "Easy to care" },
                new Comment { CommentId = 8, AnimalId = 1, CommentText = "exellent" },
                new Comment { CommentId = 9, AnimalId = 6, CommentText = "Lovly" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "Dror", Age = 7, PictureSrc = "https://images1.ynet.co.il/PicServer5/2017/04/07/7704426/Photo26.jpg", Description = "Dror description" ,CategoryId=1 },
                new { AnimalId = 2, Name = "Snail", Age = 40, PictureSrc = "https://upload.wikimedia.org/wikipedia/commons/c/cc/Snail.jpg", Description = "snail desc", CategoryId = 2 },
                new { AnimalId = 3, Name = "Salmon", Age = 2, PictureSrc = "https://upload.wikimedia.org/wikipedia/commons/3/39/Salmo_salar.jpg", Description = "salmon desc", CategoryId = 3 },
                new { AnimalId = 4, Name = "Tiger", Age = 6, PictureSrc = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Walking_tiger_female.jpg", Description = " tiger desc", CategoryId = 4 },
                new { AnimalId = 5, Name = "Aligator", Age = 2, PictureSrc = "https://www.thoughtco.com/thmb/Eydgd4WW-vQhhUzreDHeCBVEj-Q=/650x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/Crocodile-58a4997d3df78c4758b362e4.jpg", Description = "aligator desc", CategoryId = 5 },
                new { AnimalId = 6, Name = "Frog", Age = 3, PictureSrc = "https://www.thoughtco.com/thmb/hwaxmmF-BmtNA7VFcRzfADA2u3k=/650x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/amphibian-58a496d83df78c4758b13589.jpg", Description = "frog desc",  CategoryId = 6 }
               
            );
            modelBuilder.Entity<Admin>().HasData(new{ AdminId = 1, Name ="Amit", Password = "1234"},
                new{ AdminId = 2, Name ="Maayan", Password = "0000"});
        }
    }
}
