using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskinho.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskinho.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupView : PopupPage
    {
        public bool verdadeiro = false;
        public PopupView(Func<bool> metodo, Tarefa tarefa)
        {
            BindingContext = new ViewModels.Popups.PopupViewModel(metodo, tarefa);
            InitializeComponent();
        }


    }
}