using H4_ChatApp.ViewModels;

namespace H4_ChatApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage_ViewModel _ViewModel { get; private set; }

	public LoginPage()
	{
		InitializeComponent();
		_ViewModel= new LoginPage_ViewModel();
		this.BindingContext = _ViewModel;
	}
}

