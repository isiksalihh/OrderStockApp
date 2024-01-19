using System.ComponentModel;

namespace OrderStockApp.Business.Models.ResponseModels.OrderRowResponses
{
    public class OrderRowResponse
    {
        public int ID { get; set; }
        [DisplayName("Sipariş Sırası")]
        public int OrderQueue { get; set; }
        [DisplayName("Stok Adı")]
        public string StockName { get; set; }
        [DisplayName("Stok Kodu")]
        public string StockCode { get; set; }
        [DisplayName("Birim Fiyatı")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Miktar")]
        public int Quantity { get; set; }
        [DisplayName("Ara Toplam")]
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public int StockCardID { get; set; }
    }
}
