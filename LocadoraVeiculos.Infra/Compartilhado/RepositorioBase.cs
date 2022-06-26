using FluentValidation.Results;
using LocadoraVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>, IRepositorio<T>
    {
        ConexaoBancoDados conexaoBancoDados;

        public RepositorioBase()
        {
            conexaoBancoDados = new();
        }

        public ValidationResult Inserir(T entidade, string sql)
        {
            if (VerificarDuplicidade(entidade) == true)
                return null;

            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade, sql);

            return resultado;
        }

        protected abstract bool VerificarDuplicidade(T entidade);

        protected abstract ValidationResult Validar(T entidade);

        protected abstract void DefinirParametros(T entidade, SqlCommand cmd);

        private void InserirRegistroBancoDados(T entidade, string sql)
        {
            conexaoBancoDados.ConectarBancoDados();

            SqlCommand cmd_Insercao = new(sql, conexaoBancoDados.conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            conexaoBancoDados.DesconectarBancoDados();
        }


    }
}
