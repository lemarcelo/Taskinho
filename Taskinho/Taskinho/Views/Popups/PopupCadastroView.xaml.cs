﻿using System;
using Rg.Plugins.Popup.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskinho.Model;

namespace Taskinho.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCadastroView : PopupPage
    {
        public PopupCadastroView(Tarefa tarefa= null)
        {
            BindingContext = new ViewModels.Popups.PopupCadastroViewModel(tarefa);
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            EntryFocused.Focus();
        }
    }
}