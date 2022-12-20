using H4_ChatApp.ViewModels;

namespace H4_ChatApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage_ViewModel _ViewModel { get; private set; }

	public MainPage()
	{
		InitializeComponent();
		_ViewModel= new MainPage_ViewModel();
		this.BindingContext = _ViewModel;
	}
}

