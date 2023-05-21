using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPPresentationLayer.Models;
using DataAccessLayer;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPPresentationLayer.Controllers
{
    public class BranchController : Controller
    {
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
            BranchViewModel model = new BranchViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                Branch branch = new Branch(model.PlaceName, model.StreetName, model.HouseNumber, model.PostalCode, new BranchDAL());
                branch.Save();
                string[] message = new string[1] {$"Vestiging ({model.PlaceName}, {model.StreetName} {model.HouseNumber} {model.PostalCode}) is succesvol toegevoegd!"};
                return RedirectToAction("Index", "Dashboard", new { messages = message });
            }
            return View(model);
        }
    }
}

