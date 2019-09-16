using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Taskinho.DB
{
    public interface IConfigDB
    {
        string GetFolder(string dBName);
    }
}
