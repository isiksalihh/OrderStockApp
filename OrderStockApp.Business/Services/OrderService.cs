using Microsoft.EntityFrameworkCore;
using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Models.RequestModels.OrderRequests;
using OrderStockApp.Business.Models.ResponseModels.OrderResponses;
using OrderStockApp.Core.Business;
using OrderStockApp.Data;
using OrderStockApp.Data.Entities;

namespace OrderStockApp.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderStockAppDataContext _context;
        public OrderService(OrderStockAppDataContext context)
        {
            _context = context;

        }

        public async Task<ServiceResult<List<OrderResponse>>> GetOrders()
        {
            var result = new ServiceResult<List<OrderResponse>>();

            var order = await _context.Orders.Select(x => new OrderResponse
            {
                ID = x.ID,
                OrderDate = x.OrderDate,
                OrderNumber = x.OrderNumber,
                TotalPrice = x.TotalPrice,

            }).ToListAsync();

            result.Data = order;
            return result;
        }
        public async Task<ServiceResult<OrderResponse>> GetOrder(int id)
        {
            var result = new ServiceResult<OrderResponse>();

            var order = await _context.Orders.Where(x=>x.ID == id).Select(x => new OrderResponse
            {
                ID = x.ID,
                OrderDate = x.OrderDate,
                OrderNumber = x.OrderNumber,
                TotalPrice = x.TotalPrice,

            }).FirstOrDefaultAsync();

            result.Data = order;
            return result;
        }
        public async Task<ServiceResult<OrderResponse>> Update(OrderUpdateRequest request)
        {
            var result = new ServiceResult<OrderResponse>();

            var order = await _context.Orders.Where(x => x.ID == request.ID).FirstOrDefaultAsync();

            order.OrderNumber = request.OrderNumber;
            order.OrderDate = request.OrderDate;
            order.TotalPrice = request.TotalPrice;

            _context.Update(order);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<ServiceResult<OrderCreateRequest>> Create(OrderCreateRequest request)
        {
            var result = new ServiceResult<OrderCreateRequest>();

            var order = new Order
            {
                OrderNumber = request.OrderNumber,
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            result.Data = new OrderCreateRequest
            {
                ID = order.ID,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                TotalPrice = order.TotalPrice,

            };

            return result;
        }
    }
}
