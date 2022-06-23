using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo
{
    public class RepositorioGrupoVeiculoEmBancoDados : ConexaoBancoDados<GrupoVeiculo>, IRepositorio<GrupoVeiculo>
    {
        public ValidationResult Inserir(GrupoVeiculo entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(GrupoVeiculo entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Excluir(GrupoVeiculo entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }

        public GrupoVeiculo SelecionarPorId(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBGRUPOVEICULO WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            GrupoVeiculo selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBGRUPOVEICULO";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<GrupoVeiculo> funcionarios = LerTodos(leitor);

            DesconectarBancoDados();

            return funcionarios;
        }

        protected override void DefinirParametros(GrupoVeiculo entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOMEGRUPO", entidade.Nome);

        }

        protected override void InserirRegistroBancoDados(GrupoVeiculo entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO TBGRUPOVEICULO 
                           (
                                [NOMEGRUPO]   

                           )
                           VALUES
                           (
                                @NOME


                           );SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override void EditarRegistroBancoDados(GrupoVeiculo entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE [TBGRUPOVEICULO] SET 

                                [NOME] = @NOME    
                           WHERE
		                         ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(GrupoVeiculo entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBGRUPOVEICULO WHERE ID = @ID;";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override List<GrupoVeiculo> LerTodos(SqlDataReader leitor)
        {
            List<GrupoVeiculo> gruposVeiculos = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();

                GrupoVeiculo grupoVeiculo = new GrupoVeiculo(nome)
                {
                    Id = id


                };

                gruposVeiculos.Add(grupoVeiculo);
            }

            return gruposVeiculos;
        }

        protected override GrupoVeiculo LerUnico(SqlDataReader leitor)
        {
            GrupoVeiculo funcionario = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();


                funcionario = new GrupoVeiculo(nome)
                {
                    Id = id
                };
            }

            return funcionario;
        }

        protected override ValidationResult Validar(GrupoVeiculo entidade)
        {
            return new ValidadorGrupoVeiculo().Validate(entidade);
        }
    }
}
