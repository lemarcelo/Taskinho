using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Taskinho.Model;
using Taskinho.DB;
using Taskinho.ViewModels.Popups;
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
        public Command AdicionarCommand
        {
            get;set;
        }
        public Command ExcluirCommand
        {
            get;set;
        }
        public Command EditarCommand
        {
            get;set;
        }

        PopupCadastroViewModel PopupCadastroVm;
        PopupCadastroViewModel GetPopupCadastroVm()
        {
            if (PopupCadastroVm == null)
            {
                PopupCadastroVm = new PopupCadastroViewModel(MetodoUpdate, tarefa);
                return PopupCadastroVm;
            }
            else return PopupCadastroVm;
        }

        private bool MetodoUpdate()
        {
                connection.UpdateT(tarefa);
                Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
                return true;
        }

        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;
        public DetailViewModel(Tarefa tarefa = null)
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

        void SubscribeAdd()
        {
            MessagingCenter.Subscribe<DetailViewModel>(this, "AddMsg", (sender) =>
            {
                Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
                MessagingCenter.Unsubscribe<DetailViewModel>(this, "AddMsg");
            });
        }
        void EditReq(Tarefa ClickedTask)
        {
            PopupCadastroVm.SubscribeEditMsg();
            MessagingCenter.Send<PopupCadastroViewModel, Tarefa>(GetPopupCadastroVm(), "EditReqMsg", ClickedTask);

        }

        void AdicionarAction()
        {
            if (AdicionarCommand != null)
            {
                SubscribeAdd();
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
                //EditReq((Tarefa)param);

                navigationService.NavigationToCadastro();
                
            }
            else
            {
                messageService.ShowAsync("Falha na navegação");
            }
        }
        public bool MetodoExcluir()
        {
            connection.DeleteT(tarefa);
            Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);

            return true;
        }
        void ExcluirAction(object param)
        {
            if (ExcluirCommand != null)
            {
                tarefa = (Tarefa)param;
                string msgParam = string.Format("Deseja excluir a tarefa \n \n{0}", tarefa.TarefaTitulo);
                messageService.ShowAskAsync(MetodoExcluir, msgParam);
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
