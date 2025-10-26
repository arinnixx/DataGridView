using System.ComponentModel.DataAnnotations;
using DataGridView.Classes;
using DataGridView.Infrastructure;
using DataGridView.Models;

namespace DataGridView.Forms
{
    /// <summary>
    /// Форма для добавления или редактирования товара на складе
    /// </summary>
    public partial class AddProductForm : Form
    {
        private readonly ProductModel targetProduct;
        private readonly ErrorProvider errorProvider = new ErrorProvider();

        /// <summary>
        /// Инициализирует новый экземпляр формы для добавления или редактирования товара
        /// </summary>
        public AddProductForm(ProductModel? sourceProduct = null)
        {
            InitializeComponent();

            if (sourceProduct != null)
            {
                targetProduct = sourceProduct.Clone();
                buttonSave.Text = "Сохранить";
                Text = "Редактирование товара";
            }
            else
            {
                targetProduct = new ProductModel();
                buttonSave.Text = "Добавить";
                Text = "Добавить товар";
            }

            comboBoxMaterial.DataSource = Enum.GetValues(typeof(MaterialType));

            comboBoxMaterial.AddBinding(x => x.SelectedItem!, targetProduct, x => x.Material, errorProvider);
            textBoxProductName.AddBinding(x => x.Text, targetProduct, x => x.ProductName, errorProvider);
            textBoxProductSize.AddBinding(x => x.Text, targetProduct, x => x.Size, errorProvider);
            numericUpDownQuantity.AddBinding(x => x.Value, targetProduct, x => x.Quantity, errorProvider);
            numericUpDownMinQuantity.AddBinding(x => x.Value, targetProduct, x => x.MinimumQuantity, errorProvider);
            numericUpDownPrice.AddBinding(x => x.Value, targetProduct, x => x.Price, errorProvider);

            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;
        }


        /// <summary>
        /// Текущий товар
        /// </summary>
        public ProductModel CurrentProduct => targetProduct;

        /// <summary>
        /// Метод обработки клика кнопки "Добавить" или "Сохранить"
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var context = new ValidationContext(targetProduct);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(targetProduct, context, results, true);

            if (isValid)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, исправьте ошибки в форме перед сохранением.",
               "Ошибки валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
