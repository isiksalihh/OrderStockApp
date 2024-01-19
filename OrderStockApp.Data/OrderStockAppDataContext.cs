using Microsoft.EntityFrameworkCore;
using OrderStockApp.Data.Entities;

namespace OrderStockApp.Data
{
    public class OrderStockAppDataContext : DbContext
    {
        public OrderStockAppDataContext(DbContextOptions<OrderStockAppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<StockCard> StockCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}
