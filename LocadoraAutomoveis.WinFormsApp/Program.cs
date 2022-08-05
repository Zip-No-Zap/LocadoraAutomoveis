using LocadoraAutomoveis.WinFormsApp.Compartilhado.ServiceLocator;
using GeradorTestes.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Logs;
using System.Windows.Forms;
using System;

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
            MigradorBancoDadosLocadoraAutomoveis.AtualizarBancoDados();
            
            ConfiguracaoLogger configuracao = new();
            configuracao.CriarLogger();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           var serviceLocatorAutofac = new ServiceLocatorComAutofac();
           //var serviceLocatorManual = new ServiceLocatorManual();
           Application.Run(new FormPrincipal(serviceLocatorAutofac));
        }
    }
}
