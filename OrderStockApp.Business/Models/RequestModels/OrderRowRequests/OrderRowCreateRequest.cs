namespace OrderStockApp.Business.Models.RequestModels.OrderRowRequests
{
    public class OrderRowCreateRequest
    {
        public int OrderQueue { get; set; }
        public int StockCardID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}
