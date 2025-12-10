namespace DataGridView.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip = new ToolStrip();
            toolStripButtonAdd = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDelete = new ToolStripButton();
            toolStripButtonUpdate = new ToolStripButton();
            statusStrip = new StatusStrip();
            toolStripStatusLabelQuantity = new ToolStripStatusLabel();
            toolStripStatusLabelAmount = new ToolStripStatusLabel();
            toolStripStatusLabelAmountVAT = new ToolStripStatusLabel();
            dataGridViewProducts = new System.Windows.Forms.DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            ProductSize = new DataGridViewTextBoxColumn();
            Material = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            MinQuantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete, toolStripButtonUpdate });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(910, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            toolStripButtonAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonAdd.Image = (Image)resources.GetObject("toolStripButtonAdd.Image");
            toolStripButtonAdd.ImageTransparentColor = Color.Magenta;
            toolStripButtonAdd.Name = "toolStripButtonAdd";
            toolStripButtonAdd.Size = new Size(97, 22);
            toolStripButtonAdd.Text = "Добавить товар";
            toolStripButtonAdd.Click += toolStripButtonAdd_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonEdit.Image = (Image)resources.GetObject("toolStripButtonEdit.Image");
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(99, 22);
            toolStripButtonEdit.Text = "Изменить товар";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDelete
            // 
            toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonDelete.Image = (Image)resources.GetObject("toolStripButtonDelete.Image");
            toolStripButtonDelete.ImageTransparentColor = Color.Magenta;
            toolStripButtonDelete.Name = "toolStripButtonDelete";
            toolStripButtonDelete.Size = new Size(89, 22);
            toolStripButtonDelete.Text = "Удалить товар";
            toolStripButtonDelete.Click += toolStripButtonDelete_Click;
            // 
            // toolStripButtonUpdate
            // 
            toolStripButtonUpdate.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonUpdate.Image = (Image)resources.GetObject("toolStripButtonUpdate.Image");
            toolStripButtonUpdate.ImageTransparentColor = Color.Magenta;
            toolStripButtonUpdate.Name = "toolStripButtonUpdate";
            toolStripButtonUpdate.Size = new Size(65, 22);
            toolStripButtonUpdate.Text = "Обновить";
            toolStripButtonUpdate.TextImageRelation = TextImageRelation.TextAboveImage;
            toolStripButtonUpdate.Click += toolStripButtonUpdate_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelQuantity, toolStripStatusLabelAmount, toolStripStatusLabelAmountVAT });
            statusStrip.Location = new Point(0, 536);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(910, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelQuantity
            // 
            toolStripStatusLabelQuantity.Name = "toolStripStatusLabelQuantity";
            toolStripStatusLabelQuantity.Size = new Size(0, 17);
            // 
            // toolStripStatusLabelAmount
            // 
            toolStripStatusLabelAmount.Name = "toolStripStatusLabelAmount";
            toolStripStatusLabelAmount.Size = new Size(0, 17);
            // 
            // toolStripStatusLabelAmountVAT
            // 
            toolStripStatusLabelAmountVAT.Name = "toolStripStatusLabelAmountVAT";
            toolStripStatusLabelAmountVAT.Size = new Size(0, 17);
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;
            dataGridViewProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Columns.AddRange(new DataGridViewColumn[] { ProductName, ProductSize, Material, Quantity, MinQuantity, Price, Amount });
            dataGridViewProducts.Dock = DockStyle.Fill;
            dataGridViewProducts.Location = new Point(0, 25);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.Size = new Size(910, 511);
            dataGridViewProducts.TabIndex = 2;
            dataGridViewProducts.CellFormatting += dataGridViewProducts_CellFormatting;
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "Наименование товара";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // ProductSize
            // 
            ProductSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductSize.DataPropertyName = "Size";
            ProductSize.HeaderText = "Размер";
            ProductSize.Name = "ProductSize";
            ProductSize.ReadOnly = true;
            // 
            // Material
            // 
            Material.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Material.DataPropertyName = "Material";
            Material.HeaderText = "Материал";
            Material.Name = "Material";
            Material.ReadOnly = true;
            Material.Resizable = DataGridViewTriState.True;
            // 
            // Quantity
            // 
            Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Количество на складе";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // MinQuantity
            // 
            MinQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MinQuantity.DataPropertyName = "MinimumQuantity";
            MinQuantity.HeaderText = "Минимальный предел количества";
            MinQuantity.Name = "MinQuantity";
            MinQuantity.ReadOnly = true;
            // 
            // Price
            // 
            Price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Цена (без НДС)";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Amount
            // 
            Amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Amount.HeaderText = "Общая сумма товара";
            Amount.Name = "Amount";
            Amount.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 558);
            Controls.Add(dataGridViewProducts);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автоматизация склада гвоздей";
            Load += MainForm_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripStatusLabel toolStripStatusLabelQuantity;
        private ToolStripStatusLabel toolStripStatusLabelAmount;
        private ToolStripStatusLabel toolStripStatusLabelAmountVAT;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductSize;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn MinQuantity;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Amount;
        private ToolStripButton toolStripButtonUpdate;
    }
}