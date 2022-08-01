using Microsoft.Extensions.Configuration;
using System.IO;
using Serilog;

namespace LocadoraAutomoveis.Infra.Logs
{
    public class ConfiguracaoLogger
    {
        public ConfiguracaoLogger()
        {
            CriarLoggerGasolina();
            CriarLoggerDiesel();
            CriarLoggerAlcool();
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

        public void CriarLoggerGasolina()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var diretorioGasolina = configuracao
                .GetSection("ConfiguracaoGasolina")
                .GetSection("Preco")
                .Value;

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Debug()
               .WriteTo.File(diretorioGasolina + "Log.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();

            ConfiguracaoLogs = new ConfiguracaoLogs { PrecoGasolina = diretorioGasolina };
        }

        public void CriarLoggerDiesel()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var diretorioDiesel = configuracao
             .GetSection("ConfiguracaoDiesel")
             .GetSection("Preco")
             .Value;

            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Debug()
              .WriteTo.File(diretorioDiesel + "Log.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();

            ConfiguracaoLogs = new ConfiguracaoLogs { PrecoDiesel = diretorioDiesel };
        }

        public void CriarLoggerAlcool()
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("ConfiguracaoAplicacao.json")
               .Build();

            var diretorioAlcool = configuracao
                .GetSection("ConfiguracaoAlcool")
                .GetSection("Preco")
                .Value;

            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Debug()
             .WriteTo.Debug()
             .WriteTo.File(diretorioAlcool + "Log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();

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
