namespace DataGridView.EntityManager
{
    /// <summary>
    /// Класс для хранения статистики
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// Всего товаров на складе
        /// </summary>
        public int totalProducts { get; set; }

        /// <summary>
        /// Общая сумма без НДС
        /// </summary>
        public decimal totalAmountWithoutVat { get; set; }

        /// <summary>
        /// Общая сумма с НДС
        /// </summary>
        public decimal totalAmountWithVat { get; set; }
    }
}
