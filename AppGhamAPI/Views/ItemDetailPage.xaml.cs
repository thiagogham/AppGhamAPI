using AppGhamAPI.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppGhamAPI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}