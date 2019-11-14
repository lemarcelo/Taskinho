using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Taskinho.Model;
using Rg.Plugins.Popup.Services;

namespace Taskinho.Views.Services
{
    public class NavigationService : Taskinho.Services.INavigationService
    {
        private Tarefa _Tarefa;

        public Tarefa Tarefa
        {
            get { return _Tarefa; }
            set { _Tarefa = value; }
        }
        private Grupo _Grupo;

        public Grupo Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }


        public NavigationService()
        {
            //Tarefa = tarefa;
            //Grupo = grupo;
        }
        public async Task NavigationToCadastro()
        {
            var page = new Popups.PopupCadastroView();
            await PopupNavigation.Instance.PushAsync(page);
            //await App.MasterDetail.Detail.Navigation.PushModalAsync(new CadastroTarefaView());
        }

        public async Task NavigationToPrincipal()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.PrincipalView());
        }
        public async Task BackToPrincipal()
        {
            await App.MasterDetail.Detail.Navigation.PopModalAsync();
        }

        public async Task BackPopUp()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        public async Task NavigationToCadastro(Tarefa tarefa = null)
        {
            var page = new Popups.PopupCadastroView(tarefa);
            await PopupNavigation.Instance.PushAsync(page);
            //if (tarefa != null)
            //{
            //    var page = new Popups.PopupCadastroView(tarefa);
            //    await PopupNavigation.Instance.PushAsync(page);

            //}
            //else
            //{

            //}


        }
    }
}
