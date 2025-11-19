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
        public Task AddProduct(ProductModel product);

        /// <summary>
        /// Обновить товар
        /// </summary>
        public Task UpdateProduct(ProductModel product);

        /// <summary>
        /// Удалить товар по ID
        /// </summary>
        public Task DeleteProduct(Guid id);

        /// <summary>
        /// Найти товар по ID
        /// </summary>
        public Task<ProductModel?> GetProductById(Guid id);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        public Task<decimal> GetProductTotalPriceWithoutTax(Guid id);

        /// <summary>
        /// Получить статистику по продуктам на складе
        /// </summary>
        public Task<Statistics> GetStatistics();

    }
}
