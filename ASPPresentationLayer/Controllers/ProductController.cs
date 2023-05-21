using ASPPresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccessLayer;
using LogicLayer;

namespace ASPPresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string[] messages)
        {
            // to-do: if (admin == false) return Dashboard Index
            List<ProductViewModel> model = new List<ProductViewModel>();
            foreach (Product product in new ProductContainer(new ProductDAL()).GetAll())
            {
                model.Add(ViewModelConverter.ToViewModel(product));
            }
            List<CategoryViewModel> categoryModels = new List<CategoryViewModel>();
            foreach (Category category in new CategoryContainer(new CategoryDAL()).GetAll())
            {
                categoryModels.Add(ViewModelConverter.ToViewModel(category));
            }
            List<BranchViewModel> branchModels = new List<BranchViewModel>();
            foreach (Branch branch in new BranchContainer(new BranchDAL()).GetAll())
            {
                branchModels.Add(ViewModelConverter.ToViewModel(branch));
            }
            ViewBag.Categories = categoryModels;
            ViewBag.Branch = branchModels;
            ViewBag.Info = messages;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int[] checkedProductIDs)
        {
            if (checkedProductIDs.Length == 0)
            {
                string[] message = new string[1] {"Fout: Selecteer eerst een product om aan te passen." };
                return RedirectToAction("List", new { messages = message });
            }
            List<ProductViewModel> products = new List<ProductViewModel>();
            ProductContainer container = new ProductContainer(new ProductDAL());
            foreach (int ID in checkedProductIDs)
            {
                products.Add(ViewModelConverter.ToViewModel(container.Get(ID)));
            }

            ProductChangeViewModel model = new ProductChangeViewModel
            {
                Products = products,
                AddSubtract = new string[checkedProductIDs.Length],
                Amounts = new int[checkedProductIDs.Length]
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Change(ProductChangeViewModel productChangeViewModel)
        {
            ProductContainer productContainer = new ProductContainer(new ProductDAL());
            List<Product> newProducts = new List<Product>();

            string errors = "";
            List<ProductViewModel> invalidProducts = new List<ProductViewModel>();
            for (int i = 0; i < productChangeViewModel.Products.Count; i++)
            {
                try
                {
                    productContainer.Get(productChangeViewModel.Products[i].ID);
                } catch (NullReferenceException)
                {
                    errors += $"Fout: een product dat je wilde aanpassen ({productChangeViewModel.Products[i].Name}) kan niet meer gevonden worden.\n";
                    invalidProducts.Add(productChangeViewModel.Products[i]);
                    continue;
                }

                Product oldProduct = productContainer.Get(productChangeViewModel.Products[i].ID);
                int result = 0;
                if (productChangeViewModel.AddSubtract[i] == "-")
                {
                    result = oldProduct.Amount - productChangeViewModel.Amounts[i];
                }

                if (productChangeViewModel.AddSubtract[i] == "+")
                {
                    result = oldProduct.Amount + productChangeViewModel.Amounts[i];
                }
                if (result > 0)
                {
                    newProducts.Add( new Product( oldProduct.ID, oldProduct.Name, oldProduct.Barcode, result, oldProduct.Location, oldProduct.Category, oldProduct.Size, new ProductDAL()));
                }
                else
                {
                    ViewBag.Info = $"Fout: je actie zorgt ervoor dat het aantal van het product '{oldProduct.Name}' lager is dan nul ({result}). Selecteer een andere waarde en probeer het opnieuw.";
                    
                    int[] checkedIDs = new int[productChangeViewModel.Products.Count];
                    for (int j = 0; j < productChangeViewModel.Products.Count; j++)
                    {
                        checkedIDs[j] = productChangeViewModel.Products[j].ID;
                        productChangeViewModel.Products[j].Amount = productContainer.Get(productChangeViewModel.Products[j].ID).Amount;
                    }
                    return View("Edit", productChangeViewModel);
                }
            }

            foreach (Product product in newProducts)
            {
                product.Update();
            }

            foreach (ProductViewModel p in invalidProducts)
            {
                productChangeViewModel.Products.Remove(p);
            }

            bool plural = productChangeViewModel.Products.Count > 1;
            string[] messages = new string[2];
            if (plural) {
                messages[0] = "Producten ";
            } else
            {
                messages[0] = "Product ";
            }

            foreach (ProductViewModel p in productChangeViewModel.Products)
            {
                messages[0] += $"'{p.Name}'";
                if (plural) messages[0] += ", ";
                else messages[0] += " ";
            }

            if (plural)
                messages[0] += "zijn succesvol aangepast!";
            else
                messages[0] += "is succesvol aangepast!";
            messages[1] = errors;
            return RedirectToAction("List", new { messages = messages });
            
            
        }

        public IActionResult List(string[] messages)
        {
            if (messages != null)
                ViewBag.Info = messages;
            else
                ViewBag.Info = new string[0];

            List<ProductViewModel> products = new List<ProductViewModel>();
            ProductContainer container = new ProductContainer(new ProductDAL());
            foreach (Product product in container.GetAll())
            {
                products.Add(ViewModelConverter.ToViewModel(product));
            }
            List<CategoryViewModel> categoryModels = new List<CategoryViewModel>();
            foreach (Category category in new CategoryContainer(new CategoryDAL()).GetAll()) {
                categoryModels.Add(ViewModelConverter.ToViewModel(category));
            }
            List<BranchViewModel> branchs = new List<BranchViewModel>();
            foreach (Branch branch in new BranchContainer(new BranchDAL()).GetAll())
            {
                branchs.Add(ViewModelConverter.ToViewModel(branch));
            }
            ViewBag.Categories = categoryModels;
            ViewBag.Branch = branchs;
            return View(products);
        }

        [HttpPost]
        public IActionResult Search (string nameToSearch, string filterCategory, string filterBranch)
        {
            if (nameToSearch == null)
            {
                nameToSearch = "";
            }


            ProductContainer container = new ProductContainer(new ProductDAL());
            List<ProductViewModel> models = new List<ProductViewModel>();
            if ((filterCategory == null || filterCategory == "Geen") && (filterBranch == null || filterBranch == "Geen"))
            {
                List<Product> products =
                    container.GetAll().FindAll(Product => Product.Name.ToLower().Contains(nameToSearch.ToLower()) || Product.Barcode.ToLower().Contains(nameToSearch.ToLower()));
                
                foreach (Product product in products)
                {
                    models.Add(ViewModelConverter.ToViewModel(product));
                }
            }
            else {
                List<Product> products = container.GetListOfProductsOnFilter(nameToSearch, filterCategory, filterBranch);
                foreach (Product product in products)
                {
                    models.Add(ViewModelConverter.ToViewModel(product));
                }
            }

            List<CategoryViewModel> categoryModels = new List<CategoryViewModel>();
            foreach (Category category in new CategoryContainer(new CategoryDAL()).GetAll())
            {
                categoryModels.Add(ViewModelConverter.ToViewModel(category));
            }

            List<BranchViewModel> branchs = new List<BranchViewModel>();
            foreach (Branch branch in new BranchContainer(new BranchDAL()).GetAll())
            {
                branchs.Add(ViewModelConverter.ToViewModel(branch));
            }
            ViewBag.Categories = categoryModels;
            ViewBag.Branch = branchs;
            ViewBag.Info = new string[0];
            ViewBag.SearchTerm = nameToSearch;
            ViewBag.Filter = filterCategory;
            ViewBag.FilterL = filterBranch;
            return View("List", models);
        }

        [HttpPost]
        public IActionResult List(int[] checkedProductIDs)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public IActionResult Delete(int[] checkedProductIDs)
        {
            string[] message = new string[1];
            if (checkedProductIDs.Length == 0)
            {
                message[0] = "Fout: Geen producten zijn verwijderd. Selecteer een product in de lijst en probeer opnieuw.";
                return RedirectToAction("Index", new { messages = message });
            }

            foreach (int id in checkedProductIDs)
            {
                foreach (Product product in new ProductContainer(new ProductDAL()).GetAll())
                {
                    if (product.ID == id)
                    {
                        product.Delete();
                    }
                }
            }

            message[0] = "Product(en) succesvol verwijderd!";
            return RedirectToAction("Index", new { messages = message });
        }

        public IActionResult SelectBranch()
        {
            List<BranchViewModel> model = new List<BranchViewModel>();
            BranchContainer container = new BranchContainer(new BranchDAL());
            List<int> branchIDWithLocations = new List<int>();
    
            foreach (Branch branch in container.GetAll())
            {
                foreach (Location location in new LocationContainer(new LocationDAL()).GetAll())
                {
                    if (location.Branch.ID == branch.ID) {
                        branchIDWithLocations.Add(branch.ID);
                    }
                }
                model.Add(ViewModelConverter.ToViewModel(branch));
            }
            ViewBag.ValidBranchIDs = branchIDWithLocations;
            return View(model);
        }
        
        public IActionResult Add(int branchId)
        {
            ProductViewModel model = ReadyAddAction(branchId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            Location location = new LocationContainer(new LocationDAL()).Get(model.Location.ID);

            Category category = new CategoryContainer(new CategoryDAL()).Get(model.Category.ID);

            Measurements measurements = new Measurements(model.Measurements.Width, model.Measurements.Length, model.Measurements.Height);

            

            if (ModelState.IsValid)
            {
                Product product = new Product(model.Name, model.Barcode, model.Amount, location, category, measurements, new ProductDAL());
                product.Save();
                string[] message = new string[1];
                message[0] = $"Product '{model.Name}' (barcode: {model.Barcode}, "
                + $"aantal: {model.Amount}, locatie: {location.LocationNumber}, " +
                $"categorie: {category.Name}, afmetingen: {measurements.Length}x{measurements.Width}x{measurements.Height}) is succesvol aangemaakt!";
                return RedirectToAction("Index", new {messages = message});
            }

            model = ReadyAddAction(model.Location.Branch.ID);
            return View(model);
        }

        private ProductViewModel ReadyAddAction(int branchId)
        {
            CategoryContainer categoryContainer = new CategoryContainer(new CategoryDAL());
            LocationContainer locationContainer = new LocationContainer(new LocationDAL());
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (Category category in categoryContainer.GetAll())
            {
                categories.Add(ViewModelConverter.ToViewModel(category));
            }
            foreach (Location location in locationContainer.GetAll())
            {
                if (location.Branch.ID == branchId)
                    locations.Add(ViewModelConverter.ToViewModel(location));
            }
            ProductViewModel model = new ProductViewModel()
            {
                Category = new CategoryViewModel(),
                Location = new LocationViewModel() { LocationNumber = "", Branch = new BranchViewModel() { ID = branchId } }

            };
            ViewBag.Categorys = categories;
            ViewBag.Locations = locations;
            return model;
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}