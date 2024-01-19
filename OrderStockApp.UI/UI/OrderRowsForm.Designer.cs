namespace OrderStockApp.UI.UI
{
    partial class OrderRowsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderRowsForm));
            groupBox1 = new GroupBox();
            AddNewRowButton = new Button();
            OrderDatePicker = new DateTimePicker();
            OrderRowNumberTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            OrderRowDataGrid = new DataGridView();
            groupBox2 = new GroupBox();
            TotalPriceLabel = new Label();
            label3 = new Label();
            SaveButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderRowDataGrid).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AddNewRowButton);
            groupBox1.Controls.Add(OrderDatePicker);
            groupBox1.Controls.Add(OrderRowNumberTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(838, 116);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sipariş Temel Bilgileri";
            // 
            // AddNewRowButton
            // 
            AddNewRowButton.Location = new Point(700, 77);
            AddNewRowButton.Name = "AddNewRowButton";
            AddNewRowButton.Size = new Size(123, 23);
            AddNewRowButton.TabIndex = 4;
            AddNewRowButton.Text = "Yeni Satır Ekle";
            AddNewRowButton.UseVisualStyleBackColor = true;
            AddNewRowButton.Click += AddNewRowButton_Click;
            // 
            // OrderDatePicker
            // 
            OrderDatePicker.Location = new Point(66, 71);
            OrderDatePicker.Name = "OrderDatePicker";
            OrderDatePicker.Size = new Size(205, 23);
            OrderDatePicker.TabIndex = 3;
            // 
            // OrderRowNumberTextBox
            // 
            OrderRowNumberTextBox.Location = new Point(66, 33);
            OrderRowNumberTextBox.Name = "OrderRowNumberTextBox";
            OrderRowNumberTextBox.Size = new Size(205, 23);
            OrderRowNumberTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 77);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 1;
            label2.Text = "Tarih";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Evrak No";
            // 
            // OrderRowDataGrid
            // 
            OrderRowDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderRowDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            OrderRowDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderRowDataGrid.Location = new Point(12, 134);
            OrderRowDataGrid.Name = "OrderRowDataGrid";
            OrderRowDataGrid.Size = new Size(838, 271);
            OrderRowDataGrid.TabIndex = 1;
            OrderRowDataGrid.CellValueChanged += OrderRowDataGrid_CellValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TotalPriceLabel);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(18, 411);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(196, 67);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sipariş Bilgileri";
            // 
            // TotalPriceLabel
            // 
            TotalPriceLabel.AutoSize = true;
            TotalPriceLabel.Location = new Point(101, 32);
            TotalPriceLabel.Name = "TotalPriceLabel";
            TotalPriceLabel.Size = new Size(0, 15);
            TotalPriceLabel.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 0;
            label3.Text = "Toplam Fiyat:";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(722, 445);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(128, 33);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Kaydet";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // OrderRowsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 490);
            Controls.Add(SaveButton);
            Controls.Add(groupBox2);
            Controls.Add(OrderRowDataGrid);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OrderRowsForm";
            Text = "Sipariş Girişi";
            Load += OrderRowsForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)OrderRowDataGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button AddNewRowButton;
        private DateTimePicker OrderDatePicker;
        private TextBox OrderRowNumberTextBox;
        private Label label2;
        private Label label1;
        private DataGridView OrderRowDataGrid;
        private GroupBox groupBox2;
        private Label TotalPriceLabel;
        private Label label3;
        private Button SaveButton;
    }
}