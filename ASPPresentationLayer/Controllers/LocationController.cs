using ASPPresentationLayer.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using LogicLayer;

namespace ASPPresentationLayer.Controllers
{
    public class LocationController : Controller

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
            BranchContainer branchContainer = new BranchContainer(new BranchDAL());
                List<BranchViewModel> branches = new List<BranchViewModel>();
                foreach (Branch branch in branchContainer.GetAll())
                {
                    branches.Add(ViewModelConverter.ToViewModel(branch));
                }

                ViewBag.Branches = branches;
                return View("Add");
            }

        [HttpPost]
        public IActionResult AddLocation(LocationViewModel model)
        {
            Branch branch = new BranchContainer(new BranchDAL()).Get(model.Branch.ID);
            Location location = new Location(model.LocationNumber, model.MaxCapacity, branch, new LocationDAL());
            location.Save();
            return RedirectToAction("Add");
        }
    }
}