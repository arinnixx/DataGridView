using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;


namespace DataGridView.Services.Contracts
{
    /// <summary>
    /// Интерфейс для сервиса склада
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken);

        /// <summary>
        /// Добавить новый товар
        /// </summary>
        Task AddProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить товар
        /// </summary>
        Task UpdateProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить товар
        /// </summary>
        Task DeleteProduct(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Получить общую стоимость товара БЕЗ НДС (Цена * Количество)
        /// </summary>
        Task<decimal> GetProductTotalPriceWithoutTax(ProductModel product, CancellationToken cancellationToken);

        /// <summary>
        /// Получить статистику по продуктам на складе
        /// </summary>
        Task<Statistics> GetStatistics(decimal vatRate, CancellationToken cancellationToken);
    }
}
