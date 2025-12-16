using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage
{
    /// <summary>
    /// Хранилище в виде базы данных
    /// </summary>
    public class WarehouseDatabaseStorage : IStorage
    {
        /// <summary>
        /// Добавление нового продукта в базу данных
        /// </summary>
        public async Task AddProduct(ProductModel product, CancellationToken cancellationToken)
        {
            using var database = new DatabaseContext();
            database.Products.Add(product);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Возвращает все гвозди из базы данных
        /// </summary>
        public async Task<IEnumerable<ProductModel>> GetAllProducts(CancellationToken cancellationToken)
        {
            using var database = new DatabaseContext();
            var products = await database.Products.AsNoTracking().ToListAsync(cancellationToken);
            return products;
        }

        /// <summary>
        /// Удаление продукта из базы данных
        /// </summary>
        public async Task DeleteProduct(ProductModel product, CancellationToken cancellationToken)
        {
            using var database = new DatabaseContext();
            database.Remove(product);
            await database.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Обновление существующего продукта в базе данных
        /// </summary>
        public async Task UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            using var database = new DatabaseContext();
            database.Products.Update(product);
            await database.SaveChangesAsync(cancellationToken);
        }
    }
}
