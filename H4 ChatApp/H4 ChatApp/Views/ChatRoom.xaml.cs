using H4_ChatApp.ViewModels;
using System.Globalization;

namespace H4_ChatApp.Views;

public partial class ChatRoom : ContentPage
{
    public ChatRoom_ViewModel _ViewModel { get; private set; }

    public ChatRoom()
    {
        InitializeComponent();
        _ViewModel = new ChatRoom_ViewModel();
        this.BindingContext = _ViewModel;
    }

    async void OnBackButtonClicked(object sender, EventArgs args)
    {
        bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Do you wanna leave the chat room? : ", "Yes", "No");

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