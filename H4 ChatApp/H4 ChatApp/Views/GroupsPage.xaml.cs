using H4_ChatApp.ViewModels;
using System.Globalization;

namespace H4_ChatApp.Views;

public partial class GroupPage : ContentPage
{
    public GroupPage_ViewModel _ViewModel { get; private set; }

    public GroupPage()
    {
        InitializeComponent();
        _ViewModel = new GroupPage_ViewModel();
        this.BindingContext = _ViewModel;
    }
}