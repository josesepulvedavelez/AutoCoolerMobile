using AutoCoolerMobile.Model;
using AutoCoolerMobile.ViewModel;

namespace AutoCoolerMobile.View;

public partial class LoginPage : ContentPage
{
	private readonly UserViewModel _userViewModel;

    public LoginPage()
	{
		InitializeComponent();
        _userViewModel = new UserViewModel();
        BindingContext = _userViewModel;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginRequest = new LoginRequest
        {
            UserName = userNameEntry.Text,
            Password = passwordEntry.Text
        };

        try
        {
            await _userViewModel.Login(loginRequest);
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }

    }

    private async void OnCompanyPage_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//CompanyPage");
    }
}