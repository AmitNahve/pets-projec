using WebApplicationPetsShop.Models;

namespace WebApplicationPetsShop.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetAlltAnimals();
        void Delete(int id);
        void AddNewAnimal(Animal animal, int Category);
        Animal Details(int id);
        IEnumerable<Animal> AllAnimals();
        IEnumerable<Category> AllCategories();
        IEnumerable<Animal> GetTwoTopedCommentAnimals();
        List<Animal> FilterByCategory(string category);
        void AddNewComment(string comment, int id);
        bool LoggingIn(Admin admin);
        public void EditAnimal(Animal animal);
    }
}
