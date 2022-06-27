using FluentValidation.Results;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public class ConexaoBancoDados
    {
        public SqlConnection conexao;
        public string sql;

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
