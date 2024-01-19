using OrderStockApp.Business.Models.RequestModels.StockCardRequests;
using OrderStockApp.Business.Models.ResponseModels.StockCardResponses;
using OrderStockApp.Core.Business;

namespace OrderStockApp.Business.Interfaces
{
    public interface IStockCardService
    {
        Task<ServiceResult<List<StockCardResponse>>> GetAll();
        Task<ServiceResult<StockCardResponse>> GetStockByCode(string stockCode);
        Task<ServiceResult<StockCardCreateRequest>> Create(StockCardCreateRequest request);
        Task<ServiceResult<StockCardUpdateRequest>> Update(StockCardUpdateRequest request);
    }
}
