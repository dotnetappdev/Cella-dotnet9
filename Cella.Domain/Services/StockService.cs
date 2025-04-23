using Cella.Domain.Interfaces;
using Cella.Infrastructure;
using Cella.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Domain.Services
{
    public class StockService : IStockInterface
    {
        private readonly ApplicationDbContext _dBContext;

        public StockService(ApplicationDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public ServiceResponse<string> PostStockItem(StockItemVm stockItemVm)
        {
            try
            {
                // Map ViewModel to Entity
                var stockItem = new StockItem
                {
                    Id = stockItemVm.Id ?? 0,
                    Description = stockItemVm.Description,
                    StockCode = stockItemVm.StockCode,
                    BarCode = stockItemVm.BarCode,
                    ShortDescription = stockItemVm.ShortDescription,
                    DefaultPrice = stockItemVm.Price,
                    Name = stockItemVm.Name,
                    FullDescription = stockItemVm.FullDescription,
                    Categories = stockItemVm.Categories,
                    Manufactures = stockItemVm.Manufactures,
                    AvailableStartDate = stockItemVm.AvailableStartDate,
                    AvailableEndDate = stockItemVm.AvailableEndDate,
                    isShowCallButton = stockItemVm.isShowCallButton ?? false,
                    isNew = stockItemVm.isNew ?? false,
                    isShowOnHomePage = stockItemVm.isShowOnHomePage ?? false,
                    StockItemType = stockItemVm.StockItemType,
                    isShowPrice = stockItemVm.isShowPrice ?? false,
                    canAddToCart = stockItemVm.canAddToCart ?? false,
                    isPublished = stockItemVm.isPublished ?? false,
                    PriceList = stockItemVm.PriceList,
                    PriceListType = stockItemVm.PriceListType,
                    SKU = stockItemVm.SKU,
                    isFeatured = stockItemVm.isFeatured ?? false,
                    isBackOrder = stockItemVm.isBackOrder ?? false,
                    CreateDate = stockItemVm.CreateDate,
                    LastModifiedDate = stockItemVm.LastModifiedDate,
                    CreatedBy = stockItemVm.CreatedBy,
                    UpdatedBy = stockItemVm.UpdatedBy,
                    isActive = stockItemVm.isActive ?? false,
                    isDeleted = stockItemVm.isDeleted ?? false
                };

                _dBContext.StockItems.Add(stockItem);
                _dBContext.SaveChanges();

                return ServiceResponse<string>.Create(
                    data: null,
                    message: "Stock item created successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "An error occurred while creating the stock item.",
                    exception: ex,
                    errorCode: (int?)HttpStatusCode.BadRequest
                );
            }
        }

        public ServiceResponse<string> PutStockItem(StockItemVm stockItemVm)
        {
            try
            {
                var stockItem = new StockItem
                {
                    Id = stockItemVm.Id ?? 0,
                    Description = stockItemVm.Description,
                    StockCode = stockItemVm.StockCode,
                    BarCode = stockItemVm.BarCode,
                    ShortDescription = stockItemVm.ShortDescription,
                    DefaultPrice = stockItemVm.Price,
                    Name = stockItemVm.Name,
                    FullDescription = stockItemVm.FullDescription,
                    Categories = stockItemVm.Categories,
                    Manufactures = stockItemVm.Manufactures,
                    AvailableStartDate = stockItemVm.AvailableStartDate,
                    AvailableEndDate = stockItemVm.AvailableEndDate,
                    isShowCallButton = stockItemVm.isShowCallButton ?? false,
                    isNew = stockItemVm.isNew ?? false,
                    isShowOnHomePage = stockItemVm.isShowOnHomePage ?? false,
                    StockItemType = stockItemVm.StockItemType,
                    isShowPrice = stockItemVm.isShowPrice ?? false,
                    canAddToCart = stockItemVm.canAddToCart ?? false,
                    isPublished = stockItemVm.isPublished ?? false,
                    PriceList = stockItemVm.PriceList,
                    PriceListType = stockItemVm.PriceListType,
                    SKU = stockItemVm.SKU,
                    isFeatured = stockItemVm.isFeatured ?? false,
                    isBackOrder = stockItemVm.isBackOrder ?? false,
                    CreateDate = stockItemVm.CreateDate,
                    LastModifiedDate = stockItemVm.LastModifiedDate,
                    CreatedBy = stockItemVm.CreatedBy,
                    UpdatedBy = stockItemVm.UpdatedBy,
                    isActive = stockItemVm.isActive ?? false,
                    isDeleted = stockItemVm.isDeleted ?? false
                };

                _dBContext.Attach(stockItem);
                _dBContext.Entry(stockItem).State = EntityState.Modified;
                _dBContext.SaveChanges();

                return ServiceResponse<string>.Create(
                    message: "Stock item updated successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "Failed to update stock item.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<string>> Delete(int stockId)
        {
            try
            {
                var record = await _dBContext.StockItems.FindAsync(stockId);
                if (record == null)
                {
                    return ServiceResponse<string>.Create(
                        message: "Stock item not found.",
                        errorCode: (int?)HttpStatusCode.BadRequest
                        );
                }

                _dBContext.StockItems.Remove(record);
                await _dBContext.SaveChangesAsync();

                return ServiceResponse<string>.Create(
                    message: "Stock item deleted successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<string>.Create(
                    message: "Failed to delete stock item.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

        public async Task<ServiceResponse<IEnumerable<StockItem>>> GetAll()
        {
            try
            {
                var stockItems = await _dBContext.StockItems.ToListAsync();

                return ServiceResponse<IEnumerable<StockItem>>.Create(
                    data: stockItems,
                    message: "Stock items retrieved successfully.",
                    errorCode: (int?)HttpStatusCode.OK
                );
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<StockItem>>.Create(
                    message: "Failed to retrieve stock items.",
                    errorCode: (int?)HttpStatusCode.BadRequest,
                    exception: ex
                );
            }
        }

    }
}
