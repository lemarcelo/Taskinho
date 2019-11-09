using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Taskinho.ViewModels;

namespace Taskinho.Model
{
    public class Tarefa
    {
        [PrimaryKey, AutoIncrement]
        public long IdTarefa { get; set; }
        public int IdGrupo { get; set; }

        //public enum TarefaStatus { a,b,c,d,e}
        public string TarefaStatus { get; set; }
        public string TarefaTitulo { get; set; }


        //private string _TarefaTitulo { get; set; }
        //public string TarefaTitulo
        //{
        //    get { return _TarefaTitulo; }
        //    set
        //    {
        //        _TarefaTitulo = value;
        //        NotifyPropertyChanged("TarefaTitulo");
        //    }
        //}

        public string TarefaDetalhes { get; set; }
        public string TarefaPrioridade { get; set; }
        public DateTime TarefaCadastro { get; set; }
        public DateTime TarefaPrazoDate { get; set; }
        public TimeSpan TarefaPrazoHour { get; set; }

        public Tarefa()
        {
            TarefaPrazoDate = DateTime.Now;
        }
    }
}
