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
            if (VerificarDuplicidade(entidade) == true)
                return null;

            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(Taxa entidade)
        {
            if (VerificarDuplicidade(entidade) == true)
                return null;

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

        protected override void DefinirParametros(Taxa entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("DESCRICAO", entidade.Descricao);
            cmd.Parameters.AddWithValue("TIPO", entidade.Tipo);
            cmd.Parameters.AddWithValue("VALOR", entidade.Valor);
        }

        protected override void InserirRegistroBancoDados(Taxa entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO TBTAXA
                           (
                                [DESCRICAO],    
                                [TIPO],
                                [VALOR]
                           )
                           VALUES
                           (
                                @DESCRICAO,
                                @TIPO,
                                @VALOR

                           );SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override void EditarRegistroBancoDados(Taxa entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE [TBTAXA] SET 

                                [DESCRICAO] = @DESCRICAO, 
                                [TIPO] = @TIPO,
                                [VALOR] = @VALOR

                           WHERE
		                         ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Taxa entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBTAXA WHERE ID = @ID;";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
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
            return new ValidadorTaxa().Validate(entidade);
        }

        protected override bool VerificarDuplicidade(Taxa entidade)
        {
            var taxas = SelecionarTodos();

            foreach (Taxa t in taxas)
            {
                if (t.Descricao == entidade.Descricao)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
