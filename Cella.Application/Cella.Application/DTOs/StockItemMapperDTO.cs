using Cella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cella.Application.DTOs
{
    public  class StockItemMapperDTO
    {
        private StockItem MapToStockItem(StockItemVm vm)
        {
            return new StockItem
            {
                Id = vm.Id ?? 0,
                Description = vm.Description,
                StockCode = vm.StockCode,
                BarCode = vm.BarCode,
                ShortDescription = vm.ShortDescription,
                DefaultPrice = vm.Price,
                Name = vm.Name,
                FullDescription = vm.FullDescription,
                Categories = vm.Categories,
                Manufactures = vm.Manufactures,
                AvailableStartDate = vm.AvailableStartDate,
                AvailableEndDate = vm.AvailableEndDate,
                isShowCallButton = vm.isShowCallButton ?? false,
                isNew = vm.isNew ?? false,
                isShowOnHomePage = vm.isShowOnHomePage ?? false,
                StockItemType = vm.StockItemType,
                isShowPrice = vm.isShowPrice ?? false,
                canAddToCart = vm.canAddToCart ?? false,
                isPublished = vm.isPublished ?? false,
                PriceList = vm.PriceList,
                PriceListType = vm.PriceListType,
                SKU = vm.SKU,
                isFeatured = vm.isFeatured ?? false,
                isBackOrder = vm.isBackOrder ?? false,
                CreateDate = vm.CreateDate,
                LastModifiedDate = vm.LastModifiedDate,
                CreatedBy = vm.CreatedBy,
                UpdatedBy = vm.UpdatedBy,
                isActive = vm.isActive ?? false,
                isDeleted = vm.isDeleted ?? false
            };
        }

    }
}
