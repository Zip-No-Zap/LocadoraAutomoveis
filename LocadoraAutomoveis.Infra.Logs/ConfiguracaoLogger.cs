using Serilog;


namespace LocadoraAutomoveis.Infra.Logs
{
    public static class ConfiguracaoLogger
    {
        public static void CriarLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()   
                .WriteTo.File(@"C:\temp\Logs\Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
