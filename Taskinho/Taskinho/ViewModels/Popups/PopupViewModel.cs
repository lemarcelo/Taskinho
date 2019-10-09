using System;
using System.Collections.Generic;
using System.Text;
using Taskinho.Model;
using Xamarin.Forms;
using Taskinho.ViewModels;

namespace Taskinho.ViewModels.Popups
{
    public class PopupViewModel : ViewModelBase
    {
        private Tarefa _Tarefa;
        public Tarefa Tarefa
        {
            get { return _Tarefa; }
            set { _Tarefa = value;
                NotifyPropertyChanged("Tarefa");
            }
        }

        public Command EnviarMsg
        {
            get;
            set;
        }
        public Command RegistrarMsg
        {
            get;
            set;
        }
        public PopupViewModel()
        {
             EnviarMsg = new Command(SendDeleteReqMsg);
             RegistrarMsg = new Command(RegDeleteReqMsg);
        }

        public void SendDeleteReqMsg()
        {

            MessagingCenter.Send(this, "EditReqMsg");
        }
        public void RegDeleteReqMsg()
        {
                MessagingCenter.Subscribe<PopupViewModel>(this, "EditReqMsg", (sender) =>
                {
                    Tarefa.TarefaTitulo = "TesteMsg";
            });
        }
        public void CancelDeleteReqMsg()
        {
            MessagingCenter.Unsubscribe<PopupViewModel>(this, "DeleteReqMsg");
        }
    }
}
