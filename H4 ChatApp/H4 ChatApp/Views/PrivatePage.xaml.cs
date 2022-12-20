using H4_ChatApp.ViewModels;
using System.Globalization;

namespace H4_ChatApp.Views;

public partial class PrivatePage : ContentPage
{
    public PrivatePage_ViewModel _ViewModel { get; private set; }

    public PrivatePage()
    {
        InitializeComponent();
        _ViewModel = new PrivatePage_ViewModel();
        this.BindingContext = _ViewModel;
    }
}