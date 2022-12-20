using H4_ChatApp.ViewModels;
using System.Globalization;

namespace H4_ChatApp.Views;

public partial class GroupChatRoom : ContentPage
{
    public GroupChatRoom_ViewModel _ViewModel { get; private set; }

    public GroupChatRoom()
    {
        InitializeComponent();
        _ViewModel = new GroupChatRoom_ViewModel();
        this.BindingContext = _ViewModel;
    }

    protected override bool OnBackButtonPressed()
    {
        _ViewModel.LeavePage();
        return base.OnBackButtonPressed();
    }

    async void OnBackButtonClicked(object sender, EventArgs args)
    {
        bool answer = await App.Current.MainPage.DisplayAlert("Question?", "Do you wanna leave the group chat room? : ", "Yes", "No");

        if (answer)
        {
            await _ViewModel.LeavePage();
            await Shell.Current.GoToAsync("..");
        }
    }

}