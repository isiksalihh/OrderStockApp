namespace OrderStockApp.Business.Models.RequestModels.StockCardRequests
{
    public class StockCardCreateRequest
    {
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
