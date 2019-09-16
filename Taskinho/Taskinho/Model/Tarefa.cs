using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

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
        public string TarefaDetalhes { get; set; }
        public string TarefaPrioridade { get; set; }
        public DateTime TarefaCadastro { get; set; }
        public DateTime TarefaPrazo { get; set; }

        public Tarefa()
        {
            TarefaTitulo = "Tarefa Teste";
            TarefaDetalhes = "Detalhes Teste";
            TarefaPrazo = DateTime.Now;
        }
    }
}
