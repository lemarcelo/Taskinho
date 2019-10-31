using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskinho.Model;
using Taskinho.ViewModels;
using Xamarin.Forms;

namespace Taskinho.Views.Services
{
    public class MessageService : Taskinho.Services.IMessageService
    {
        public async Task ShowAsync(string message)
        {
            //var page = new Popups.PopupView();
            //await PopupNavigation.Instance.PushAsync(page);
        }

        public async Task ShowAskAsync(Func<bool> metodo, Tarefa tarefa)
        {
            var page = new Popups.PopupView(metodo, tarefa);
            await PopupNavigation.Instance.PushAsync(page);
        }

        public async Task ShowPage(Tarefa tarefa)
        {
            //var page = new Views.Popups.PopupView();
            //await PopupNavigation.Instance.PushAsync(page);
        }
    }
}
