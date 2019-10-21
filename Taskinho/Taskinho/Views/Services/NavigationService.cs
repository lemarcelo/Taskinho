using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Taskinho.Model;

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


        public NavigationService(Tarefa tarefa = null, Grupo grupo = null)
        {
            Tarefa = tarefa;
            Grupo = grupo;
        }
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
