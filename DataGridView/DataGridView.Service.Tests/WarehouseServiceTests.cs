using DataGridView.Constants;
using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;
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

            var mockLogger = new Mock<ILogger>();
            var mockLoggerFactory = new Mock<ILoggerFactory>();
            mockLoggerFactory
                .Setup(f => f.CreateLogger(It.IsAny<string>())).
                Returns(mockLogger.Object);

            service = new WarehouseService(storageMock.Object, mockLoggerFactory.Object);
        }

        /// <summary>
        /// Проверяет, что при добавлении товара сервис вызывает метод AddProduct хранилища.
        /// </summary>
        [Fact]
        public async Task AddShouldCallStorageAdd()
        {
            // Arrange
            var product = new ProductModel();

            // Act
            await service.AddProduct(product, CancellationToken.None);

            // Assert
            storageMock.Verify(s => s.AddProduct(product, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что при удалении товара сервис вызывает метод DeleteProduct хранилища.
        /// </summary>
        [Fact]
        public async Task DeleteProductShouldDelete()
        {
            // Arrange
            var product = new ProductModel();

            // Act
            await service.DeleteProduct(product, CancellationToken.None);

            // Assert
            storageMock.Verify(s => s.DeleteProduct(product, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает данные, которые предоставляет хранилище при получении всех товаров.
        /// </summary>
        [Fact]
        public async Task GettAllProductShouldReturnAllDataFromStorage()
        {
            // Arrange
            var products = new List<ProductModel>
            {
                new ProductModel(),
                new ProductModel()
            };

            storageMock
                .Setup(s => s.GetAllProducts(CancellationToken.None))
                .ReturnsAsync(products);

            // Act
            var result = await service.GetAllProducts(CancellationToken.None);

            // Assert
            result.Should().BeSameAs(products);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет статистику на основе данных из хранилища.
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldCalculateCorrectly()
        {
            // Arrange
            var vatRate = WarehouseConstants.VatRate;
            var products = new List<ProductModel>
            {
                new ProductModel { Price = 100m, Quantity = 2 },
                new ProductModel { Price = 200m, Quantity = 3 },
                new ProductModel { Price = 300m, Quantity = 1 }
            };

            storageMock
                .Setup(s => s.GetAllProducts(CancellationToken.None))
                .ReturnsAsync(products);



            var expectedStatistics = new Statistics
            {
                TotalProducts = 3,
                TotalAmountWithoutVat = 1100m,
                TotalAmountWithVat = 1320m
            };

            // Act
            var result = await service.GetStatistics(vatRate, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.TotalProducts.Should().Be(expectedStatistics.TotalProducts);
            result.TotalAmountWithoutVat.Should().Be(expectedStatistics.TotalAmountWithoutVat);
            result.TotalAmountWithVat.Should().Be(expectedStatistics.TotalAmountWithVat);

            storageMock.Verify(s => s.GetAllProducts(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что при обновлении продукта сервис вызывает метод UpdateProduct хранилища.
        /// </summary>
        [Fact]
        public async Task UpdateProductShouldCallStorageUpdateProduct()
        {
            // Arrange
            var product = new ProductModel();

            // Act
            await service.UpdateProduct(product, CancellationToken.None);

            // Assert
            storageMock.Verify(s => s.UpdateProduct(product, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет общую стоимость товара без налогов.
        /// </summary>
        [Fact]
        public async Task GetProductTotalPriceWithoutTaxShouldCalculateCorrectly()
        {
            // Arrange
            var product = new ProductModel
            {
                Price = 100m,
                Quantity = 5
            };

            // Act
            var result = await service.GetProductTotalPriceWithoutTax(product, CancellationToken.None);

            // Assert
            result.Should().Be(500m);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает 0 при попытке расчета стоимости для null товара.
        /// </summary>
        [Fact]
        public async Task GetProductTotalPriceWithoutTaxShouldReturnZeroForNullProduct()
        {
            // Arrange
            ProductModel? product = null;

            // Act
            var result = await service.GetProductTotalPriceWithoutTax(product!, CancellationToken.None);

            // Assert
            result.Should().Be(0m);
        }
    }
}