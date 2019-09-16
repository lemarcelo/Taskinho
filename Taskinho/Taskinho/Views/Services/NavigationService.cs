using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Taskinho.Views.Services
{
    public class NavigationService : Taskinho.Services.INavigationService
    {
        public async Task NavigationToCadastro()
        {
            await App.MasterDetail.Detail.Navigation.PushModalAsync(new CadastroTarefaView());
        }

        public async Task NavigationToPrincipal()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.PrincipalView());
        }
        public async Task BackToPrincipal()
        {
            await App.MasterDetail.Detail.Navigation.PopModalAsync();
        }

    }
}
