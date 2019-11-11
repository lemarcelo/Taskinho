using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Taskinho.Model;
using Xamarin.Forms;

namespace Taskinho.DB
{
    public class LocalDB : IDisposable
    {
        private SQLiteConnection _connection;

        public LocalDB()
        {
            var depDBConfig = DependencyService.Get<IConfigDB>();
            string dbPath = depDBConfig.GetFolder("TaskinhoLocalDB.sqlite");
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Tarefa>();
            _connection.CreateTable<Grupo>();
            //TODO - IS NULL OR EPNTY PRA CRIAR O BANCO ->https://youtu.be/y9wACg61r4M?t=511
        }
        public Tarefa GetById(int id)
        {
            return _connection.Get<Tarefa>(id);
        }
        public void InsertT (Tarefa tarefa)
        {
            _connection.Insert(tarefa);
        }
        public List<Tarefa> GetT()
        {
            return _connection.Table<Tarefa>().OrderByDescending(t => t.IdTarefa).ToList();
        }
        //TODO - UPDATE TAREFA //_connection.Table<Tarefa>().Where(a => a.IdTarefa == idT).FirstOrDefault();
        public int UpdateT(Tarefa tarefa)
        {
            return _connection.Update(tarefa);
        }
        //TODO - DELETAR TAREFA
        public void DeleteT(Tarefa tarefa)
        {
            _connection.Delete<Tarefa>(tarefa.IdTarefa);
        }
        //TODO - CADASTRAR NOVO GRUPO
        public int InsertG()
        {
            return 0;
        }

        //TODO - SELECIONAR LISTA DE GRUPOS NO CADASTRO DE GRUPOS
        public List<Grupo> GetG()
        {
            return null;
        }
        //TODO - ATUALIZAR GRUPO
        public int UpdateG(Grupo grupo)
        {
            return 0;
        }
        //TODO - DELETAR GRUPO
        public void DeleteG(Grupo grupo)
        {
            
        }
        public void Realized(Tarefa tarefa)
        {
            if (tarefa.TarefaStatus == "r")
            {
                _connection.Update(new Tarefa
                {
                    IdTarefa = tarefa.IdTarefa,
                    TarefaStatus = "p"
                });
            }
            else
            {
                _connection.Update(new Tarefa
                {
                    IdTarefa = tarefa.IdTarefa,
                    TarefaStatus = "r"
                });
            }


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
