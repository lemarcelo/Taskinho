using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Windows.Storage;
using Taskinho.DB;
using Taskinho.UWP.UWPConfig;
using System.IO;

[assembly: Dependency(typeof(UWPConfig))]
namespace Taskinho.UWP.UWPConfig
{
    public class UWPConfig : IConfigDB
    {
        public string GetFolder(string dBName)
        {
            string dBPath = ApplicationData.Current.LocalFolder.Path;

            string dBLocation = Path.Combine(dBPath, dBName);

            return dBLocation;
        }
    }
}
