using Cella.Maui.Pages;
using Cella.Maui.Pages.Stock;

namespace Cella.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainMenu), typeof(MainMenu));
            Routing.RegisterRoute(nameof(StockListings), typeof(StockListings));

        }
    }
}
