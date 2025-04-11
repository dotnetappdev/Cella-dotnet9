using Cella.Application;
using Cella.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;


namespace Cella.Maui.ViewModels
    {
        public partial class StockViewModel : ObservableObject
        {
            private readonly ApiService _apiService;

            public StockViewModel()
            {
                _apiService = new ApiService();
                SaveCommand = new Command(async () => await SaveStockItemAsync());
            }

            // Command to trigger save operation
            public ICommand SaveCommand { get; }

            // Properties with the [ObservableProperty] attribute
            [ObservableProperty] private int? _id;
            [ObservableProperty] private string? _description;
            [ObservableProperty] private string? _stockCode;
            [ObservableProperty] private string? _barCode;
            [ObservableProperty] private string? _shortDescription;
            [ObservableProperty] private string? _price;
            [ObservableProperty] private string? _name;
            [ObservableProperty] private string? _fullDescription;
            [ObservableProperty] private int? _categories;
            [ObservableProperty] private string? _manufactures;
            [ObservableProperty] private DateTime? _availableStartDate;
            [ObservableProperty] private DateTime? _availableEndDate;
            [ObservableProperty] private bool _isShowCallButton;
            [ObservableProperty] private bool _isNew;
            [ObservableProperty] private bool? _isShowOnHomePage;
            [ObservableProperty] private int? _stockItemType;
            [ObservableProperty] private bool? _isShowPrice;
            [ObservableProperty] private bool? _canAddToCart;
            [ObservableProperty] private bool? _isPublished;
            [ObservableProperty] private decimal? _defaultPrice;
            [ObservableProperty] private int? _priceList;
            [ObservableProperty] private int? _priceListType;
            [ObservableProperty] private string? _sku;
            [ObservableProperty] private bool? _isFeatured;
            [ObservableProperty] private bool? _isBackOrder;
            [ObservableProperty] private DateTime? _createDate;
            [ObservableProperty] private DateTime? _lastModifiedDate;
            [ObservableProperty]  private string? _createdBy;
            [ObservableProperty] private string? _updatedBy;
            [ObservableProperty] private bool? _isActive;
            [ObservableProperty] private bool? _isDeleted;

            // Save the StockItemVm data to the backend via the ApiService
            public async Task SaveStockItemAsync()
            {
                // Create a StockItem object (adjust if you need to pass different fields to your API)
                var stockItem = new StockItem
                {
                    Description=this.Description  ,
                    StockCode = this.StockCode,
                    BarCode = this.BarCode,
                    ShortDescription = this.ShortDescription,
                    Price = this.Price,
                    Name = this.Name,
                    FullDescription = this.FullDescription,
                    Categories = this.Categories,
                    Manufactures = this.Manufactures,
                    AvailableStartDate = this.AvailableStartDate,
                    AvailableEndDate = this.AvailableEndDate,
                    isShowCallButton = this.IsShowCallButton,
                    isNew = this.IsNew,
                    isShowOnHomePage = this.IsShowOnHomePage,
                    StockItemType = this.StockItemType,
                    isShowPrice = this.IsShowPrice,
                    canAddToCart = this.CanAddToCart,
                    isPublished = this.IsPublished,
                    DefaultPrice = this.DefaultPrice,
                    PriceList = this.PriceList,
                    PriceListType = this.PriceListType,
                    SKU = this.Sku,
                    isFeatured = this.IsFeatured,
                    isBackOrder = this.IsBackOrder,
                    CreateDate = this.CreateDate,
                    LastModifiedDate = this.LastModifiedDate,
                    CreatedBy = this.CreatedBy,
                    UpdatedBy = this.UpdatedBy,
                    isActive = this.IsActive,
                    isDeleted = this.IsDeleted
                };

                // Call the ApiService to save the stock item to the backend
               // bool success = await _apiService.PostStockItemViewModel(stockItem);

                if (success)
                {
                    // Handle success, maybe show a success message or navigate
                }
                else
                {
                    // Handle failure, show an error message
                }
            }
        }
    }


