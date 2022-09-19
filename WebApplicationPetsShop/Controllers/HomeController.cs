using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationPetsShop.Data;
using WebApplicationPetsShop.Models;
using WebApplicationPetsShop.Repositories;

namespace WebApplicationPetsShop.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext _shopContext;
        private IRepository _repository;


        public HomeController(ShopContext shopContext, IRepository repository)
        {
            _shopContext = shopContext;
            _repository = repository;
        }
        public IActionResult Index()
        {
            
            return View(_repository.GetTwoTopedCommentAnimals());
        }
        public IActionResult Catalogue()
        {
            
            return View(_repository.GetAlltAnimals());
        }
         public IActionResult Details(int id)
        {
            
            return View(_repository.Details(id));

        }
        
        public IActionResult AnimalByCategory(string category)
        {

            return View("Catalogue",_repository.FilterByCategory(category));
        }

        public IActionResult AddNewComment(string comment , int id)
        {
           _repository.AddNewComment(comment, id);
            return RedirectToAction("Catalogue");
        }



    }

}
