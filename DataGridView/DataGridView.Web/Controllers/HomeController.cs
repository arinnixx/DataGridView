using System.Diagnostics;
using System.Threading;
using DataGridView.Constants;
using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridView.Web.Controllers
{
    public class HomeController(IService service) : Controller
    {
       private IService Service { get; set; } = service;

        public async Task<IActionResult> Index()
        {
            var products = await Service.GetAllProducts();
            var statistics = await Service.GetStatistics(WarehouseConstants.VatRate,CancellationToken.None);

            var viewModel = new IndexViewModel
            {
                Products = products,
                Statistics = statistics
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductEditViewModel productEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productEditViewModel);
            }

            var product = new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = productEditViewModel.ProductName,
                Size = productEditViewModel.Size,
                Material = productEditViewModel.Material,
                Quantity = productEditViewModel.Quantity,
                MinimumQuantity = productEditViewModel.MinimumQuantity,
                Price = productEditViewModel.Price
            };

            await Service.AddProduct(product, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) // Измените параметр на id
        {
            var products = await Service.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == id); // Ищем по id

            if (product == null)
            {
                return NotFound();
            }

            var productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id, // Добавьте это
                ProductName = product.ProductName,
                Size = product.Size,
                Material = product.Material,
                Quantity = product.Quantity,
                MinimumQuantity = product.MinimumQuantity,
                Price = product.Price
            };

            return View(productEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel productEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productEditViewModel);
            }

            var products = await Service.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == productEditViewModel.Id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = productEditViewModel.ProductName;
            product.Size = productEditViewModel.Size;
            product.Material = productEditViewModel.Material;
            product.Quantity = productEditViewModel.Quantity;
            product.MinimumQuantity = productEditViewModel.MinimumQuantity;
            product.Price = productEditViewModel.Price;

            await Service.UpdateProduct(product, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var products = await Service.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id) 
        {
            var products = await Service.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            await Service.DeleteProduct(product, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });

        }
    }
}
