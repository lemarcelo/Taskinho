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


        public string Titulo
        {
            get{if (tarefa != null)
                {
                    return this.tarefa.TarefaTitulo;
                }
                else{return null;}}
            set{if (this.tarefa != null)
                {
                    this.tarefa.TarefaTitulo = value; NotifyPropertyChanged("Titulo");
                }
                else
                {
                    tarefa = new Tarefa();
                    this.tarefa.TarefaTitulo = value; NotifyPropertyChanged("Titulo");
                }
            }
        }

        public string Detalhes
        {
            get
            {
                if (tarefa != null)
                {
                    return this.tarefa.TarefaDetalhes;
                }
                else { return null; }
            }
            set
            {
                if (this.tarefa != null)
                {
                    this.tarefa.TarefaDetalhes = value; NotifyPropertyChanged("Titulo");
                }
                else
                {
                    tarefa = new Tarefa();
                    this.tarefa.TarefaDetalhes = value; NotifyPropertyChanged("Detalhes");
                }
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
            this.tarefa = tarefa;
            EditorAdd(tarefa);
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
                if (TituloPagina == "EditarTarefa")
                {
                    _connection.InsertT(tarefa);
                    SendAdd();
                }
                else
                {
                    _connection.UpdateT(tarefa);
                    SendEdit();
                }
                navigationService.BackPopUp();
            }
            else
            {

            }

        }
        private void CancelarAction()
        {
            if (CancelarCommand != null)
            {
                navigationService.BackPopUp();
            }
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
        //TODO - OCULTAR DATA QUANDO NÃO INFORMADA
        //TODO - POSSIBILIDADE DE ALTERAR TAREFA
        //TODO - POSSIBILIDADE DE DESFAZER REALIZAÇÃO
        //TODO - PAREI NA NAVEGAÇÃO DE TELA TESTE DA TELA CADASTO PARA A PRINCIPAL POR VOLTA DE 20 MIN
        //TODO - https://www.youtube.com/watch?v=Yr7pGCsGmQ0&t=486s
        //TODO - Reagendar Tarefa
    }
}
