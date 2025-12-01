using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.Services.Contracts;

namespace DataGridView.Services
{
    public class WarehouseService(IStorage storage) : IService
    {
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            storage.AddProduct(product, cancellationToken);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(ProductModel product, CancellationToken cancellationToken)
        {
            storage.DeleteProduct(product, cancellationToken);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var allProducts = await storage.GetAllProducts();
            return allProducts;
        }

        public async Task<Statistics> GetStatistics(decimal vatRate, CancellationToken cancellationToken)
        {
            var statistics = await storage.GetStatistics(vatRate, cancellationToken);
            return statistics;
        }

        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            storage.UpdateProduct(product, cancellationToken);
            return Task.CompletedTask;
        }

        public Task<decimal> GetProductTotalPriceWithoutTax(ProductModel product, CancellationToken cancellationToken)
        {
            if (product == null)
            {
                return Task.FromResult(0m);
            }
            var totalPrice = product.Price * product.Quantity;
            return Task.FromResult(totalPrice);
        }




    }
}
