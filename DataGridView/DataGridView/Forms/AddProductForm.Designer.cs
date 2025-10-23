namespace DataGridView.Forms
{
    partial class AddProductForm
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
            textBoxProductName = new TextBox();
            textBoxProductSize = new TextBox();
            comboBoxMaterial = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            numericUpDownMinQuantity = new NumericUpDown();
            numericUpDownPrice = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(215, 36);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(224, 23);
            textBoxProductName.TabIndex = 0;
            // 
            // textBoxProductSize
            // 
            textBoxProductSize.Location = new Point(215, 93);
            textBoxProductSize.Name = "textBoxProductSize";
            textBoxProductSize.Size = new Size(224, 23);
            textBoxProductSize.TabIndex = 1;
            // 
            // comboBoxMaterial
            // 
            comboBoxMaterial.FormattingEnabled = true;
            comboBoxMaterial.Location = new Point(215, 151);
            comboBoxMaterial.Name = "comboBoxMaterial";
            comboBoxMaterial.Size = new Size(224, 23);
            comboBoxMaterial.TabIndex = 2;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(215, 209);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(224, 23);
            numericUpDownQuantity.TabIndex = 3;
            // 
            // numericUpDownMinQuantity
            // 
            numericUpDownMinQuantity.Location = new Point(215, 258);
            numericUpDownMinQuantity.Name = "numericUpDownMinQuantity";
            numericUpDownMinQuantity.Size = new Size(224, 23);
            numericUpDownMinQuantity.TabIndex = 4;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Location = new Point(215, 310);
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(224, 23);
            numericUpDownPrice.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 39);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 6;
            label1.Text = "Наименование товара";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 101);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 7;
            label2.Text = "Размер";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(147, 154);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 8;
            label3.Text = "Материал";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 211);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 9;
            label4.Text = "Количество на складе";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 260);
            label5.Name = "label5";
            label5.Size = new Size(198, 15);
            label5.TabIndex = 10;
            label5.Text = "Минимальный предел количества";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(174, 312);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 11;
            label6.Text = "Цена";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(79, 380);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(109, 23);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(277, 380);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(109, 23);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 445);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDownPrice);
            Controls.Add(numericUpDownMinQuantity);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxMaterial);
            Controls.Add(textBoxProductSize);
            Controls.Add(textBoxProductName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Товар";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMinQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxProductName;
        private TextBox textBoxProductSize;
        private ComboBox comboBoxMaterial;
        private NumericUpDown numericUpDownQuantity;
        private NumericUpDown numericUpDownMinQuantity;
        private NumericUpDown numericUpDownPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonSave;
        private Button buttonCancel;
    }
}