using Inventory.Data.Models;
using Inventory.Repository.Interfaces;
using KoalaInventoryManagement.ViewModels.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace KoalaInventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Await the asynchronous calls to retrieve data
            var productsDB = _unitOfWork.Products.GetAll();
            var suppliersDB = await _unitOfWork.Suppliers.GetAllAsync();
            var categoriesDB = await _unitOfWork.Categories.GetAllAsync();
            var WareHouseDB = _unitOfWork.WareHouses.GetAll(); // Assuming this is also async

            // Create the view model
            ProductsTotalViewModel viewModel = new ProductsTotalViewModel
            {
                products = productsDB.Select(product => new ProductsViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CurrentStock = product.CurrentStock,
                    MinimumStock = product.MinimumStock,
                    MaximumStock = product.MaximumStock,

                }).ToList(),

                suppliers = suppliersDB.Select(supplier => new SupplierViewModel
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                }).ToList(),

                categories = categoriesDB.Select(category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToList(),
                warehouse = WareHouseDB.Select(warehouse => new WareHouseViewModel
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Getview()
        {
            
            return View("index");
        }

        [HttpGet]
        public IActionResult Search()
        {
            var searchTerm = "Palestine Flag".ToLower(); // Convert the search term to lowercase
            var ProductName = _unitOfWork.Products.FindByName(
                a => a.Name.ToLower().Contains(searchTerm),
                null
            );
            return Ok(ProductName);
        }

        
        [HttpPost]
        public IActionResult AddProduct(string Name, string Description, double Price, int Current_Stock, int Minimum_Stock, int Maximum_Stock, int Supplier, int Category)
        {
            // Create a new product instance
            var newProduct = new Models.Product
            {
                Name = Name,
                Description = Description,
                Price = Price,
                CurrentStock = Current_Stock, 
                MinimumStock = Minimum_Stock, 
                MaximumStock = Maximum_Stock, 
                SupplierId = Supplier, 
                CategoryId = Category, 
                CreateAt = DateTime.Now
            };

            // Add the new product to the database
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Complete();


            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
           
             _unitOfWork.Products.Delete(id);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProduct()
        {
            var UpdateProduct = _unitOfWork.Products.Update(new Models.Product { Id = 5, Name = "salama2", Description = "Test salama2", Price = 50});
            _unitOfWork.Complete();
            return Ok(UpdateProduct);
        }

        [HttpGet]
        public IActionResult GetAllProductSupplier()
        {
            var products= _unitOfWork.Products.GetProductsBySupplier(1);
            return Ok(products);
        }
        [HttpGet]
        public IActionResult GetAllProductCategory()
        {
            var products = _unitOfWork.Products.GetProductsByCategory(1);
            return Ok(products);
        }
    }
}
