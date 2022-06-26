using FluentValidation.Results;
using LocadoraVeiculos.Dominio;
using System;
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



        #region metodos abstratos

        //protected void InserirRegistroBancoDados(T entidade);
        //protected void EditarRegistroBancoDados(T entidade);
        //protected void ExcluirRegistroBancoDados(T entidade);
        //protected void DefinirParametros(T entidade, SqlCommand cmd_Insercao);
        //protected ValidationResult Validar(T entidade);
        //protected List<T> LerTodos(SqlDataReader leitor);
        //protected T LerUnico(SqlDataReader leitor);
        //protected bool VerificarDuplicidade(T entidade);

        #endregion
    }
}
