using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Models.RequestModels.StockCardRequests;
using OrderStockApp.Business.Models.ResponseModels.StockCardResponses;
using OrderStockApp.Core.Business;

namespace OrderStockApp.UI
{
    public partial class StockCardsForm : Form
    {
        private readonly IStockCardService _stockCardService;
        public StockCardsForm(IStockCardService stockCardService)
        {
            InitializeComponent();
            _stockCardService = stockCardService;

        }
        private async void StockCardsForm_Load(object sender, EventArgs e)
        {

            await RefreshStockCardList();
        }

        private void stockListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = stockListBox.IndexFromPoint(e.Location);
                if (index == ListBox.NoMatches)
                {
                    stockListBox.ClearSelected();
                }
            }
        }

        private async void stockListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (stockListBox.SelectedIndex == -1)
            {
                stockCodeTextBox.Text = string.Empty;
                stockNameTextBox.Text = string.Empty;
                stockPriceNumericUpDown.Value = 0;
            }
            else
            {
                var stockCard = (StockCardResponse)stockListBox.SelectedItem;

                if (stockCard != null)
                {
                    stockCodeTextBox.Text = stockCard.StockCode;
                    stockNameTextBox.Text = stockCard.StockName;
                    stockPriceNumericUpDown.Value = stockCard.UnitPrice;
                }
                else
                {
                    MessageBox.Show("Failed to retrieve stock information.");
                }
            }
        }
        private async void addStockCardButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stockCodeTextBox.Text) || string.IsNullOrEmpty(stockNameTextBox.Text))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurunuz.");
                return;
            }

            var stockCode = stockCodeTextBox.Text;
            var stockCardName = stockNameTextBox.Text;
            var unitPrice = stockPriceNumericUpDown.Value;

            if (stockListBox.SelectedIndex == -1)
            {

                var stockCard = new StockCardCreateRequest
                {
                    StockCode = stockCode,
                    StockName = stockCardName,
                    UnitPrice = unitPrice
                };

                var result = await _stockCardService.Create(stockCard);

                if (result.IsSuccess)
                {
                    MessageBox.Show("Stok kartý baþarýyla eklendi.");
                    await RefreshStockCardList();
                }
                else
                {
                    MessageBox.Show("Stok kartý eklenirken bir hata oluþtu.");
                }
            }
            else
            {
                var selectedStockCard = (StockCardResponse)stockListBox.SelectedItem;

                var stockCard = new StockCardUpdateRequest
                {
                    ID = selectedStockCard.ID,
                    StockCode = stockCode,
                    StockName = stockCardName,
                    UnitPrice = unitPrice
                };

                var result = await _stockCardService.Update(stockCard);

                if (result.IsSuccess)
                {
                    MessageBox.Show("Stok kartý baþarýyla güncellendi.");
                    await RefreshStockCardList();
                }
                else
                {
                    MessageBox.Show("Stok kartý güncellenirken bir hata oluþtu.");
                }
            }
        }
        private async Task<ServiceResult<List<StockCardResponse>>> RefreshStockCardList()
        {
            var result = new ServiceResult<List<StockCardResponse>>();
            var stockCardRecords = await _stockCardService.GetAll();

            stockListBox.DataSource = stockCardRecords.Data;
            stockListBox.DisplayMember = "StockName";
            stockListBox.ClearSelected();
            result.Data = stockCardRecords.Data;
            return result;
        }
    }
}
