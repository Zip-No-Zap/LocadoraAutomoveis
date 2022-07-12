using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace LocadoraAutomoveis.Infra.Logs
{
    public static class ConfiguracaoLogger
    {
        public static void CriarLogger()
        {
            var configuracao = new ConfigurationBuilder()
                                                        //.SetBasePath(Directory.GetCurrentDirectory())
                                                        //.AddJsonFile("ConfiguracaoAplicacao.json")
                                                        .Build();

            var result = configuracao.GetSection("nome").Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()   
                .WriteTo.File(@"C:\temp\Logs\Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
