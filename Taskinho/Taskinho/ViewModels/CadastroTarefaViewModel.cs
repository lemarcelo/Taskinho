using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Taskinho.ViewModels;
using Xamarin.Forms;
using Taskinho.DB;
using Taskinho.Model;
using Taskinho.Services;
using System.Threading.Tasks;

namespace Taskinho.ViewModels
{
    public class CadastroTarefaViewModel : ViewModelBase
    {
        #region Props
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

        private void Adicionar(object obj)
        {
            tarefa.IdGrupo = 0;
            tarefa.TarefaTitulo = Titulo;
            tarefa.TarefaDetalhes = Detalhes;
            tarefa.TarefaPrazo = Prazo;
            tarefa.IdGrupo = Gid;
            tarefa.TarefaStatus = "p";
            LocalDB _connection = new LocalDB();
            _connection.InsertT(tarefa);
            messageService.ShowAsync("Tarefa Salva");
            SendAddMsg();
            navigationService.BackToPrincipal();
        }

        private void Cancelar()
        {
            if (CancelarCommand != null)
            {
                navigationService.BackToPrincipal();
            }
        }
        
        void SendAddMsg()
        {
            var detailViewModel = new DetailViewModel();
            MessagingCenter.Send(detailViewModel, "AddMsg");
        }

        public void RegEditReqMsg()
        {
            MessagingCenter.Subscribe<CadastroTarefaViewModel, Tarefa>(this, "EditReqMsg", (sender, args) =>
            {
                Titulo = args.TarefaTitulo;
                Detalhes = args.TarefaDetalhes;
                Prazo = args.TarefaPrazo;
            });
        }


        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;

        public CadastroTarefaViewModel()
        {
            RegEditReqMsg();
            Prazo = DateTime.Now;
            CancelarCommand = new Command(Cancelar);
            SalvarCommand = new Command(Adicionar);

            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();

        }

        //TODO - OCULTAR DATA QUANDO NÃO INFORMADA
        //TODO - POSSIBILIDADE DE ALTERAR TAREFA
        //TODO - POSSIBILIDADE DE DESFAZER REALIZAÇÃO
        //TODO - PAREI NA NAVEGAÇÃO DE TELA TESTE DA TELA CADASTO PARA A PRINCIPAL POR VOLTA DE 20 MIN
        //TODO - https://www.youtube.com/watch?v=Yr7pGCsGmQ0&t=486s
        //TODO - Reagendar Tarefa
    }
}
