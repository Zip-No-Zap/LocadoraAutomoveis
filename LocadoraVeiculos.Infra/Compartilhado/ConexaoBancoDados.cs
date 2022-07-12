using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public class ConexaoBancoDados
    {
        public SqlConnection conexao;
        public string sql;


        public ConexaoBancoDados()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ArquivoConfiguracao")
                .Build();

            conexao.ConnectionString = configuracao.GetConnectionString("SqlServer");
            //@"Data Source=(localDB)\MSSqlLocalDB;Initial Catalog=LocadoraAutomoveisDb;Integrated Security=True";
        }

        public void ConectarBancoDados()
        {
            conexao = new();

            conexao.Open();
        }

        public void DesconectarBancoDados()
        {
            conexao.Close();
        }
    }
}
