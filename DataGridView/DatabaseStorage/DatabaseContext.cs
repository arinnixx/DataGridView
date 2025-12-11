using DataGridView.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="ProductModel"/>
        /// </summary>
        public DbSet<ProductModel> Products { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="ProductModel"/>
        /// </summary>
        public DatabaseContext() => Database.EnsureCreated();

        /// <summary>
        /// Конфигурация подключения к базе данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=WarehouseDatabase;Trusted_Connection=True;");

        /// <summary>
        /// Конфигурация модели данных
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                // Настройка первичного ключа
                entity.HasKey(e => e.Id);

                // Настройка свойства Id
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                // Настройка названия продукта
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                // Настройка размера
                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(50);

                // Настройка перечисления Material
                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasConversion<int>();

                // Настройка числовых свойств
                entity.Property(e => e.Quantity)
                    .IsRequired();

                // Настройка минимальных числовых свойств
                entity.Property(e => e.MinimumQuantity)
                    .IsRequired();

                // Настройка денежных свойств
                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                // Добавление индексов для часто используемых полей
                entity.HasIndex(e => e.ProductName);
                entity.HasIndex(e => e.Material);
                entity.HasIndex(e => e.Quantity);
            });
        }

    }
}
