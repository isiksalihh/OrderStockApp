using OrderStockApp.Business.Interfaces;

namespace OrderStockApp.UI.UI
{
    public partial class OrdersForm : Form
    {
        private readonly IStockCardService _stockCardService;
        private readonly IOrderRowService _orderRowService;
        private readonly IOrderService _orderService;
        private OrdersForm _ordersForm;

        public OrdersForm(IStockCardService stockCardService, IOrderRowService orderRowService, IOrderService orderService)
        {
            _stockCardService = stockCardService;
            _orderRowService = orderRowService;
            _orderService = orderService;
            InitializeComponent();
            this._ordersForm = this;

        }
        private void StockCardListFormButton_Click(object sender, EventArgs e)
        {
            StockCardsForm stockCardsForm = new StockCardsForm(_stockCardService);
            stockCardsForm.Show();
        }

        private void OrderRowListButton_Click(object sender, EventArgs e)
        {
            OrderRowsForm orderRowsForm = new OrderRowsForm(_orderRowService, _stockCardService, _orderService, 0, _ordersForm);
            orderRowsForm.Show();
        }

        private async void OrdersForm_Load(object sender, EventArgs e)
        {
            await GetOrders();
        }
        public async Task GetOrders()
        {
            var result = await _orderService.GetOrders();

            if (result.IsSuccess)
            {
                orderDataGrid.DataSource = null;
                if (result.Data.Count > 0)
                {
                    orderDataGrid.DataSource = result.Data;
                    orderDataGrid.Columns["ID"].Visible = false;
                }

            }
        }

        private void orderDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedID = Convert.ToInt32(orderDataGrid.Rows[e.RowIndex].Cells["ID"].Value);

                OrderRowsForm otherForm = new OrderRowsForm(_orderRowService, _stockCardService, _orderService, selectedID, _ordersForm);
                otherForm.Show();
            }
        }
    }
}
