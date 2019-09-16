using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskinho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroTarefaView : ContentPage
    {
        public CadastroTarefaView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CadastroTarefaViewModel();
        }
    }
}