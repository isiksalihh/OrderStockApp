using OrderStockApp.Business.Models.RequestModels.OrderRequests;
using OrderStockApp.Business.Models.ResponseModels.OrderResponses;
using OrderStockApp.Core.Business;

namespace OrderStockApp.Business.Interfaces
{
    public interface IOrderService
    {
        Task<ServiceResult<List<OrderResponse>>> GetOrders();
        Task<ServiceResult<OrderResponse>> GetOrder(int id);
        Task<ServiceResult<OrderResponse>> Update(OrderUpdateRequest request);
        Task<ServiceResult<OrderCreateRequest>> Create(OrderCreateRequest request);
    }
}
