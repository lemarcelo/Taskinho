using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Taskinho.DB;
using System.IO;

[assembly:Dependency(typeof(Taskinho.iOS.iOSConfig.iOSConfig))]
namespace Taskinho.iOS.iOSConfig
{
    public class iOSConfig : IConfigDB
    {
        public string GetFolder(string dBName)
        {
            string dBPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string libLocation = Path.Combine(dBPath, "..", "Library");

            string dBLocation = Path.Combine(libLocation, dBName);

            return dBLocation;

        }
    }
}