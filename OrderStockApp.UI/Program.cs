using Microsoft.EntityFrameworkCore;
using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Services;
using OrderStockApp.Data;
using OrderStockApp.UI.UI;

namespace OrderStockApp.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //LOCAL DB CONNECTION STRING
            var localDb = "DESKTOP-R855719\\SQLEXPRESS;";
            var dbName = "StockCardApp;";
            var connectionString = $"Server={localDb}Database={dbName}TrustServerCertificate=true;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<OrderStockAppDataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            OrderStockAppDataContext context = new OrderStockAppDataContext(optionsBuilder.Options);

            IStockCardService stockCardService = new StockCardService(context); 
            IOrderService orderService = new OrderService(context);
            IOrderRowService orderRowService = new OrderRowService(context);

            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new OrdersForm(stockCardService, orderRowService, orderService));
        }
    }
}