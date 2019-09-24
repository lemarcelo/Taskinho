using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Taskinho.Model;
using Taskinho.DB;
using Taskinho.ViewModels;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Taskinho.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        Tarefa tarefa;
        LocalDB connection;

        private List<Tarefa> _Tarefas;
        public List<Tarefa> Tarefas
        {
            get { return _Tarefas; }
            set
            {
                _Tarefas = value;
                NotifyPropertyChanged("Tarefas");
            }
        }


        private List<Tarefa> _TarefasRetorno;
        public List<Tarefa> TarefasRetorno
        {
            get { return _TarefasRetorno; }
            set
            {
                _TarefasRetorno = value;
            }
        }

        public Command AdicionarCommand
        {
            get;
            set;
        }
        public Command ExcluirCommand
        {
            get;
            set;
        }
        public Command EditarCommand
        {
            get;
            set;
        }

        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;
        public DetailViewModel()
        {
            tarefa = new Tarefa();
            connection = new LocalDB();
            Tarefas = new List<Tarefa>(connection.GetT());
            AdicionarCommand = new Command(AdicionarAction);
            EditarCommand = new Command(TesteEditar);
            ExcluirCommand = new Command(ExcluirAction);
            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }



        void ExcluirAction(object param)
        {
            tarefa = (Tarefa)param;
            //connection.DeleteT(tarefa);
            //TODO - IDENTIFICAR O ITEM TRAZIDO COMO UM ITEM DA LISTA QUE TEMOS SENDO EXIBIDA.
            //TODO - ONPROPERTY CHANGED NÃO ESTÁ EXECUTANDO PARA A REMOÇÃO
            Tarefas.Remove(tarefa); 
            //Tarefas = connection.GetT();
            //messageService.ShowAsync("Teste");
        }

        void AssinarAddMsg()
        {
            MessagingCenter.Subscribe<DetailViewModel>(this, "AdicionarTarefaMsg", (sender) =>
            {
            Tarefas = new List<Tarefa>(connection.GetT());
            //Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
            });
        }
        
        void AdicionarAction()
        {
            if (AdicionarCommand != null)
            {
                AssinarAddMsg();
                navigationService.NavigationToCadastro();
            }
            else
            {
                messageService.ShowAsync("Falha na navegação");
            }
        }
        void TesteEditar()
        {
            messageService.ShowAsync("Editar Teste");
        }


        //Desconsiderar

        //var aButtonClickedCommand = new Command(() =>
        //{
        //    App.DB.IncrementScore(App.cfs, App.phrase, (int)App.aBtn);
        //    App.correctButtonPressed = (int)App.aBtn;
        //    ResetTimer2();
        //});



        //TODO - ADICIONAR TAREFA CRIADA NO CADASTRO A DETALHES
        //TODO - VERIFICAR POSSIBILIDADE DE UTILIZAR O OBSERVABLE COLLECTION

    }
}
