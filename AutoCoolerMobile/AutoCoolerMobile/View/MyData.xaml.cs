using AutoCoolerMobile.ViewModel;
using AutoCoolerMobile.Model;

namespace AutoCoolerMobile.View;

public partial class MyData : ContentPage
{
	private readonly UserViewModel _userViewModel;

    public MyData()
	{
		InitializeComponent();

        _userViewModel = new UserViewModel();
        _userViewModel.User = Session.UserCurrent;

        BindingContext = _userViewModel;
    }
}