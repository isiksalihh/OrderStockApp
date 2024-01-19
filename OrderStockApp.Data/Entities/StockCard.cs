using System.ComponentModel.DataAnnotations.Schema;

namespace OrderStockApp.Data.Entities
{
    [Table("StockCard")]
    public class StockCard
    {

        public int ID { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
