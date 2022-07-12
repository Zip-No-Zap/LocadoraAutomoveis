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

            ConectarBancoDados();   
        }

        public void ConectarBancoDados()
        {
            conexao = new();

            conexao.ConnectionString = @"Data Source=(localDB)\MSSqlLocalDB;Initial Catalog=LocadoraAutomoveisDb;Integrated Security=True";

            conexao.Open();
        }

        public void DesconectarBancoDados()
        {
            conexao.Close();
        }
    }
}
