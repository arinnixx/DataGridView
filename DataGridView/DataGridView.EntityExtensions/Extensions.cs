using System.Runtime.CompilerServices;
using DataGridView.Entities.Models;

namespace DataGridView.EntityExtensions
{
    /// <summary>
    /// Расширение для <see cref="ProductModel"/>.
    /// </summary>
    public static class Extensions
    {
        public static decimal GetProductTotalPriceWithoutTax(this ProductModel product) =>
            product.Price * product.Quantity;

        public static decimal GetTotalPriceWithTax(this ProductModel product, decimal vatRate) =>
        product.Price * product.Quantity * vatRate;

    }
}
