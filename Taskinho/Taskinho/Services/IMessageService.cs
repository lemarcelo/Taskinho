using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskinho.Model;

namespace Taskinho.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
        Task ShowAskAsync(Func<bool> method, Tarefa tarefa);
        Task ShowPage(Tarefa tarefa);
    }
}
