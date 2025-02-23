using System.ComponentModel;
using Xamarin.Forms;
using Warehouse.ViewModels;

namespace Warehouse.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}