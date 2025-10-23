using System.ComponentModel.DataAnnotations;
using DataGridView.Classes;
using DataGridView.Infrastructure;
using DataGridView.Models;

namespace DataGridView.Forms
{
    public partial class AddProductForm : Form
    {
        private readonly ProductModel targetProduct;
        private readonly ErrorProvider errorProvider = new ErrorProvider();

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

            comboBoxMaterial.AddBinding(x => x.SelectedItem!, targetProduct, x => x.Material);
            textBoxProductName.AddBinding(x => x.Text, targetProduct, x => x.ProductName);
            textBoxProductSize.AddBinding(x => x.Text, targetProduct, x => x.Size);
            numericUpDownQuantity.AddBinding(x => x.Value, targetProduct, x => x.Quantity);
            numericUpDownMinQuantity.AddBinding(x => x.Value, targetProduct, x => x.MinimumQuantity);
            numericUpDownPrice.AddBinding(x => x.Value, targetProduct, x => x.Price);

            ConfigureErrorProvider();
        }

        private void ConfigureErrorProvider()
        {
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
            errorProvider.Clear();

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
                foreach (var validationResult in results)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        Control? control = memberName switch
                        {
                            nameof(ProductModel.Material) => comboBoxMaterial,
                            nameof(ProductModel.ProductName) => textBoxProductName,
                            nameof(ProductModel.Size) => textBoxProductSize,
                            nameof(ProductModel.Quantity) => numericUpDownQuantity,
                            nameof(ProductModel.MinimumQuantity) => numericUpDownMinQuantity,
                            nameof(ProductModel.Price) => numericUpDownPrice,
                            _ => null
                        };

                        if (control != null)
                        {
                            errorProvider.SetError(control, validationResult.ErrorMessage);
                        }
                    }
                }
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
