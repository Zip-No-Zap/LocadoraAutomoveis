﻿using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBase<T, Tmapeador, Tvalidador> where T : EntidadeBase<T>
                                                        where Tmapeador : MapeadorBase<T>, new()
                                                        where Tvalidador : ValidadorBase<T>, new()
                                                       
    {
        readonly ConexaoBancoDados conexaoBancoDados;

        protected abstract string Sql_insercao { get; }
        protected abstract string Sql_edicao { get; }
        protected abstract string Sql_exclusao { get; }
        protected abstract string Sql_selecao_por_id  {get;}
        protected abstract string Sql_selecao_todos { get; }
        public  string Sql_selecao_por_parametro { get; set; }
        public  string PropriedadeParametro { get; set; }

        public string propriedadeValidar = "";

        

        public RepositorioBase()
        {
            conexaoBancoDados = new();
        }

        public void Inserir(T entidade)
        {
            InserirRegistroBancoDados(entidade);
        }

        public void Editar(T entidade)
        {
            EditarRegistroBancoDados(entidade);
        }

        public void Excluir(T entidade)
        {
            ExcluirRegistroBancoDados(entidade);
        }

        public T SelecionarPorId(Guid id)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmdSelecao = new(Sql_selecao_por_id, conexaoBancoDados.conexao);

            cmdSelecao.Parameters.AddWithValue("ID", id);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            var selecionado = mapeador.ConverterRegistro(leitor);

            conexaoBancoDados.DesconectarBancoDados();

            return selecionado;
        }

        public List<T> SelecionarTodos()
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Selecao = new(Sql_selecao_todos, conexaoBancoDados.conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<T> funcionarios = mapeador.LerTodos(leitor);

            conexaoBancoDados.DesconectarBancoDados();

            return funcionarios;
        }

        public T SelecionarPorParametro(string parametroPropriedade, T entidade)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Selecao = new(Sql_selecao_por_parametro, conexaoBancoDados.conexao);

            mapeador.DefinirParametroValidacao(parametroPropriedade, entidade, cmd_Selecao, propriedadeValidar.ToUpper());

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            var selecionado = mapeador.ConverterRegistro(leitor);

            conexaoBancoDados.DesconectarBancoDados();

            return selecionado;
        }

        #region privates

        private void InserirRegistroBancoDados(T entidade)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Insercao = new(Sql_insercao, conexaoBancoDados.conexao);

            mapeador.ConfigurarParametros(entidade, cmd_Insercao);

            cmd_Insercao.ExecuteNonQuery();

            conexaoBancoDados.DesconectarBancoDados();
        }

        private void EditarRegistroBancoDados(T entidade)
        {
            Tmapeador mapeador = new();

            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Edicao = new(Sql_edicao, conexaoBancoDados.conexao);

            mapeador.ConfigurarParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            conexaoBancoDados.DesconectarBancoDados();
        }

        private void ExcluirRegistroBancoDados(T entidade)
        {
            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Exclusao = new(Sql_exclusao, conexaoBancoDados.conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            conexaoBancoDados.DesconectarBancoDados();
        }

        #endregion
    }
}
