using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Taxa
{
    public class RepositorioTaxaEmBancoDados : ConexaoBancoDados<Taxa>, IRepositorio<Taxa>
    {
        public ValidationResult Inserir(Taxa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(Taxa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }


        public ValidationResult Excluir(Taxa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }

        public Taxa SelecionarPorId(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBTAXA WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            Taxa selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        public List<Taxa> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBTAXA";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<Taxa> taxas = LerTodos(leitor);

            DesconectarBancoDados();

            return taxas;
        }

        #region protected

        protected override void DefinirParametros(Taxa entidade, SqlCommand cmd_Insercao)
        {
            throw new NotImplementedException();
        }

        protected override void EditarRegistroBancoDados(Taxa entidade)
        {
            throw new NotImplementedException();
        }

        protected override void ExcluirRegistroBancoDados(Taxa entidade)
        {
            throw new NotImplementedException();
        }

        protected override void InserirRegistroBancoDados(Taxa entidade)
        {
            throw new NotImplementedException();
        }

        protected override List<Taxa> LerTodos(SqlDataReader leitor)
        {
            List<Taxa> taxas = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string descricao = leitor["DESCRICAO"].ToString();
                string tipo = leitor["TIPO"].ToString();
                float valor = (float)leitor["VALOR"];

                var taxa = new Taxa()
                {
                    Id = id,
                    Descricao = descricao,
                    Tipo = tipo,
                    Valor = valor
                };

                taxas.Add(taxa);
            }

            return taxas;
        }

        protected override Taxa LerUnico(SqlDataReader leitor)
        {
            Taxa taxa = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string descricao = leitor["DESCRICAO"].ToString();
                string tipo = leitor["TIPO"].ToString();
                float valor = (float)leitor["VALOR"];

                taxa = new Taxa()
                {
                    Id = id,
                    Descricao = descricao,
                    Tipo = tipo,
                    Valor = valor
                };
            }

            return taxa;
        }

        protected override ValidationResult Validar(Taxa entidade)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
