using DataGridView.Entities.Models;

namespace DataGridView.MemoryStorage.Contracts
{
    /// <summary>
    /// Интерфейс хранилища
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить товар
        /// </summary>
        public Task DeleteProduct(ProductModel product, CancellationToken cancellationToken);

    }
}
