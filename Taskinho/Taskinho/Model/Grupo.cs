using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Taskinho.Model
{
    public class Grupo
    {
        [PrimaryKey, AutoIncrement]
        public int IdGrupo { get; set; }
        public string GrupoNome { get; set; }
        public int GrupoCor { get; set; }

    }
}
