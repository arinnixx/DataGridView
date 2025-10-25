using System.ComponentModel.DataAnnotations;
using DataGridView.Classes;

namespace DataGridView.Models
{
    /// <summary>
    /// Модель товара (гвозди)
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Наименование товара
        /// </summary>
        [Display(Name = "Наименование товара")]
        [Required(ErrorMessage = "{0} обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} должно быть от {2} до {1} символов")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Размер
        /// </summary>
        [Display(Name = "Размер")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} должен быть от {2} до {1} символов")]
        public string Size { get; set; } = string.Empty;

        /// <summary>
        /// Материал
        /// </summary>
        [Display(Name = "Материал")]
        [Required(ErrorMessage = "{0} обязателен для выбора")]
        [Range(1, 4, ErrorMessage = "{0} должен быть выбран из списка")]
        public MaterialType Material { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        [Display(Name = "Количество на складе")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} должно быть не менее {1}")]
        public int Quantity { get; set; }

        /// <summary>
        /// Минимальный предел количества
        /// </summary>
        [Display(Name = "Минимальный предел количества")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} должно быть не менее {1}")]
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Цена (без НДС)
        /// </summary>
        [Display(Name = "Цена (без НДС)")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} должна быть больше {1}")]
        public decimal Price { get; set; }

        /// <summary>
        /// Общая сумма товара
        /// </summary>
        [Display(Name = "Общая сумма товара")]
        public decimal TotalAmount => Price * Quantity;

        /// <summary>
        /// Создает копию объекта ProductModel
        /// </summary>
        public ProductModel Clone()
        {
            return new ProductModel
            {
                Id = this.Id,
                ProductName = this.ProductName,
                Size = this.Size,
                Material = this.Material,
                Quantity = this.Quantity,
                MinimumQuantity = this.MinimumQuantity,
                Price = this.Price
            };
        }
    }
}
