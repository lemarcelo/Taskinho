using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskinho.Model;

namespace Taskinho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.DetailViewModel();
        }
    }
}