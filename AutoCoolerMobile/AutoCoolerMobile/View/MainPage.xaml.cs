using AutoCoolerMobile.Model;
using AutoCoolerMobile.ViewModel;

using System.Threading.Tasks;

namespace AutoCoolerMobile.View
{
    public partial class MainPage : ContentPage
    {        
        private readonly ServiceOrderViewModel _serviceOrderViewModel;

        public MainPage()
        {
            InitializeComponent();
            _serviceOrderViewModel = new ServiceOrderViewModel();
            BindingContext = _serviceOrderViewModel;
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            var userId = Session.UserCurrent?.UserId ?? 0;

            if (userId > 0)
            {
                await _serviceOrderViewModel.LoadServiceOrdersAsync(userId);
            }
            else
            {
                await DisplayAlert("Error", "User not logged in. Please log in to view service orders.", "OK");
            }            
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var collectionView = (CollectionView)sender;

            if (collectionView.SelectedItem is ServiceOrderForTechnicianDto selectedOrder)
            {
                await Shell.Current.GoToAsync($"///ServiceOrderDetailPage?serviceOrderId={selectedOrder.ServiceOrderId}", true);
                collectionView.SelectedItem = null;
            }
        }

    }
}
