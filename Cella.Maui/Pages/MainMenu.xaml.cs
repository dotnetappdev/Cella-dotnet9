using Cella.Maui.Pages.Stock;

namespace Cella.Maui.Pages;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
	}

    private async 
        void btnStockListings_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(StockListings));

    }
}