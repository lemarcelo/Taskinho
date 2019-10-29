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
        public PopupViewModel(Func<bool> metodoParam, Tarefa TarefaParam)
        {
            
            this.tarefa = new Tarefa();

            bool jose = false;
            jose = metodoParam.Invoke();


            Device.BeginInvokeOnMainThread(() =>
            {
                this.tarefa.TarefaTitulo = TarefaParam.TarefaTitulo;
            });
        }
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
        public Command Executar
        {
            get;
            set;
        }

        /*Lembrete para perguntar sobre isto tarefa dentro da mainthread não funciona
             pode ter relação com o contexto da aplicação mas não sei explicar o motivo*/
        public Command Cancelar
        {
            get;
            set;
        }
        private readonly Services.INavigationService navigationService;
        public PopupViewModel()
        {
            Executar = new Command(ExecutarAction);
            Cancelar = new Command(CancelarAction);

            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }
        void ExecutarAction()
        {
            method.Invoke();
        }
        void CancelarAction()
        {
            navigationService.BackToPrincipal();
        }


    }
}
