using DataGridView.Classes;
using DataGridView.Models;

namespace DataGridView.Forms
{
    public partial class MainForm : Form
    {
        private readonly List<ProductModel> items;
        private readonly BindingSource bindingSource = new();

        public MainForm()
        {
            InitializeComponent();

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

            SetStatistic();

            ProductName.DataPropertyName = nameof(ProductModel.ProductName);
            ProductSize.DataPropertyName = nameof(ProductModel.Size);
            Material.DataPropertyName = nameof(ProductModel.Material);
            Quantity.DataPropertyName = nameof(ProductModel.Quantity);
            MinQuantity.DataPropertyName = nameof(ProductModel.MinimumQuantity);
            Price.DataPropertyName = nameof(ProductModel.Price);
            Amount.DataPropertyName = nameof(ProductModel.TotalAmount);

            dataGridView.AutoGenerateColumns = false;
            Material.DataSource = Enum.GetValues(typeof(MaterialType));

            bindingSource.DataSource = items;
            dataGridView.DataSource = bindingSource;
        }

        /// <summary>
        /// Обработчик события форматирования ячеек DataGridView
        /// </summary>
        private void dataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView.Columns[e.ColumnIndex];
            var product = (ProductModel)dataGridView.Rows[e.RowIndex].DataBoundItem;

            if (product == null)
                return;

            if (col.DataPropertyName == nameof(ProductModel.Material))
            {
                e.Value = product.Material switch
                {
                    MaterialType.Copper => "Медь",
                    MaterialType.Steel => "Сталь",
                    MaterialType.Iron => "Железо",
                    MaterialType.Chrome => "Хром",
                    _ => "Не выбрано"
                };
            }
            else if (col.DataPropertyName == nameof(ProductModel.Price) ||
                     col.DataPropertyName == nameof(ProductModel.TotalAmount))
            {
                if (e.Value is decimal value)
                {
                    e.Value = value.ToString("C2");
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Добавить товар
        /// </summary>
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddProductForm();

            if (addForm.ShowDialog(this) == DialogResult.OK)
            {
                items.Add(addForm.CurrentProduct);
                bindingSource.ResetBindings(false);
                MessageBox.Show("Товар успешно добавлен!");
                OnUpdate();
            }
        }

        /// <summary>
        /// Метод обновления статистики
        /// </summary>
        private void SetStatistic()
        {
            var totalProducts = items.Count;
            var totalAmountWithoutVat = items.Sum(p => p.TotalAmount);
            var totalAmountWithVat = totalAmountWithoutVat * (1 + WarehouseConstants.VatRate);

            toolStripStatusLabelQuantity.Text = $"Товарных позиций: {totalProducts}";
            toolStripStatusLabelAmount.Text = $"Общая сумма без НДС: {totalAmountWithoutVat:C2}";
            toolStripStatusLabelAmountVAT.Text = $"Общая сумма с НДС: {totalAmountWithVat:C2}";
        }

        /// <summary>
        /// Обработчик нажатия кнопки Редактировать товар
        /// </summary>
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для редактирования!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProduct = (ProductModel)dataGridView.SelectedRows[0].DataBoundItem;
            var selectedIndex = items.IndexOf(selectedProduct);

            var editForm = new AddProductForm(selectedProduct);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                if (selectedIndex >= 0 && selectedIndex < items.Count)
                {
                    items[selectedIndex] = editForm.CurrentProduct;
                    OnUpdate();
                    MessageBox.Show("Товар успешно обновлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Удалить товар
        /// </summary>
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления!", "Внимание",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = (ProductModel)dataGridView.SelectedRows[0].DataBoundItem;
            var target = items.FirstOrDefault(x => x.Id == product.Id);

            if (target != null &&
                MessageBox.Show($"Вы действительно желаете удалить товар '{target.ProductName}'?",
                "Удаление товара",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                items.Remove(target);
                OnUpdate();
            }
        }

        /// <summary>
        /// Метод обновления всех данных на форме
        /// </summary>
        public void OnUpdate()
        {
            bindingSource.ResetBindings(false);
            dataGridView.Refresh();
            SetStatistic();
        }
    }
}
