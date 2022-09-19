using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPetsShop.Data;
using WebApplicationPetsShop.Models;

namespace WebApplicationPetsShop.Repositories
{
    public class Repository: IRepository
    {
        private ShopContext _shopContext;
        public Repository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

       
        public IEnumerable<Animal> GetAlltAnimals()
        {
            return _shopContext.Animals!.Include(c => c.Comments).Include(c => c.Category);

        }
        public void Delete(int id)
        {
            var animal = _shopContext.Animals!.Single(m => m.AnimalId == id);
            _shopContext.Animals!.Remove(animal);
            _shopContext.SaveChanges();
          
        }
       

        public void AddNewAnimal(Animal animal, int Category)
        {
            animal.CategoryId = Category;
            _shopContext.Animals?.Add(animal);

            _shopContext.SaveChanges();
           
        }
        
      
        public Animal Details(int id)
        {
            return _shopContext.Animals!.Include(c => c.Comments).Single(m => m.AnimalId == id);
            

        }

       
        public IEnumerable<Animal> GetTwoTopedCommentAnimals()
        {
            var animal = _shopContext.Animals!.Include(c => c.Comments);
            var towAnimals = animal!.OrderByDescending(p => p.Comments!.Count).Take(2).ToList();
            return towAnimals;

        }

        public List<Animal> FilterByCategory(string category)
        {
            if (category == null)
            {
                return _shopContext.Animals!.ToList();
            }
            else
            {
                return _shopContext.Animals!.Include(c => c.Category).Where(c => c.Category!.Name == category).ToList();
            }
        }
        public IEnumerable<Animal> AllAnimals() => _shopContext.Animals!;
        public IEnumerable<Category> AllCategories()
        {
            var categories = _shopContext.Categories!
                
                .ToList();
            return categories;
        }
        public void AddNewComment(string comment, int id)
        {
            var c = new Comment { CommentText = comment };
            var animal = _shopContext.Animals!.Include(c => c.Comments).Single(m => m.AnimalId == id);
            animal.Comments?.Add(c);
            _shopContext.SaveChanges();
           
        }
        public bool LoggingIn(Admin admin)
        {
            var ad= _shopContext.Admins!.FirstOrDefault(a => a.Name == admin.Name && a.Password == admin.Password);
            if (ad == null) { return false; }
            else { return true; }
        }
        public void EditAnimal(Animal animal)
        {
            var selectedAnimal = Details((int)animal.AnimalId);

            selectedAnimal.Name = animal.Name;
            selectedAnimal.Age = animal.Age;
            selectedAnimal.CategoryId = animal.CategoryId;
            selectedAnimal.Description = animal.Description;
            selectedAnimal.PictureSrc = animal.PictureSrc;

            _shopContext.SaveChanges();
        }
    }
}
