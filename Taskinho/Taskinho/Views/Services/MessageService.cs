using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taskinho.Views.Services
{
    public class MessageService : Taskinho.Services.IMessageService
    {
        public async Task ShowAsync(string message)
        {
            //await App.Current.MainPage.DisplayAlert("Titulo", "Mensagem", "Ok", "Cancel");

            var page = new Views.Popups.PopupView();
            await PopupNavigation.Instance.PushAsync(page);
        }

        public async Task<bool> ShowAsyncBool(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, "ok", "Cancel");
        }
    }
}
