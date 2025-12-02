using DataGridView.Constants;
using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using FluentAssertions;
using Moq;

namespace DataGridView.Service.Tests
{
    /// <summary>
    /// Модульные тесты для проверки работы <see cref="WarehouseService"/>.
    /// </summary>
    public class WarehouseServiceTests
    {
        private readonly Mock<IStorage> storageMock;
        private readonly IService service;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WarehouseServiceTests"/>.
        /// </summary>
        public WarehouseServiceTests() 
        { 
            storageMock = new Mock<IStorage>();
            service = new WarehouseService(storageMock.Object);
        }

        /// <summary>
        /// Тест на проверку вызова метода AddProduct при добавлении товара
        /// </summary>
        [Fact]
        public async Task AddShouldCallStorageAdd()
        {
            var product = new ProductModel();

            await service.AddProduct(product,CancellationToken.None);

            storageMock.Verify(s=> s.AddProduct(product, CancellationToken.None),Times.Once);
        }

        /// <summary>
        /// Проверяет, что при удалении товара сервис вызывает метод DeleteProduct хранилища.
        /// </summary>
        [Fact]
        public async Task DeleteProductShouldDelete()
        {
            var product = new ProductModel();

            await service.DeleteProduct(product,CancellationToken.None);

            storageMock.Verify(s=> s.DeleteProduct(product, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает данные, которые предоставляет хранилище при получении всех товаров.
        /// </summary>
        [Fact]
        public async Task GettAllProductShouldReturnAllDataFromStorage()
        {
            var products = new List<ProductModel>
            {
                new ProductModel(),
                new ProductModel()
            };

            storageMock
                .Setup(s => s.GetAllProducts())
                .ReturnsAsync(products);

            var result = await service.GetAllProducts();

            result.Should().BeSameAs(products);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает статистику, предоставленную хранилищем.
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldReturnDataFromStorage()
        {
            var vatRate = WarehouseConstants.VatRate;
            var expectedStatistics = new Statistics
            {
                TotalProducts = 3,
                TotalAmountWithoutVat = 7835m,
                TotalAmountWithVat = 7835m * vatRate
            };

            storageMock
                .Setup(s => s.GetStatistics(vatRate, CancellationToken.None))
                .ReturnsAsync(expectedStatistics);

            var result = await service.GetStatistics(vatRate, CancellationToken.None);

            result.Should().BeSameAs(expectedStatistics);
        }

        /// <summary>
        /// Проверяет, что при обновлении продукта сервис вызывает метод UpdateProduct хранилища.
        /// </summary>
        [Fact]
        public async Task UpdateProductShouldCallStorageUpdateProduct()
        {
            var product = new ProductModel();

            await service.UpdateProduct(product, CancellationToken.None);

            storageMock.Verify(s => s.UpdateProduct(product, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет общую стоимость товара без налогов.
        /// </summary>
        [Fact]
        public async Task GetProductTotalPriceWithoutTaxShouldCalculateCorrectly()
        {
            var product = new ProductModel
            {
                Price = 100m,
                Quantity = 5
            };

            var result = await service.GetProductTotalPriceWithoutTax(product, CancellationToken.None);

            result.Should().Be(500m);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает 0 при попытке расчета стоимости для null товара.
        /// </summary>
        [Fact]
        public async Task GetProductTotalPriceWithoutTaxShouldReturnZeroForNullProduct()
        {
            ProductModel? product = null;

            var result = await service.GetProductTotalPriceWithoutTax(product!, CancellationToken.None);

            result.Should().Be(0m);
        }
    }
}