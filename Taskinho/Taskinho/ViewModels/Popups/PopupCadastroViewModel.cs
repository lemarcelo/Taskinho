using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Taskinho.DB;
using Taskinho.Model;
using System.Threading.Tasks;

namespace Taskinho.ViewModels.Popups
{
    public class PopupCadastroViewModel : ViewModelBase
    {
        #region Props

        public string TarefaTitulo
        {
            get
            {
                if (tarefa != null){return this.tarefa.TarefaTitulo;}
                else{return null;}
            }
            set
            {
                if(this.tarefa != null){this.tarefa.TarefaTitulo = value; NotifyPropertyChanged("TarefaTitulo");}
                else{ this.tarefa = new Tarefa(); this.tarefa.TarefaTitulo = value; NotifyPropertyChanged("TarefaTitulo");}
            }
        }

        public string TarefaDetalhes
        {
            get
            {
                if (tarefa != null){return this.tarefa.TarefaDetalhes;}
                else { return null; }
            }
            set
            {
                if (this.tarefa != null){this.tarefa.TarefaDetalhes = value; NotifyPropertyChanged("TarefaDetalhes");}
                else{this.tarefa.TarefaDetalhes = value; NotifyPropertyChanged("TarefaDetalhes");}
            }
        }
        public TimeSpan PrazoHour
        {
            get
            {
                if (tarefa != null){return this.tarefa.TarefaPrazoHour;}
                else { return DateTime.Today.TimeOfDay; }
            }
            set
            {
                if (this.tarefa != null){this.tarefa.TarefaPrazoHour = value; NotifyPropertyChanged("PrazoHour");}
                else{this.tarefa.TarefaPrazoHour = value; NotifyPropertyChanged("PrazoHour");}
            }
        }
        public DateTime PrazoDate
        {
            get
            {
                if (tarefa != null){return this.tarefa.TarefaPrazoDate; }
                else { return DateTime.Now; }
            }
            set
            {
                if (this.tarefa != null){this.tarefa.TarefaPrazoDate = value; NotifyPropertyChanged("PrazoDate");}
                else{this.tarefa.TarefaPrazoDate = value; NotifyPropertyChanged("PrazoDate");}
            }
        }


        private Tarefa _Tarefa;
        public Tarefa tarefa
        {
            get { return _Tarefa; }
            set
            {
                _Tarefa = value;
                NotifyPropertyChanged("tarefa");
            }
        }

        private string _TituloPagina;
        public string TituloPagina
        {
            get { return _TituloPagina; }
            set
            {
                _TituloPagina = value;
                NotifyPropertyChanged("TituloPagina");
            }
        }


        #endregion
         
        public ICommand CancelarCommand
        {
            get;
            set;
        }
        public ICommand SalvarCommand
        {
            get;
            set;
        }

        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;
        
        public PopupCadastroViewModel(Tarefa tarefa = null)
        {
            this.tarefa = new Tarefa();
            this.tarefa = tarefa;


            EditorAdd(this.tarefa);
            CancelarCommand = new Command(CancelarAction);
            SalvarCommand = new Command(SalvarAction);

            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();

        }
        void EditorAdd(Tarefa tarefa = null)
        {
            if (tarefa != null)
            {
                TituloPagina = "Editar Tarefa";
            }
            else
            {
                TituloPagina = "Adicionar Tarefa";
            }
        }
        //TODO - SALVAR TAREFA EDITADA NÃO TAREFA CLICADA
        private void SalvarAction(object obj)
        {
            if (tarefa != null)
            {
                tarefa.IdGrupo = 0;
                tarefa.TarefaStatus = "p";
                LocalDB _connection = new LocalDB();
                if (TituloPagina == "Editar Tarefa")
                {
                    _connection.UpdateT(tarefa);
                    SendEdit();
                }
                else
                {
                    _connection.InsertT(tarefa);
                    SendAdd();
                }
                navigationService.BackPopUp();
            }
            else
            {

            }

        }
        private void CancelarAction()
        {

            var detailViewModel = new DetailViewModel();
            MessagingCenter.Unsubscribe<DetailViewModel, Tarefa>(detailViewModel, "EditMsg");
            MessagingCenter.Unsubscribe<DetailViewModel>(detailViewModel, "AddMsg");

            navigationService.BackPopUp();

        }
        void SendAdd()
        {
            var detailViewModel = new DetailViewModel();
            MessagingCenter.Send(detailViewModel, "AddMsg");
        }
        public void SendEdit()
        {
            var detailViewModel = new DetailViewModel();
            MessagingCenter.Send(detailViewModel, "EditMsg", tarefa);
        }
        //TODO - POSSIBILIDADE DE DESFAZER REALIZAÇÃO
        //TODO - Reagendar Tarefa
    }
}
