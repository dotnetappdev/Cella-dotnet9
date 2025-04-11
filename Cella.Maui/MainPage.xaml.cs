using Cella.Maui.Pages;
 

namespace Cella.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
 

        }

        private async void OnLogin(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainMenu));


        }
    }

}
