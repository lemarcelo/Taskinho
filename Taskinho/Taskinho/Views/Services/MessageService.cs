using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taskinho.Views.Services
{
    public class MessageService : Taskinho.Services.IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await  App.Current.MainPage.DisplayAlert("Taskinho", message, "ok");
        }
    }
}
