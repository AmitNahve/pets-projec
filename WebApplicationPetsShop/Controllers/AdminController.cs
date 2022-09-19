using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPetsShop.Data;
using WebApplicationPetsShop.Models;
using WebApplicationPetsShop.Repositories;

namespace WebApplicationPetsShop.Controllers
{
    public class AdminController : Controller
    {
       
        private IRepository _repository;
        public AdminController( IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Admin()
        {
            return View(_repository.GetAlltAnimals());
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoggingIn(Admin admin)
        {
            if (ModelState.IsValid && _repository.LoggingIn(admin))
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return View("Login");
            }
        }
        
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Admin");
        }
        public IActionResult AddAnimal()
        {
            return View();
        }
        public IActionResult EditAnimal(int id)
        {
            IEnumerable<Category> categories = _repository.AllCategories();
            ViewBag.categories = categories;
            return View(_repository.Details(id));
        }

        public IActionResult EditExecution(int animalId, int age, string name, int categoryId, string description, string pictureSrc)
        {
            if (ModelState.IsValid)
            {
                Animal animal = new Animal
                {
                    AnimalId = animalId,
                    Age = age,
                    Name = name,
                    CategoryId = categoryId,
                    Description = description,
                    PictureSrc = pictureSrc
                };

                _repository.EditAnimal(animal);

                return RedirectToAction("Admin");
            }
            else
                return View("EditAnimal", new { animalId = animalId });
        }

            public IActionResult AddNewAnimal(Animal animal,int Category)
        {
            if (ModelState.IsValid)
            {
              
                _repository.AddNewAnimal(animal, Category);
                return RedirectToAction("Admin");
            }
            else
            {
                return View("AddAnimal");
            }
           
        }



    }
}
