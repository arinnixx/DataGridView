using DataGridView.Entities.Models;
using DataGridView.MemoryStorage.Contracts;

namespace DataGridView.Forms
{
    /// <summary>
    /// Главная форма приложения для управления складом гвоздей
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly List<ProductModel> items;
        private readonly IStorage storage;
        private readonly BindingSource bindingSource = [];

        /// <summary>
        /// Инициализирует новый экземпляр главной формы приложения
        /// </summary>
        public MainForm(IStorage storage)
        {
            InitializeComponent();
            this.storage = storage;
            dataGridViewProducts.AutoGenerateColumns = false;

            items = new List<ProductModel>();

            items.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвоздь строительный",
                Size = "100мм",
                Material = MaterialType.Steel,
                Quantity = 1000,
                MinimumQuantity = 100,
                Price = 2.50m
            });

            items.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвоздь декоративный",
                Size = "50мм",
                Material = MaterialType.Copper,
                Quantity = 500,
                MinimumQuantity = 50,
                Price = 5.75m
            });

            items.Add(new ProductModel
            {
                Id = Guid.NewGuid(),
                ProductName = "Гвоздь кровельный",
                Size = "75мм",
                Material = MaterialType.Chrome,
                Quantity = 300,
                MinimumQuantity = 30,
                Price = 8.20m
            });
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
        private async void dataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewProducts.Columns[e.ColumnIndex];
            var product = (ProductModel)dataGridViewProducts.Rows[e.RowIndex].DataBoundItem;

            if (product == null)
            {
                return;
            }


            if (col.DataPropertyName == nameof(ProductModel.Material))
            {
                e.Value = product.Material switch
                {
                    Entities.Models.MaterialType.Copper => "Медь",
                    Entities.Models.MaterialType.Steel => "Сталь",
                    Entities.Models.MaterialType.Iron => "Железо",
                    Entities.Models.MaterialType.Chrome => "Хром",
                    _ => string.Empty,
                };
            }
            if (col == Amount)
            {
                var totalAmount = await storage.GetProductTotalPriceWithoutTax(product.Id, CancellationToken.None);
                e.Value = totalAmount.ToString("C2");

            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить товар
        /// </summary>
        private async void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddProductForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                await storage.AddProduct(addForm.CurrentProduct, CancellationToken.None);
                await OnUpdate();
            }
        }

        /// <summary>
        /// Метод обновления статистики
        /// </summary>
        private async Task SetStatistic()
        {
            var statistics = await storage.GetStatistics(CancellationToken.None);
            toolStripStatusLabelQuantity.Text = $"Товарных позиций: {statistics.totalProducts}";
            toolStripStatusLabelAmount.Text = $"Общая сумма без НДС: {statistics.totalAmountWithoutVat:C2}";
            toolStripStatusLabelAmountVAT.Text = $"Общая сумма с НДС: {statistics.totalAmountWithVat:C2}";
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать товар
        /// </summary>
        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                return;
            }

            var selectedProduct = (ProductModel)dataGridViewProducts.SelectedRows[0].DataBoundItem;

            var editForm = new AddProductForm(selectedProduct);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await storage.UpdateProduct(editForm.CurrentProduct, CancellationToken.None);
                await OnUpdate();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                return;
            }

            var product = (ProductModel)dataGridViewProducts.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Вы действительно желаете удалить товар '{product.ProductName}'?",
                "Удаление товара",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await storage.DeleteProduct(product.Id, CancellationToken.None);
                await OnUpdate();
            }
        }

        /// <summary>
        /// Метод обновления всех данных на форме
        /// </summary>
        public async Task OnUpdate()
        {
            var products = await storage.GetAllProducts();
            bindingSource.DataSource = products.ToList();
            bindingSource.ResetBindings(false);
            await SetStatistic();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            var products = await storage.GetAllProducts();
            bindingSource.DataSource = products.ToList();
            dataGridViewProducts.DataSource = bindingSource;
            await SetStatistic();
        }
    }
}
