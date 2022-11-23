using ZApp.ViewModels;

namespace ZApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		BindingContext = loginPageViewModel;
		InitializeComponent();
	}
}