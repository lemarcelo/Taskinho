using System;
using Taskinho.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskinho
{
    public partial class App : Application
    {

        public static MasterDetailPage MasterDetail { get; set; }
        public App()
        {
            DependencyService.Register<Services.IMessageService, Views.Services.MessageService>();
            DependencyService.Register<Services.INavigationService, Views.Services.NavigationService>();
            InitializeComponent();
            MainPage = new Views.PrincipalView();
            CadastroTarefaViewModel cadVm = new CadastroTarefaViewModel();
            cadVm.RegEditReqMsg();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
