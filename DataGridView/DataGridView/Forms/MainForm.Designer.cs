﻿namespace DataGridView.Forms
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
            statusStrip = new StatusStrip();
            toolStripStatusLabelQuantity = new ToolStripStatusLabel();
            toolStripStatusLabelAmount = new ToolStripStatusLabel();
            toolStripStatusLabelAmountVAT = new ToolStripStatusLabel();
            dataGridView = new System.Windows.Forms.DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            ProductSize = new DataGridViewTextBoxColumn();
            Material = new DataGridViewComboBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            MinQuantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { toolStripButtonAdd, toolStripButtonEdit, toolStripButtonDelete });
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
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ProductName, ProductSize, Material, Quantity, MinQuantity, Price, Amount });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 25);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(910, 511);
            dataGridView.TabIndex = 2;
            dataGridView.CellFormatting += dataGridViewProducts_CellFormatting;
            // 
            // ProductName
            // 
            ProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductName.HeaderText = "Наименование товара";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // ProductSize
            // 
            ProductSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ProductSize.HeaderText = "Размер";
            ProductSize.Name = "ProductSize";
            ProductSize.ReadOnly = true;
            // 
            // Material
            // 
            Material.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Material.HeaderText = "Материал";
            Material.Name = "Material";
            Material.ReadOnly = true;
            Material.Resizable = DataGridViewTriState.True;
            Material.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Quantity
            // 
            Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Quantity.HeaderText = "Количество на складе";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // MinQuantity
            // 
            MinQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MinQuantity.HeaderText = "Минимальный предел количества";
            MinQuantity.Name = "MinQuantity";
            MinQuantity.ReadOnly = true;
            // 
            // Price
            // 
            Price.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            Controls.Add(dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Автоматизация склада гвоздей";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridView;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripStatusLabel toolStripStatusLabelQuantity;
        private ToolStripStatusLabel toolStripStatusLabelAmount;
        private ToolStripStatusLabel toolStripStatusLabelAmountVAT;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductSize;
        private DataGridViewComboBoxColumn Material;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn MinQuantity;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Amount;
    }
}