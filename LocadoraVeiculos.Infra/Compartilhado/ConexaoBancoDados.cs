using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public class ConexaoBancoDados
    {
        public SqlConnection conexao;
        public string sql;
        private readonly string endereco;


        public ConexaoBancoDados()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            endereco = configuracao.GetConnectionString("SqlServer");
        }

        public void ConectarBancoDados()
        {
           conexao = new();
           conexao.ConnectionString = endereco;
           conexao.Open();
        }

        public void DesconectarBancoDados()
        {
            conexao.Close();
        }
    }
}
