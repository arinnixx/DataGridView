using System.Diagnostics;
using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис управления складом гвоздей
    /// </summary>
    public class WarehouseService : IService
    {
        private readonly IStorage storage;
        private readonly ILogger logger;

        public WarehouseService(IStorage storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger(nameof(WarehouseService));
        }

        /// <summary>
        /// Добавляет новый продукт на склад
        /// </summary>
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                storage.AddProduct(product, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("WarehouseService.AddProduct выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаляет продукт со склада
        /// </summary>
        public Task DeleteProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                storage.DeleteProduct(product, cancellationToken);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("WarehouseService.DeleteProduct выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
           
            return Task.CompletedTask;
        }

        /// <summary>
        /// Получает все продукты со склада
        /// </summary>
        public async Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var allProducts = await storage.GetAllProducts(cancellationToken);
                return allProducts;
            }
            finally
            { 
                sw.Stop();
                logger.LogDebug("WarehouseService.GetAllProducts выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Рассчитывает статистику по складу с учетом НДС
        /// </summary>
        public async Task<Statistics> GetStatistics(decimal vatRate, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var products = await storage.GetAllProducts(cancellationToken);

                var totalProducts = products.Count();
                var totalAmountWithoutVat = products.Sum(p => p.Price * p.Quantity);
                var totalAmountWithVat = products.Sum(p => p.Price * vatRate * p.Quantity);

                var statistics = new Statistics
                {
                    TotalProducts = totalProducts,
                    TotalAmountWithoutVat = totalAmountWithoutVat,
                    TotalAmountWithVat = totalAmountWithVat

                };
                return statistics;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("WarehouseService.GetStatistics выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Обновляет информацию о продукте
        /// </summary>
        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                storage.UpdateProduct(product, cancellationToken);
                return Task.CompletedTask;
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("WarehouseService.UpdateProduct выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Рассчитывает общую стоимость продукта без учета налогов
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(ProductModel product, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                if (product == null)
                {
                    return Task.FromResult(0m);
                }
                var totalPrice = product.Price * product.Quantity;
                return Task.FromResult(totalPrice);
            }
            finally
            {
                sw.Stop();
                logger.LogDebug("WarehouseService.GetProductTotalPriceWithoutTax выполнен за {ElapsedMilliseconds} мс", sw.ElapsedMilliseconds);
            }
        }
    }
}
