using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Taskinho.Model;
using Taskinho.DB;
using Taskinho.ViewModels;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

namespace Taskinho.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {



        Tarefa tarefa;
        LocalDB connection;

        private ObservableCollection<Tarefa> _Tarefas;
        public ObservableCollection<Tarefa> Tarefas
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
            Tarefas = new ObservableCollection<Tarefa>(connection.GetT());
            AdicionarCommand = new Command(AdicionarAction);
            EditarCommand = new Command(EditarAction);
            ExcluirCommand = new Command(ExcluirAction);
            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }


        void RegAddMsg()
        {
            MessagingCenter.Subscribe<DetailViewModel>(this, "AddMsg", (sender) =>
            {
                Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
                MessagingCenter.Unsubscribe<DetailViewModel>(this, "AddMsg");
            });
        }

        void SendEditReq(Tarefa ClickedTask)
        {
            CadastroTarefaViewModel cadVm = new CadastroTarefaViewModel();
            MessagingCenter.Send(cadVm, "EditReqMsg", ClickedTask);
        }

        void SendDeleteReq()
        {
            messageService.ShowAskAsync();
        }

        void AdicionarAction()
        {
            if (AdicionarCommand != null)
            {
                RegAddMsg();
                navigationService.NavigationToCadastro();
            }
            else
            {
                messageService.ShowAsync("Falha na navegação");
            }
        }
        void EditarAction(object param)
        {
            if (EditarCommand != null)
            {
                navigationService.NavigationToCadastro();
                SendEditReq((Tarefa)param);

            }
            else
            {
                messageService.ShowAsync("Falha na navegação");
            }
        }
        void ExcluirAction(object param)
        {
            if (ExcluirCommand != null)
            {
                SendDeleteReq();
                messageService.ShowAskAsync();
            }
            else
            {
                messageService.ShowAsync("Falha na navegação");
            }

            tarefa = (Tarefa)param;

            //connection.UpdateT(tarefa);
            //tarefa = (Tarefa)param;
            //Tarefas.Remove(tarefa);
            //connection.DeleteT(tarefa);

        }

    }
}
