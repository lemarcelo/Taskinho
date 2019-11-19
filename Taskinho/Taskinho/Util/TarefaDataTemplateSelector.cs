using System;
using System.Collections.Generic;
using System.Text;
using Taskinho.Model;
using Xamarin.Forms;

namespace Taskinho.Util
{
    public class TarefaDataTemplateSelector : DataTemplateSelector
    {
        //[sem uso]
        //public int num = 0;
        //public enum numero { a, b, c, d }

            //TODO - CRIAR DATA TEMPLATE PARA STACKLAYOUT DE EDIÇÃO OU EXCLUSÃO

        public DataTemplate TarefaPendenteTemplate { get; set; }
        public DataTemplate TarefaRealizadaTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((Tarefa)item).TarefaRealizada)
            {
                case false:
                    return TarefaPendenteTemplate;
                case true:
                    return TarefaRealizadaTemplate;
                default:
                    return TarefaRealizadaTemplate;
            }
        }

    }
}