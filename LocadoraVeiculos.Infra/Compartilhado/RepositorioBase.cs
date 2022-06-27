using FluentValidation.Results;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBase<T, Tmapeador> where T : EntidadeBase<T>//, IRepositorio<T>
                                                        where Tmapeador : MapeadorBase<T>, new()
                                                       
    {
        ConexaoBancoDados conexaoBancoDados;
        protected abstract string sql_insercao { get; }
        protected abstract string sql_edicao { get; }
        protected abstract string sql_exclusao { get; }
        protected abstract string sql_selecao_por_id  {get;}
        protected abstract string sql_selecao_todos { get; }

        public RepositorioBase()
        {
            conexaoBancoDados = new();
        }

        public ValidationResult Inserir(T entidade, string sqlInsercao)
        {
            if (VerificarDuplicidade(entidade) == true)
                return null;

            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade, sqlInsercao);

            return resultado;
        }

        public ValidationResult Editar(T entidade, string sqlEdicao)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade, sqlEdicao);

            return resultado;
        }

        public ValidationResult Excluir(T entidade, string sqExclusao)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade, sqExclusao);

            return resultado;
        }

        public T SelecionarPorId(T entidade, string sqlSelecaoPorId)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmdSelecao = new(sqlSelecaoPorId, conexaoBancoDados.conexao);

            cmdSelecao.Parameters.AddWithValue("ID", entidade.Id);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            var selecionado = mapeador.LerUnico(leitor);

            conexaoBancoDados.DesconectarBancoDados();

            return selecionado;
        }

        public List<T> SelecionarTodos(string sqlSelecaoTodos)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Selecao = new(sqlSelecaoTodos, conexaoBancoDados.conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<T> funcionarios = mapeador.LerTodos(leitor);

            conexaoBancoDados.DesconectarBancoDados();

            return funcionarios;
        }

        #region abstracts

        protected abstract bool VerificarDuplicidade(T entidade);

       #endregion

        #region privates

        private void InserirRegistroBancoDados(T entidade, string sqlInsercao)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Insercao = new(sqlInsercao, conexaoBancoDados.conexao);

            mapeador.DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            conexaoBancoDados.DesconectarBancoDados();
        }

        private void EditarRegistroBancoDados(T entidade, string sqlEdicao)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Edicao = new(sqlEdicao, conexaoBancoDados.conexao);

            mapeador.DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            conexaoBancoDados.DesconectarBancoDados();
        }

        private void ExcluirRegistroBancoDados(T entidade, string sqlExclusao)
        {
            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Exclusao = new(sqlExclusao, conexaoBancoDados.conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            conexaoBancoDados.DesconectarBancoDados();
        }

        private ValidationResult Validar(T entidade)
        {
            return new ValidadorBase<T>().Validate(entidade);
        }

        #endregion
    }
}
