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
        public PopupView(Func<bool> Method, Tarefa TarefaParam)
        {
            BindingContext = new ViewModels.Popups.PopupViewModel(Method, TarefaParam);
            InitializeComponent();
        }
    }
}