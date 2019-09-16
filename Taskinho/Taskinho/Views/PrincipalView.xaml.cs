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
    public partial class PrincipalView : MasterDetailPage
    {
        public PrincipalView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.PrincipalViewModel();
            MasterDetailName.IsPresented = false;
            //App.MasterDetail = this;

            Master = new MenuView();
            Detail = new NavigationPage(new DetailView());
            App.MasterDetail = this;
        }
    }
}