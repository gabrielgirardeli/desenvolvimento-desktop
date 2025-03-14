using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultApps.Windows
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SplashScreen splashScreen = new SplashScreen(); 
            splashScreen.ShowDialog();
            Application.Run(new Principal());
            Application.EnableVisualStyles();
            
            
        }
    }
}
