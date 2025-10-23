using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Classes
{
    internal class WarehouseConstants
    {
        /// <summary>
        /// Ставка НДС
        /// </summary>
        public const decimal VatRate = 0.20m;

        // Константы для ProductModel

        /// <summary>
        /// Минимальная длина наименования товара
        /// </summary>
        public const int ProductNameMinLength = 2;

        /// <summary>
        /// Максимальная длина наименования товара
        /// </summary>
        public const int ProductNameMaxLength = 100;

        /// <summary>
        /// Минимальная длина размера
        /// </summary>
        public const int SizeMinLength = 1;

        /// <summary>
        /// Максимальная длина размера
        /// </summary>
        public const int SizeMaxLength = 50;

        /// <summary>
        /// Минимальное количество
        /// </summary>
        public const int QuantityMin = 0;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        public const decimal PriceMin = 0.01m;
    }
}
