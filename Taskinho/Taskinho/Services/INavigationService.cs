 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taskinho.Services
{
    public interface INavigationService
    {
        Task NavigationToCadastro();
        Task NavigationToPrincipal();
        Task BackToPrincipal();
    }
}
