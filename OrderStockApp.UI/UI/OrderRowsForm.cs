using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Models.RequestModels.OrderRequests;
using OrderStockApp.Business.Models.ResponseModels.OrderRowResponses;
using OrderStockApp.Core.Business;

namespace OrderStockApp.UI.UI
{
    public partial class OrderRowsForm : Form
    {
        private readonly IOrderRowService _orderRowService;
        private readonly IOrderService _orderService;
        private readonly IStockCardService _stockCardService;
        private List<OrderRowResponse> _orderRows;
        private OrdersForm _ordersForm;
        private int _receivedOrderID;
        public OrderRowsForm(IOrderRowService orderRowService, IStockCardService stockCardService, IOrderService orderService, int id, OrdersForm ordersForm)
        {
            _orderService = orderService;
            _stockCardService = stockCardService;
            _orderRowService = orderRowService;
            _receivedOrderID = id;
            _ordersForm = ordersForm;
            InitializeComponent();

        }

        private async void OrderRowsForm_Load(object sender, EventArgs e)
        {
            var recordsOfOrder = await GetOrderRowsAndDetails();
            _orderRows = recordsOfOrder.Data;
        }



        private async Task<ServiceResult<List<OrderRowResponse>>> GetOrderRowsAndDetails()
        {
            var result = new ServiceResult<List<OrderRowResponse>>();

            if (_receivedOrderID != 0)
            {
                var orderRowList = await _orderRowService.GetOrderRows(_receivedOrderID);
                var order = await _orderService.GetOrder(_receivedOrderID);

                if (!order.IsSuccess)
                {
                    MessageBox.Show("Sipariş bilgileri getirilirken hata oluştu");
                    return result;

                }
                OrderDatePicker.Value = order.Data.OrderDate;
                OrderRowNumberTextBox.Text = order.Data.OrderNumber.Trim();

                if (!orderRowList.IsSuccess)
                {
                    MessageBox.Show("Sipariş satırları getirilirken hata oluştu");
                    return result;
                }

                TotalPriceLabel.Text = orderRowList.Data.Sum(x => x.TotalPrice).ToString();
                OrderRowDataGrid.DataSource = orderRowList.Data;
                SetGridProperties();

                result.Data = orderRowList.Data;
            }
            return result;
        }

        private async void OrderRowDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var currentRow = e.RowIndex;
            var columnName = OrderRowDataGrid.Columns[e.ColumnIndex].Name;

            var stockCodeColumn = OrderRowDataGrid.Rows[currentRow].Cells["StockCode"].Value;
            var stockCardIDColumn = OrderRowDataGrid.Rows[currentRow].Cells["StockCardID"].Value;
            var stockNameColumn = OrderRowDataGrid.Rows[currentRow].Cells["StockName"].Value;
            var quantityColumn = OrderRowDataGrid.Rows[currentRow].Cells["Quantity"].Value;
            var unitPriceColumn = OrderRowDataGrid.Rows[currentRow].Cells["UnitPrice"].Value;
            var totalPriceColumn = OrderRowDataGrid.Rows[currentRow].Cells["TotalPrice"].Value;

            if (currentRow >= 0)
            {
                if (columnName == "StockCode")
                {
                    var result = await _stockCardService.GetStockByCode(stockCodeColumn.ToString());
                    if (!result.IsSuccess)
                    {
                        MessageBox.Show("Stok bulunamadi");
                        return;
                    }

                    stockCardIDColumn = result.Data.ID;
                    stockNameColumn = result.Data.StockName;
                    unitPriceColumn = result.Data.UnitPrice;
                }

                if (columnName == "Quantity")
                {
                    var quantity = Convert.ToDecimal(quantityColumn);
                    if (quantity <= 0)
                    {
                        MessageBox.Show("Lütfen geçerli bir miktar giriniz");
                        return;
                    }

                    var unitPrice = Convert.ToDecimal(unitPriceColumn);
                    totalPriceColumn = unitPrice * quantity;
                    TotalPriceLabel.Text = _orderRows.Sum(x => x.TotalPrice).ToString();
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satır seçiniz");
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {

            if (_orderRows == null || _orderRows.Count() <= 0)
            {
                MessageBox.Show("Lütfen sipariş satırları ekleyiniz");
                return;
            }
            if (string.IsNullOrEmpty(OrderRowNumberTextBox.Text))
            {
                MessageBox.Show("Lütfen evrak numarası giriniz");
                return;
            }
            if (_receivedOrderID == 0)
            {
                var newOrder = new OrderCreateRequest
                {
                    OrderDate = OrderDatePicker.Value,
                    OrderNumber = OrderRowNumberTextBox.Text.Trim(),
                    TotalPrice = _orderRows.Sum(x => x.TotalPrice),
                };
                var createOrderRequest = await _orderService.Create(newOrder);
                _receivedOrderID = createOrderRequest.Data.ID;

                _orderRows.ForEach(orderRow => orderRow.OrderID = _receivedOrderID);
                var createOrderRowRequest = await _orderRowService.Create(_orderRows);

                if (!createOrderRowRequest.IsSuccess || !createOrderRequest.IsSuccess)
                {
                    MessageBox.Show("Sipariş satırları kaydedilirken hata oluştu");
                    return;
                }
                else
                {
                    if (_ordersForm != null && !_ordersForm.IsDisposed)
                    {
                        await _ordersForm.GetOrders();
                    }
                    MessageBox.Show("Sipariş satırları başarılı bir şekilde kayıt edildi");
                }
            }
            else
            {
                var updatedOrder = new OrderUpdateRequest
                {
                    ID = _receivedOrderID,
                    OrderDate = OrderDatePicker.Value,
                    OrderNumber = OrderRowNumberTextBox.Text.Trim(),
                    TotalPrice = _orderRows.Sum(x => x.TotalPrice)
                };

                _orderRows.ForEach(orderRow => orderRow.OrderID = _receivedOrderID);

                var createAndUpdateOrderRequest = await _orderService.Update(updatedOrder);
                var createOrderRequest = await _orderRowService.Create(_orderRows);
                if (!createAndUpdateOrderRequest.IsSuccess || !createOrderRequest.IsSuccess)
                {
                    MessageBox.Show("Sipariş satırları kaydedilirken hata oluştu");
                    return;
                }
                else
                {
                    if (_ordersForm != null && !_ordersForm.IsDisposed)
                    {
                        await _ordersForm.GetOrders();
                    }
                    MessageBox.Show("Sipariş satırları başarılı bir şekilde kayıt edildi");
                }
            }
        }


        private void AddNewRowButton_Click(object sender, EventArgs e)
        {
            CreateEmptyRow();

            OrderRowDataGrid.DataSource = null;
            if (_orderRows.Count > 0)
                OrderRowDataGrid.DataSource = _orderRows;
            SetGridProperties();
        }

        private OrderRowResponse CreateEmptyRow()
        {
            _orderRows = _orderRows == null ? new List<OrderRowResponse>() : _orderRows;

            var rowCount = _orderRows.Count();

            rowCount = rowCount == 0 || rowCount == null ? 0 : rowCount;

            var emptyRow = new OrderRowResponse
            {
                ID = 0,
                OrderQueue = rowCount + 1,
                StockCode = "",
                StockName = "",
                Quantity = 0,
                TotalPrice = 0,
                UnitPrice = 0,
                StockCardID = 0,
                OrderID = _receivedOrderID
            };

            _orderRows.Add(emptyRow);

            return emptyRow;
        }
        private void SetGridProperties()
        {
            OrderRowDataGrid.Columns["ID"].Visible = false;
            OrderRowDataGrid.Columns["OrderID"].Visible = false;
            OrderRowDataGrid.Columns["StockCardID"].Visible = false;
            OrderRowDataGrid.Columns["OrderQueue"].ReadOnly = true;
            OrderRowDataGrid.Columns["StockName"].ReadOnly = true;
            OrderRowDataGrid.Columns["UnitPrice"].ReadOnly = true;
            OrderRowDataGrid.Columns["TotalPrice"].ReadOnly = true;
        }


    }
}
