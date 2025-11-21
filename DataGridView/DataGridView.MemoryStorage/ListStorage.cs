using DataGridView.Entities.Models;
using DataGridView.Entities.Contracts;
using DataGridView.EntityManager;
using DataGridView.MemoryStorage.Contracts;

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
            products =
            [
                new ProductModel
                {
                
                ProductName = "Гвоздь строительный",
                Size = "100мм",
                Material = MaterialType.Steel,
                Quantity = 1000,
                MinimumQuantity = 100,
                Price = 2.50m
                },

                new ProductModel
                {
                
                ProductName = "Гвоздь декоративный",
                Size = "50мм",
                Material = MaterialType.Copper,
                Quantity = 500,
                MinimumQuantity = 50,
                Price = 5.75m
                },

                new ProductModel
                {
                
                ProductName = "Гвоздь кровельный",
                Size = "75мм",
                Material = MaterialType.Chrome,
                Quantity = 300,
                MinimumQuantity = 30,
                Price = 8.20m
                }
            ];
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ProductModel>> GetAllProducts() => await Task.FromResult<IEnumerable<ProductModel>>(products);

        async Task IStorage.AddProduct(ProductModel product)
        {
            products.Add(product);
            await Task.CompletedTask;
        }

        async Task IStorage.UpdateProduct(ProductModel product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Size = product.Size;
            existingProduct.Material = product.Material;
            existingProduct.Quantity = product.Quantity;
            existingProduct.MinimumQuantity = product.MinimumQuantity;
            existingProduct.Price = product.Price;

            await Task.CompletedTask;
        }

        async Task IStorage.DeleteProduct(Guid id)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return;
            }
            products.Remove(existingProduct);

            await Task.CompletedTask;
        }

        async Task<ProductModel?> IStorage.GetProductById(Guid id) => await Task.FromResult(products.FirstOrDefault(p => p.Id == id));

        async Task<decimal> IStorage.GetProductTotalPriceWithoutTax(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return 0;
            }
            var totalPrice = product.Price * product.Quantity;
            return await Task.FromResult(totalPrice);
        }

        async Task<Statistics> IStorage.GetStatistics()
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
