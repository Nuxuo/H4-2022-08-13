using H4_ChatApp.Views;
//using Java.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using H4_ChatApp.Models;

namespace H4_ChatApp.ViewModels
{
    public class LoginPage_ViewModel : INotifyPropertyChanged
    {
        //              PROPERTY EVENTS           //
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _Username;
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private int _UserId;
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }


        public Command Navigate_MainPage_Command { get; set; }
        private List<LoginClass> Logins = new List<LoginClass>();

        public LoginPage_ViewModel()
        {
            Navigate_MainPage_Command = new Command(Navigate_MainPage);

            Logins.Add(new LoginClass { Id = 1, Username= "Andreas", Password = "test" });
            Logins.Add(new LoginClass { Id = 2, Username = "Jesper", Password = "test" });
            Logins.Add(new LoginClass { Id = 3, Username = "Kasper", Password = "test" });
        }

        private class LoginClass
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }


        async void Navigate_MainPage()
        {
            LoginClass _login = Logins.FirstOrDefault(x => x.Username == Username && x.Password == Password);
            if (_login != null)
            {
                Username = _login.Username;
                UserId = _login.Id;



                var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId", UserId.ToString() } };
                await Shell.Current.GoToAsync($"MainPage", navigationParameter);

            }

        }

    }
}
