using DataGridView.EntityManager;
using DataGridView.Entities.Models;

namespace DataGridView.MemoryStorage.Contracts
{
    /// <summary>
    /// Методы для операций с хранилищем
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<ProductModel>> GetAllProducts();

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        public Task AddProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public Task DeleteProduct(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить статистику по продуктам на складе
        /// </summary>
        public Task<Statistics> GetStatistics(decimal vatRate, CancellationToken cancellationToken);

    }
}
