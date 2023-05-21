using ASPPresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccessLayer;
using LogicLayer;

namespace ASPPresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("Role") != 1)
            {
                return RedirectToAction("index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Add(string Name)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category(Name, new CategoryDAL());
                category.Save();

                return RedirectToAction("Index", "Dashboard", new { messages = new string[1] { $"De categorie {Name} is succesvol toegevoegd." } });
            }
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}