 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskinho.Model;

namespace Taskinho.Services
{
    public interface INavigationService
    {
        Task NavigationToCadastro(Func<bool> metodo= null, Tarefa tarefa= null);
        Task NavigationToPrincipal();
        Task BackToPrincipal();
        Task BackPopUp();
    }
}
