using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Taskinho.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
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


        public MenuViewModel()
        {
            Status = "Em Desenvolvimento...";
            this.navigationService = DependencyService.Get<Services.INavigationService>();
        }
        private readonly Services.INavigationService navigationService;
    }
}
