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

        private Tarefa _Tarefa;
        public Tarefa tarefa
        {
            get { return _Tarefa; }
            set
            {
                _Tarefa = value;
                NotifyPropertyChanged("Tarefas");
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
            tarefa.TarefaPrazo = DateTime.Now;
            CancelarCommand = new Command(CancelarAction);
            SalvarCommand = new Command(SalvarAction);

            this.messageService = DependencyService.Get<Services.IMessageService>();
            this.navigationService = DependencyService.Get<Services.INavigationService>();

        }
        //TODO - SALVAR TAREFA EDITADA NÃO TAREFA CLICADA
        private void SalvarAction(object obj)
        {
            if (MetodoParam!= null)
            {
                MetodoParam.Invoke();
            }
            tarefa.IdGrupo = 0;
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
                //Titulo = args.TarefaTitulo;
                //Detalhes = args.TarefaDetalhes;
                //Prazo = args.TarefaPrazo;
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
