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
        bool exclusao = false;

        private Tarefa _Tarefa;
        public Tarefa Tarefa
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
        public delegate void ExclusaoDelegate();

        public event ExclusaoDelegate ExclusaoEvent;


        private readonly Services.INavigationService navigationService;
        private readonly Services.IMessageService messageService;
        public PopupViewModel(Tarefa tarefa = null, Grupo grupo = null)
        {
            tarefa = Tarefa;
            Confirmar = new Command(ExcluirAction);
            //Negar = new Command();

            this.navigationService = DependencyService.Get<Services.INavigationService>();
            this.messageService = DependencyService.Get<Services.IMessageService>();
        }

        private void ExcluirAction(object obj)
        {
            ExclusaoEvent += PopupViewModel_ExclusaoEvent;
            if ()
            {
                App.Current.MainPage.DisplayAlert("","Exclusão clicada","");
            }
        }

        private void PopupViewModel_ExclusaoEvent()
        {
            throw new NotImplementedException();
        }
    }
}
