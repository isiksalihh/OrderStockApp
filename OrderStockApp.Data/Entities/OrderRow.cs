using System.ComponentModel.DataAnnotations.Schema;

namespace OrderStockApp.Data.Entities
{
    [Table("OrderRow")]
    public class OrderRow
    {
        public int ID { get; set; }
        public int OrderQueue { get; set; }
        public int StockCardID { get; set; }
        public virtual StockCard StockCard { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public decimal PriceTotal { get; set;}
    }
}
