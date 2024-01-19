using Microsoft.EntityFrameworkCore;
using OrderStockApp.Business.Interfaces;
using OrderStockApp.Business.Models.RequestModels.StockCardRequests;
using OrderStockApp.Business.Models.ResponseModels.StockCardResponses;
using OrderStockApp.Core.Business;
using OrderStockApp.Data;
using OrderStockApp.Data.Entities;

namespace OrderStockApp.Business.Services
{
    public class StockCardService : IStockCardService
    {
        private readonly OrderStockAppDataContext _context;
        public StockCardService(OrderStockAppDataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<StockCardCreateRequest>> Create(StockCardCreateRequest request)
        {
            var result = new ServiceResult<StockCardCreateRequest>();

            var isStockCardExist = _context.StockCards.Any(x => x.StockCode == request.StockCode && x.StockName == request.StockName);

            if (isStockCardExist)
            {
                result.SetError("Stok Kart bulunmaktadır.");
                return result;
            }

            var stockCard = new StockCard
            {
                StockCode = request.StockCode,
                StockName = request.StockName,
                UnitPrice = request.UnitPrice
            };

            await _context.StockCards.AddAsync(stockCard);
            await _context.SaveChangesAsync();

            result.SetSuccess("Stok Kart Eklenmiştir.");
            return result;
        }
        public async Task<ServiceResult<List<StockCardResponse>>> GetAll()
        {
            var result = new ServiceResult<List<StockCardResponse>>();

            var stockCards = await _context.StockCards.Select(x => new StockCardResponse
            {
                ID = x.ID,
                StockCode = x.StockCode,
                StockName = x.StockName,
                UnitPrice = x.UnitPrice
            }).ToListAsync();

            result.Data = stockCards;
            return result;
        }
        public async Task<ServiceResult<StockCardResponse>> GetStockByCode(string stockCode)
        {
            var result = new ServiceResult<StockCardResponse>();

            var stockCard = await _context.StockCards.FirstOrDefaultAsync(x => x.StockCode == stockCode.Trim());

            if (stockCard == null)
            {
                result.SetError("Stok Kart bulunamadı.");
                return result;
            }

            var stockCardResponse = new StockCardResponse
            {
                ID = stockCard.ID,
                StockCode = stockCard.StockCode,
                StockName = stockCard.StockName,
                UnitPrice = stockCard.UnitPrice
            };
            result.Data = stockCardResponse;
            return result;
        }
        public async Task<ServiceResult<StockCardUpdateRequest>> Update(StockCardUpdateRequest request)
        {
            var result = new ServiceResult<StockCardUpdateRequest>();

            var stockCard = await _context.StockCards.FirstOrDefaultAsync(x => x.ID == request.ID);

            var isStockCardExist = _context.StockCards.Any(x => x.StockCode == request.StockCode && x.ID != request.ID);

            if (stockCard == null)
            {
                result.SetError("Stok Kart bulunamadı.");
                return result;
            }

            if (isStockCardExist)
            {
                result.SetError("Stok Kart bulunmaktadır.");
                return result;
            }

            stockCard.StockCode = request.StockCode;
            stockCard.StockName = request.StockName;
            stockCard.UnitPrice = request.UnitPrice;

            _context.Update(stockCard);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
