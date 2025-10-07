using AutoCoolerMobile.Model;
using AutoCoolerMobile.ViewModel;

namespace AutoCoolerMobile.View;

[QueryProperty(nameof(ServiceOrderId), "serviceOrderId")]
public partial class ServiceOrderDetailPage : ContentPage
{
    private readonly ServiceOrderDetailViewModel _viewModel;
    private string _serviceOrderId;

    public string ServiceOrderId
    {
        get => _serviceOrderId;
        set
        {
            _serviceOrderId = value;
            OnServiceOrderIdChanged();
        }
    }

    public ServiceOrderDetailPage()
    {
        InitializeComponent();
        _viewModel = new ServiceOrderDetailViewModel();
        BindingContext = _viewModel;
    }

    private async void OnServiceOrderIdChanged()
    {
        if (int.TryParse(_serviceOrderId, out int id))
        {
            await _viewModel.GetServiceOrderById(id);
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
        
}

