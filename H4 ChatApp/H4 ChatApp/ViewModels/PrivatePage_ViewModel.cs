using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Android.Webkit;
using H4_ChatApp.Models;
using H4_ChatApp.Services.Core;
using H4_ChatApp.Services.Interfaces;
using H4_ChatApp.ViewModels.Core;
//using static Android.Provider.Settings;

namespace H4_ChatApp.ViewModels
{
    public class PrivatePage_ViewModel : CoreNavigation_ViewModel
    {

        private PrivateModel _SelectedPrivate;
        public PrivateModel selectedPrivate
        {
            get
            {
                return _SelectedPrivate;
            }
            set
            {
                _SelectedPrivate = value;
                OnPropertyChanged(nameof(selectedPrivate));

                if (_SelectedPrivate != null)
                {
                    Navigate_PrivateChatRoom();
                    _SelectedPrivate = null;
                }
            }
        }


        public PrivatePage_ViewModel()
        {
            selectedPrivate = null;
        }


        async void Navigate_PrivateChatRoom()
        {
            var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId", UserId.ToString() }, { "PrivateTarget", selectedPrivate.Name }, { "PrivateContactId", selectedPrivate.Id.ToString() } };
            await Shell.Current.GoToAsync($"PrivateChatRoom", navigationParameter);
        }

    }
}