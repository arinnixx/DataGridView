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
        public int TotalProducts { get; set; }

        /// <summary>
        /// Общая сумма без НДС
        /// </summary>
        public decimal TotalAmountWithoutVat { get; set; }

        /// <summary>
        /// Общая сумма с НДС
        /// </summary>
        public decimal TotalAmountWithVat { get; set; }
    }
}
