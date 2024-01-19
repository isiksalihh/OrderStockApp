using Microsoft.EntityFrameworkCore;
using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Models.RequestModels.OrderRowRequests;
using OrderStockApp.Business.Models.ResponseModels.OrderRowResponses;
using OrderStockApp.Core.Business;
using OrderStockApp.Data;
using OrderStockApp.Data.Entities;

namespace OrderStockApp.Business.Services
{
    public class OrderRowService : IOrderRowService
    {
        private readonly OrderStockAppDataContext _context;
        public OrderRowService(OrderStockAppDataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<OrderRowCreateRequest>> Create(List<OrderRowResponse> request)
        {
            var result = new ServiceResult<OrderRowCreateRequest>();

            foreach (var item in request)
            {

                var existingOrderRow = await _context.OrderRows
                     .Where(x => x.OrderID == item.OrderID && x.StockCardID == item.StockCardID && x.Quantity == item.Quantity)
                     .FirstOrDefaultAsync();

                var findStockCard = await _context.StockCards
                    .Where(x => x.StockCode == item.StockCode)
                    .FirstOrDefaultAsync();

                if (findStockCard == null)
                {
                    result.SetError("Stok kartı bulunamadı");
                    return result;
                }


                if (existingOrderRow != null)
                {
                    existingOrderRow.Quantity = item.Quantity;
                    existingOrderRow.OrderQueue = item.OrderQueue;
                    existingOrderRow.PriceTotal = item.TotalPrice;
                    existingOrderRow.StockCardID = findStockCard.ID;
                    _context.OrderRows.Update(existingOrderRow);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var orderRow = new OrderRow
                    {
                        OrderID = item.OrderID,
                        StockCardID = findStockCard.ID,
                        Quantity = item.Quantity,
                        OrderQueue = item.OrderQueue,
                        PriceTotal = item.TotalPrice,
                    };

                    await _context.OrderRows.AddAsync(orderRow);
                    await _context.SaveChangesAsync();
                }
            }




            return result;
        }
        public async Task<ServiceResult<List<OrderRowResponse>>> GetOrderRows(int orderID)
        {
            var result = new ServiceResult<List<OrderRowResponse>>();

            var orderRows = await _context.OrderRows
                .Where(x => x.OrderID == orderID)
                .ToListAsync();

            if (!orderRows.Any())
            {
                result.SetError("Sipariş satırları bulunamadı");
                return result;
            }

            var orderRowResponses = new List<OrderRowResponse>();

            foreach (var orderRow in orderRows)
            {
                var stockCardID = _context.StockCards
                    .Where(x => x.ID == orderRow.StockCardID)
                    .FirstOrDefault();

                var orderRowResponse = new OrderRowResponse
                {
                    ID = orderRow.ID,
                    OrderQueue = orderRow.OrderQueue,
                    StockName = stockCardID.StockName,
                    StockCode = stockCardID.StockCode,
                    UnitPrice = stockCardID.UnitPrice,
                    StockCardID = stockCardID.ID,
                    OrderID = orderRow.OrderID,
                    Quantity = orderRow.Quantity,
                    TotalPrice = Convert.ToDecimal(orderRow.Quantity) * orderRow.StockCard.UnitPrice
                };

                orderRowResponses.Add(orderRowResponse);
            }

            result.Data = orderRowResponses;
            return result;

        }
    }
}
