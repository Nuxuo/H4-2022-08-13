using H4_ChatApp.ViewModels;
using System.Globalization;

namespace H4_ChatApp.Views;

public partial class PrivateChatRoom : ContentPage
{
    public PrivateChatRoom_ViewModel _ViewModel { get; private set; }

    public PrivateChatRoom()
    {
        InitializeComponent();
        _ViewModel = new PrivateChatRoom_ViewModel();
        this.BindingContext = _ViewModel;
    }

    async void OnBackButtonClicked(object sender, EventArgs args)
    {
        bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Do you wanna leave the private chat room? : ", "Yes", "No");

        if (answer)
        {
            await _ViewModel.LeavePage();
            await Shell.Current.GoToAsync("..");
        }
    }

    protected override bool OnBackButtonPressed()
    {
        _ViewModel.LeavePage();
        return base.OnBackButtonPressed();
    }

}