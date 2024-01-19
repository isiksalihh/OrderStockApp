namespace OrderStockApp.Business.Models.RequestModels.OrderRequests
{
    public class OrderUpdateRequest
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderRowID { get; set; }
    }
}
