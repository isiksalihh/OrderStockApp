using System.ComponentModel.DataAnnotations.Schema;

namespace OrderStockApp.Data.Entities
{
    [Table("Order")]
    public class Order
    {
        public int ID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
