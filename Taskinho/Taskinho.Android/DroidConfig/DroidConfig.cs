using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Taskinho.DB;
using System.IO;

[assembly: Dependency(typeof(Taskinho.Droid.DroidConfig.DroidConfig))]
namespace Taskinho.Droid.DroidConfig
{
    public class DroidConfig : IConfigDB
    {
        public string GetFolder(string dBName)
        {
            string dBPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string dBLocation = Path.Combine(dBPath, dBName);

            return dBLocation;
        }
    }
}