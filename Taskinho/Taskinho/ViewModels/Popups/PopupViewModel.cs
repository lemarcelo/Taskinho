using System;
using System.Collections.Generic;
using System.Text;
using Taskinho.Model;
using Xamarin.Forms;
using Taskinho.ViewModels;
using Taskinho.Views.Services;


namespace Taskinho.ViewModels.Popups
{
    public class PopupViewModel : ViewModelBase
    {
        public Func<bool> metodo;

        private Tarefa _Tarefa;
        public Tarefa tarefa
        {
            get { return _Tarefa; }
            set { _Tarefa = value;
                NotifyPropertyChanged("Tarefa");
            }
        }

        public Func<bool> method;
        /*Lembrete para questionar sobre get; set;, pois o command não funciona sem*/
        public Command ExecutarCommand
        {
            get;
            set;
        }

        /*Lembrete para perguntar sobre isto tarefa dentro da mainthread não funciona
             pode ter relação com o contexto da aplicação mas não sei explicar o motivo*/
        public Command CancelarCommand
        {
            get;
            set;
        }
        private readonly Services.INavigationService navigationService;
        public PopupViewModel(Func<bool> metodoParam, Tarefa TarefaParam)
        {
            tarefa = new Tarefa();
            tarefa = TarefaParam;
            metodo = metodoParam;
            ExecutarCommand = new Command(ExecutarAction);
            CancelarCommand = new Command(CancelarAction);

            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }
        void ExecutarAction()
        {
            metodo.Invoke();
        }
        void CancelarAction()
        {
            navigationService.BackToPrincipal();
        }


    }
}
