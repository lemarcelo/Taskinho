using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Taskinho.DB;
using Taskinho.Model;

namespace Taskinho.ViewModels.Popups
{
    public class PopupCadastroViewModel : ViewModelBase
    {
        #region Props
        Func<bool> MetodoParam;
        Tarefa tarefa = new Tarefa();

        private string _Titulo;
        public string Titulo
        {
            get { return _Titulo; }
            set
            {
                _Titulo = value;
                NotifyPropertyChanged("Titulo");
            }
        }

        private string _Detalhes;
        public string Detalhes
        {
            get { return _Detalhes; }
            set
            {
                _Detalhes = value;
                NotifyPropertyChanged("Detalhes");
            }
        }

        private int _Gid;
        public int Gid
        {
            get { return _Gid; }
            set
            {
                _Gid = value;
                NotifyPropertyChanged("Gid");
            }
        }

        private DateTime _Prazo;
        public DateTime Prazo
        {
            get { return _Prazo; }
            set
            {
                _Prazo = value;
                NotifyPropertyChanged("Prazo");
            }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                NotifyPropertyChanged("Status");
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
        
        public PopupCadastroViewModel(Func<bool> metodo, Tarefa tarefa = null)
        {
            MetodoParam = metodo;
            this.tarefa = tarefa;
            Prazo = DateTime.Now;
            CancelarCommand = new Command(CancelarAction);
            SalvarCommand = new Command(SalvarAction);

            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();

        }
        private void SalvarAction(object obj)
        {
            tarefa.IdGrupo = 0;
            tarefa.TarefaTitulo = Titulo;
            tarefa.TarefaDetalhes = Detalhes;
            tarefa.TarefaPrazo = Prazo;
            tarefa.IdGrupo = Gid;
            tarefa.TarefaStatus = "p";
            LocalDB _connection = new LocalDB();
            _connection.InsertT(tarefa);
            SendAddMsg();
            navigationService.BackPopUp();
        }

        private void CancelarAction()
        {
            if (CancelarCommand != null)
            {
                navigationService.BackPopUp();
            }
        }

        void SendAddMsg()
        {
            var detailViewModel = new DetailViewModel();
            MessagingCenter.Send(detailViewModel, "AddMsg");
        }

        public void SubscribeEditMsg()
        {
            MessagingCenter.Subscribe<PopupCadastroViewModel, Tarefa>(this, "EditReqMsg", (sender, args) =>
            {
                Titulo = args.TarefaTitulo;
                Detalhes = args.TarefaDetalhes;
                Prazo = args.TarefaPrazo;
            });
        }

        //TODO - OCULTAR DATA QUANDO NÃO INFORMADA
        //TODO - POSSIBILIDADE DE ALTERAR TAREFA
        //TODO - POSSIBILIDADE DE DESFAZER REALIZAÇÃO
        //TODO - PAREI NA NAVEGAÇÃO DE TELA TESTE DA TELA CADASTO PARA A PRINCIPAL POR VOLTA DE 20 MIN
        //TODO - https://www.youtube.com/watch?v=Yr7pGCsGmQ0&t=486s
        //TODO - Reagendar Tarefa
    }
}
