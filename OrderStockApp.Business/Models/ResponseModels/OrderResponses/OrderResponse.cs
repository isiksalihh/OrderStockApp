using System.ComponentModel;

namespace OrderStockApp.Business.Models.ResponseModels.OrderResponses
{
    public class OrderResponse
    {
        
        public int ID { get; set; }
        [DisplayName("Evrak Numarası")]
        public string OrderNumber { get; set; }
        [DisplayName("Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Toplam Tutar")]
        public decimal TotalPrice { get; set; }
    }
}
