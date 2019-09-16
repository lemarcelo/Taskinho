using System;
using System.Collections.Generic;
using System.Text;
using Taskinho.Model;
using Xamarin.Forms;

namespace Taskinho.Util
{
    public class TarefaDataTemplateSelector : DataTemplateSelector
    {
        public int num = 0;
        public enum numero { a, b, c, d }
        public DataTemplate TarefaPendenteTemplate { get; set; }
        public DataTemplate TarefaRealizadaTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((Tarefa)item).TarefaStatus)
            {
                case "p":
                    return TarefaPendenteTemplate;
                case "r":
                    return TarefaRealizadaTemplate;
                default:
                    return TarefaRealizadaTemplate;
            }
        }

    }
}