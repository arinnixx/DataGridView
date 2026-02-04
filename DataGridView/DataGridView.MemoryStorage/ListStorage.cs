using DataGridView.Entities.Models;
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
            products = []; 
        }

        /// <inheritdoc/>
        public Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken)
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

        Task IStorage.DeleteProduct(ProductModel product, CancellationToken cancellationToken)
        {
            products.Remove(product);
            return Task.CompletedTask;
        }

    }
}