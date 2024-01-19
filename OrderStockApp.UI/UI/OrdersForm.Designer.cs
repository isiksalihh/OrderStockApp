namespace OrderStockApp.UI.UI
{
    partial class OrdersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            OrderRowListButton = new Button();
            StockCardListFormButton = new Button();
            orderDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).BeginInit();
            SuspendLayout();
            // 
            // OrderRowListButton
            // 
            OrderRowListButton.Location = new Point(12, 12);
            OrderRowListButton.Name = "OrderRowListButton";
            OrderRowListButton.Size = new Size(121, 29);
            OrderRowListButton.TabIndex = 0;
            OrderRowListButton.Text = "Yeni Sipariş Ekle";
            OrderRowListButton.UseVisualStyleBackColor = true;
            OrderRowListButton.Click += OrderRowListButton_Click;
            // 
            // StockCardListFormButton
            // 
            StockCardListFormButton.Location = new Point(188, 12);
            StockCardListFormButton.Name = "StockCardListFormButton";
            StockCardListFormButton.Size = new Size(121, 29);
            StockCardListFormButton.TabIndex = 1;
            StockCardListFormButton.Text = "Stok Kart Listesi";
            StockCardListFormButton.UseVisualStyleBackColor = true;
            StockCardListFormButton.Click += StockCardListFormButton_Click;
            // 
            // orderDataGrid
            // 
            orderDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGrid.Location = new Point(12, 71);
            orderDataGrid.Name = "orderDataGrid";
            orderDataGrid.ReadOnly = true;
            orderDataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            orderDataGrid.Size = new Size(297, 433);
            orderDataGrid.TabIndex = 2;
            orderDataGrid.CellContentClick += orderDataGrid_CellContentClick;
            // 
            // OrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 516);
            Controls.Add(orderDataGrid);
            Controls.Add(StockCardListFormButton);
            Controls.Add(OrderRowListButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OrdersForm";
            Text = "Sipariş Kayıtları";
            Load += OrdersForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button OrderRowListButton;
        private Button StockCardListFormButton;
        private DataGridView orderDataGrid;
    }
}