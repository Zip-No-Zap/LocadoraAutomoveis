using LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator;
using System;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceLocatorAutofac = new ServiceLocatorComAutofac();
            Application.Run(new FormPrincipal(serviceLocatorAutofac));
        }
    }
}
