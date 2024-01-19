namespace OrderStockApp.Business.Models.ResponseModels.StockCardResponses
{
    public class StockCardResponse
    {
        public int ID { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
