namespace OrderStockApp.Business.Models.RequestModels.StockCardRequests
{
    public class StockCardUpdateRequest
    {
        public int ID { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
