namespace OrderStockApp.UI
{
    partial class StockCardsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockCardsForm));
            stockListBox = new ListBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox1 = new GroupBox();
            stockPriceNumericUpDown = new NumericUpDown();
            stockNameTextBox = new TextBox();
            addStockCardButton = new Button();
            label3 = new Label();
            label2 = new Label();
            stockCodeTextBox = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stockPriceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // stockListBox
            // 
            stockListBox.FormattingEnabled = true;
            stockListBox.ItemHeight = 15;
            stockListBox.Location = new Point(24, 24);
            stockListBox.Name = "stockListBox";
            stockListBox.Size = new Size(171, 364);
            stockListBox.TabIndex = 0;
            stockListBox.SelectedIndexChanged += stockListBox_SelectedIndexChanged;
            stockListBox.MouseDown += stockListBox_MouseDown;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stockPriceNumericUpDown);
            groupBox1.Controls.Add(stockNameTextBox);
            groupBox1.Controls.Add(addStockCardButton);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(stockCodeTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(228, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 271);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stok Kart Bilgileri";
            // 
            // stockPriceNumericUpDown
            // 
            stockPriceNumericUpDown.Location = new Point(15, 169);
            stockPriceNumericUpDown.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            stockPriceNumericUpDown.Name = "stockPriceNumericUpDown";
            stockPriceNumericUpDown.Size = new Size(168, 23);
            stockPriceNumericUpDown.TabIndex = 6;
            // 
            // stockNameTextBox
            // 
            stockNameTextBox.Location = new Point(15, 105);
            stockNameTextBox.Name = "stockNameTextBox";
            stockNameTextBox.Size = new Size(168, 23);
            stockNameTextBox.TabIndex = 5;
            // 
            // addStockCardButton
            // 
            addStockCardButton.Location = new Point(15, 218);
            addStockCardButton.Name = "addStockCardButton";
            addStockCardButton.Size = new Size(168, 37);
            addStockCardButton.TabIndex = 4;
            addStockCardButton.Text = "Kaydet";
            addStockCardButton.UseVisualStyleBackColor = true;
            addStockCardButton.Click += addStockCardButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 151);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 3;
            label3.Text = "Birim Fiyat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 87);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Stok Adı";
            // 
            // stockCodeTextBox
            // 
            stockCodeTextBox.Location = new Point(15, 46);
            stockCodeTextBox.Name = "stockCodeTextBox";
            stockCodeTextBox.Size = new Size(168, 23);
            stockCodeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 28);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Stok Kodu";
            // 
            // StockCardsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 419);
            Controls.Add(groupBox1);
            Controls.Add(stockListBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StockCardsForm";
            Text = "Stok Kayıt Ekranı";
            Load += StockCardsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stockPriceNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox stockListBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private GroupBox groupBox1;
        private NumericUpDown stockPriceNumericUpDown;
        private TextBox stockNameTextBox;
        private Button addStockCardButton;
        private Label label3;
        private Label label2;
        private TextBox stockCodeTextBox;
        private Label label1;
    }
}
