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
        public List<Tarefa> testeTable()
        {
            return _connection.Table<Tarefa>().ToList();
        }
        public void InsertT (Tarefa tarefa)
        {
            _connection.Insert(tarefa);
        }
        public List<Tarefa> GetT()
        {
            return _connection.Table<Tarefa>().ToList();
        }
        //TODO - ATUALIZAR TAREFA //_connection.Table<Tarefa>().Where(a => a.IdTarefa == idT).FirstOrDefault();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
