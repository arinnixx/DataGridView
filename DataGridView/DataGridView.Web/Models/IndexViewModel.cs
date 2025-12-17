using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Коллекция товаров для отображения на странице
        /// </summary>
        public IEnumerable<ProductModel> Products { get; set; } = Enumerable.Empty<ProductModel>();

        /// <summary>
        /// Объект статистики, содержащий агрегированные данные по товарам
        /// </summary>
        public Statistics Statistics { get; set; } = new();
    }
}
