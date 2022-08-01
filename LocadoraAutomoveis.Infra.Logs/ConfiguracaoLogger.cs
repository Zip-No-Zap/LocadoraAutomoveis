using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace LocadoraAutomoveis.Infra.Logs
{
    public class ConfiguracaoLogger
    {
        public void CriarLogger()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida")
                .Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File(diretorioSaida + "Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
