using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Funcionario
{
    public class RepositorioFuncionarioEmBancoDados : ConexaoBancoDados<Funcionario>, IRepositorio<Funcionario>
    {
        public ValidationResult Inserir(Funcionario entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(Funcionario entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Excluir(Funcionario entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }

        public Funcionario SelecionarPorId(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBFUNCIONARIO WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            Funcionario selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        public List<Funcionario> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBFUNCIONARIO";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<Funcionario> funcionarios = LerTodos(leitor);

            DesconectarBancoDados();

            return funcionarios;
        }

        #region metodos protected
        protected override void DefinirParametros(Funcionario entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("LOGIN", entidade.Login);
            cmd.Parameters.AddWithValue("SENHA", entidade.Senha);
            cmd.Parameters.AddWithValue("SALARIO", entidade.Salario);
            cmd.Parameters.AddWithValue("DATAADMISSAO", entidade.DataAdmissao);
            cmd.Parameters.AddWithValue("PERFIL", entidade.TipoPerfil);

        }

        protected override void InserirRegistroBancoDados(Funcionario entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO TBFUNCIONARIO 
                           (
                                [NOME],    
                                [LOGIN],
                                [SENHA],
                                [SALARIO],
                                [DATAADMISSAO],
                                [PERFIL],
                           )
                           VALUES
                           (
                                @NOME,
                                @LOGIN,
                                @SENHA,
                                @SALARIO,
                                @DATAADMISSAO,
                                @PERFIL
                           );SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override void EditarRegistroBancoDados(Funcionario entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE [TBFUNCIONARIO] SET 

                        [NOME] = @NOME,    
	                    [LOGIN] = @LOGIN,
                        [SENHA] = @SENHA,
                        [DATAADMISSAO] = @DATAADMISSAO,
                        [PERFIL] = @PERFIL

                   WHERE
		                 ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Funcionario entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBFUNCIONARIO WHERE ID = @ID;";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }



        protected override ValidationResult Validar(Funcionario entidade)
        {
            return new ValidadorFuncionario().Validate(entidade);
        }

        protected override List<Funcionario> LerTodos(SqlDataReader leitor)
        {
            List<Funcionario> funcionarios = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string login = leitor["LOGIN"].ToString();
                string senha = leitor["SENHA"].ToString();
                DateTime dataAdmissao = Convert.ToDateTime(leitor["DATAADMISSAO"]);

                Funcionario funcionario = new Funcionario(nome, login, senha)
                {
                    Id = id
                };

                funcionarios.Add(funcionario);
            }

            return funcionarios;
        }

        protected override Funcionario LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
