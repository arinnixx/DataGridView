using System.Diagnostics;
using System.Threading;
using DataGridView.Constants;
using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridView.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления продуктами на складе
    /// </summary>
    public class HomeController(IService service) : Controller
    {
       private IService Service { get; set; } = service;

        /// <summary>
        /// Отображает главную страницу со списком всех продуктов и статистикой склада
        /// </summary>
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

        /// <summary>
        /// Отображает форму для создания нового продукта
        /// </summary>

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductEditViewModel());
        }

        /// <summary>
        /// Обрабатывает отправку формы создания нового продукта
        /// </summary>

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

        /// <summary>
        /// Отображает форму для редактирования существующего продукта по его идентификатору
        /// </summary>

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

        /// <summary>
        /// Обрабатывает отправку формы редактирования продукта
        /// </summary>
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

        /// <summary>
        /// Отображает страницу подтверждения удаления продукта
        /// </summary>
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

        /// <summary>
        /// Выполняет удаление продукта после подтверждения
        /// </summary>
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

        /// <summary>
        /// Отображает страницу "Политика конфиденциальности".
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о текущем запросе.
        /// </summary>
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });

        }
    }
}
