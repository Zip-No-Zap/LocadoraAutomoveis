using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;

namespace LocadoraAutomoveis.Infra.Logs
{
    public class ConfiguracaoLogger
    {
        public ConfiguracaoLogger()
        {
            CriarLoggerCombustivel();
        }

        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

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

        public void CriarLoggerCombustivel()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var diretorioGasolina = configuracao
                .GetSection("ConfiguracaoCombustivel")
                .GetSection("Preco")
                .Value;

            var diretorioDiesel = configuracao
                .GetSection("ConfiguracaoDiesel")
                .GetSection("Preco")
                .Value;

            var diretorioAlcool = configuracao
                .GetSection("ConfiguracaoAlcool")
                .GetSection("Preco")
                .Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File(diretorioGasolina + "Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.File(diretorioDiesel + "Log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.File(diretorioAlcool + "Log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            ConfiguracaoLogs = new ConfiguracaoLogs { PrecoGasolina = diretorioGasolina };
            ConfiguracaoLogs = new ConfiguracaoLogs { PrecoDiesel = diretorioDiesel };
            ConfiguracaoLogs = new ConfiguracaoLogs { PrecoAlcool = diretorioAlcool };
        }

    }

    public class ConfiguracaoLogs
    {
        public string PrecoGasolina { get; set; }
        public string PrecoDiesel { get; set; }
        public string PrecoAlcool { get; set; }
    }
}
