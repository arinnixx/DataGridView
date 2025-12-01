using System.Diagnostics;
using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.Services.Contracts;
using Serilog;

namespace DataGridView.Services
{
    public class WarehouseService(IStorage storage) : IService
    {
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
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.AddProduct выполнен за {ms:F6} мс", ms);
            }
            return Task.CompletedTask;
        }

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
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.DeleteProduct выполнен за {ms:F6} мс", ms);
            }
           
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var allProducts = await storage.GetAllProducts();
                return allProducts;
            }
            finally
            { 
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.GetAllProducts выполнен за {ms:F6} мс", ms);
            }
        }

        public async Task<Statistics> GetStatistics(decimal vatRate, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                var statistics = await storage.GetStatistics(vatRate, cancellationToken);
                return statistics;
            }
            finally
            {
                sw.Stop();
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.GetStatistics выполнен за {ms:F6} мс", ms);
            }
        }

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
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.UpdateProduct выполнен за {ms:F6} мс", ms);
            }
        }

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
                double ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                Log.Debug("WarehouseService.GetProductTotalPriceWithoutTax выполнен за {ms:F6} мс", ms);
            }
        }
    }
}
