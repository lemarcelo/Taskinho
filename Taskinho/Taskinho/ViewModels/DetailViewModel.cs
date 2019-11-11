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
        LocalDB _connection = new LocalDB();
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
        private string _SelectedDetalhes;
        public string DetalhesFrame
        {
            get { return _SelectedDetalhes; }
            set
            {
                _SelectedDetalhes = value;
                NotifyPropertyChanged("SelectedDetalhes");
            }
        }
        public Command AdicionarCommand
        {
            get;set;
        }
        public Command FrameCommand
        {
            get;set;
        }
        public Command EditarCommand
        {
            get; set;

        }
        public Command ExcluirCommand
        {
            get;set;
        }
        public Command StatusCommand
        {
            get;set;
        }

        PopupCadastroViewModel PopupCadastroVm;
        PopupCadastroViewModel GetPopupCadastroVm()
        {
            if (PopupCadastroVm == null)
            {
                PopupCadastroVm = new PopupCadastroViewModel(tarefa);
                return PopupCadastroVm;
            }
            else return PopupCadastroVm;
        }

        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;
        public DetailViewModel(Tarefa tarefa = null)
        {
            tarefa = new Tarefa();
            connection = new LocalDB();
            Tarefas = new ObservableCollection<Tarefa>(connection.GetT());
            FrameCommand = new Command(FrameAction);
            AdicionarCommand = new Command(AdicionarAction);
            EditarCommand = new Command(EditarAction);
            ExcluirCommand = new Command(ExcluirAction);
            StatusCommand = new Command(StatusAction);
            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }

        private void StatusAction(object obj)
        {
            _connection.Realized((Tarefa)obj);
        }

        private void FrameAction(object obj)
        {
            var DetalhesClicado = (Tarefa)obj;
            DetalhesFrame = DetalhesClicado.TarefaDetalhes;
        }
        void SubscribeAdd()
        {
            MessagingCenter.Subscribe<DetailViewModel>(this, "AddMsg", (sender) =>
            {
                Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
                MessagingCenter.Unsubscribe<DetailViewModel>(this, "AddMsg");
            });
        }

        void SubscribeUpdate()
        {
            MessagingCenter.Subscribe<DetailViewModel, Tarefa>(this, "EditMsg", (sender, args)=>
                {
                    Tarefas = new ObservableCollection<Tarefa>(connection.GetT() as List<Tarefa>);
                    MessagingCenter.Unsubscribe<DetailViewModel, Tarefa>(this, "EditMsg");
                }
            );
        }

        void AdicionarAction()
        {
            if (AdicionarCommand != null)
            {
                SubscribeAdd();
                tarefa = null;
                navigationService.NavigationToCadastro(tarefa);
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
                Tarefa tarefinha = new Tarefa();
                tarefinha = (Tarefa)param;
                SubscribeUpdate();
                Tarefa tarefaParam = _connection.GetById((int)tarefinha.IdTarefa);

                navigationService.NavigationToCadastro(tarefaParam);
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
