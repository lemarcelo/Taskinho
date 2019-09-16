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
        Tarefa tarefa = new Tarefa();
        private string _titulo;
        #region Props
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                NotifyPropertyChanged("Titulo");
            }
        }
        private string _detalhes;

        public string Detalhes
        {
            get { return _detalhes; }
            set
            {
                _detalhes = value;
                NotifyPropertyChanged("Detalhes");
            }
        }
        private int _gId;
        public int Gid
        {
            get { return _gId; }
            set
            {
                _gId = value;
                NotifyPropertyChanged("Gid");
            }
        }

        private DateTime _prazo;
        public DateTime Prazo
        {
            get { return _prazo; }
            set
            {
                _prazo = value;
                NotifyPropertyChanged("Prazo");
            }

        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
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
            tarefa.TarefaPrazo = DateTime.Now;
            tarefa.IdGrupo = Gid;
            tarefa.TarefaStatus = "p";
            LocalDB _connection = new LocalDB();
            _connection.InsertT(tarefa);
            messageService.ShowAsync("Tarefa Salva");
            navigationService.BackToPrincipal();
        }

        private void Cancelar()
        {
            if (CancelarCommand != null)
            {
                navigationService.BackToPrincipal();
            }
        }
        
        private readonly Services.IMessageService messageService;
        private readonly Services.INavigationService navigationService;

        public CadastroTarefaViewModel()
        {
            
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
