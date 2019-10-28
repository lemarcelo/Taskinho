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
        public PopupViewModel(Tarefa TarefaParam)
        {
            /*Lembrete para perguntar sobre isto tarefa dentro da mainthread não funciona
             pode ter relação com o contexto da aplicação mas não sei explicar o motivo*/
            tarefa = new Tarefa();
            Device.BeginInvokeOnMainThread(() =>
            {
                tarefa.TarefaTitulo = TarefaParam.TarefaTitulo;
            });
        }
        //bool exclusao = false;
        private string _jose;
        public string jose
        {
            get { return _jose; }
            set{ _jose = value;
                NotifyPropertyChanged("jose");
            }
        }



        private Tarefa _Tarefa;
        public Tarefa tarefa
        {
            get { return _Tarefa; }
            set { _Tarefa = value;
                NotifyPropertyChanged("Tarefa");
            }
        }

        public Command Confirmar
        {
            get;
            set;
        }
        public Command Negar
        {
            get;
            set;
        }
        //public event EventHandler ExclusaoEvent;


        private readonly Services.INavigationService navigationService;
        private readonly Services.IMessageService messageService;
        public PopupViewModel()
        {
            Confirmar = new Command(ExcluirAction);
            //Negar = new Command();

            this.navigationService = DependencyService.Get<Services.INavigationService>();
            this.messageService = DependencyService.Get<Services.IMessageService>();
        }

        private void ExcluirAction(object obj)
        {
            messageService.ShowAskAsync(tarefa);
        }

    }
}
