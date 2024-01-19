using OrderStockApp.Business.Models.RequestModels.OrderRowRequests;
using OrderStockApp.Business.Models.ResponseModels.OrderRowResponses;
using OrderStockApp.Core.Business;

namespace OrderStockApp.Business.Interfaces
{
    public interface IOrderRowService
    {
        Task<ServiceResult<List<OrderRowResponse>>> GetOrderRows(int orderID);
        Task<ServiceResult<OrderRowCreateRequest>> Create(List<OrderRowResponse> request);
    }
}
