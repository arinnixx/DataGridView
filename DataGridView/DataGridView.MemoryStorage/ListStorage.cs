using DataGridView.Entities.Models;
using DataGridView.Entities.Contracts;
using DataGridView.EntityManager;
using DataGridView.MemoryStorage.Contracts;
using System.Threading.Tasks;

namespace DataGridView.MemoryStorage
{
    /// <summary>
    /// Сервис для доступа к товарам, хранящимся в памяти
    /// </summary>
    public class ListStorage : IStorage
    {
        private readonly List<ProductModel> products;

        /// <summary>
        /// Инициализация экземпляра ListStorage
        /// </summary>
        public ListStorage()
        {
            products = []; // Пустой список
        }

        /// <inheritdoc/>
        public Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return Task.FromResult<IEnumerable<ProductModel>>(products);
        }

        Task IStorage.AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            products.Add(product);
            return Task.CompletedTask;
        }

        Task IStorage.UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return Task.CompletedTask;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Size = product.Size;
            existingProduct.Material = product.Material;
            existingProduct.Quantity = product.Quantity;
            existingProduct.MinimumQuantity = product.MinimumQuantity;
            existingProduct.Price = product.Price;

            return Task.CompletedTask;
        }

        Task IStorage.DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return Task.CompletedTask;
            }
            products.Remove(existingProduct);

            return Task.CompletedTask;
        }

        Task<decimal> IStorage.GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return Task.FromResult(0m);
            }
            var totalPrice = product.Price * product.Quantity;
            return Task.FromResult(totalPrice);
        }

        async Task<Statistics> IStorage.GetStatistics(CancellationToken cancellationToken)
        {
            var products = await GetAllProducts();
            var statistics = new Statistics
            {
                totalProducts = products.Count(),
                totalAmountWithoutVat = products.Sum(p => p.Price * p.Quantity),
                totalAmountWithVat = products.Sum(p => p.Price * WarehouseConstants.VatRate * p.Quantity)
            };
            return statistics;
        }
    }
}