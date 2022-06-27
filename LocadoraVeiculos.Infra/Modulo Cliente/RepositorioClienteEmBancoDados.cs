using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente
{
    public class RepositorioClienteEmBancoDados : ConexaoBancoDados<Cliente>, IRepositorio<Cliente>
    {
        public ValidationResult Inserir(Cliente entidade)
        {
            if (VerificarDuplicidade(entidade) == true)
                return null;

            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }
        public ValidationResult Editar(Cliente entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Excluir(Cliente entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }

        public Cliente SelecionarPorId(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBCLIENTE WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            Cliente selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        public List<Cliente> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBCLIENTE";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<Cliente> clientes = LerTodos(leitor);

            DesconectarBancoDados();

            return clientes;
        }

        protected override void DefinirParametros(Cliente entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("CPF", entidade.Cpf);
            cmd.Parameters.AddWithValue("CNPJ", entidade.Cnpj);
            cmd.Parameters.AddWithValue("ENDERECO", entidade.Endereco);
            cmd.Parameters.AddWithValue("TIPOCLIENTE", entidade.TipoCliente);
            cmd.Parameters.AddWithValue("CNH", entidade.Cnh);
            cmd.Parameters.AddWithValue("EMAIL", entidade.Email);
            cmd.Parameters.AddWithValue("TELEFONE", entidade.Telefone);
        }

        protected override void InserirRegistroBancoDados(Cliente entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO TBCLIENTE 
                           (
                                [NOME],    
                                [CPF],
                                [CNPJ],   
                                [ENDERECO],
                                [TIPOCLIENTE],
                                [CNH],
                                [EMAIL],
                                [TELEFONE]  
                           )
                           VALUES
                           (
                                @NOME,    
                                @CPF,
                                @CNPJ,   
                                @ENDERECO,
                                @TIPOCLIENTE,
                                @CNH,
                                @EMAIL,
                                @TELEFONE

                           );SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override void EditarRegistroBancoDados(Cliente entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE [TBCLIENTE] SET 

                                [NOME] = @NOME,
                                [CPF] = @CPF,
                                [CNPJ] = @CNPJ,
                                [ENDERECO] = @ENDERECO,
                                [TIPOCLIENTE] = @TIPOCLIENTE,
                                [CNH] = @CNH,
                                [EMAIL] = @EMAIL,
                                [TELEFONE] = @TELEFONE

                   WHERE
		                 ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Cliente entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBCLIENTE WHERE ID = @ID;";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override List<Cliente> LerTodos(SqlDataReader leitor)
        {
            List<Cliente> clientes = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string cpf = leitor["CPF"].ToString();
                string cnpj = leitor["CNPJ"].ToString();
                string endereco = leitor["ENDERECO"].ToString();
                string tipoCliente = leitor["TIPOCLIENTE"].ToString();
                string cnh = leitor["CNH"].ToString();
                string email = leitor["EMAIL"].ToString();
                string telefone = leitor["TELEFONE"].ToString();


                Cliente cliente = new Cliente(nome, cpf, cnpj, cnh, email, endereco, telefone)
                {
                    Id = id
                };

                clientes.Add(cliente);
            }

            return clientes;
        }

        protected override Cliente LerUnico(SqlDataReader leitor)
        {
            Cliente cliente = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string cpf = leitor["CPF"].ToString();
                string cnpj = leitor["CNPJ"].ToString();
                string endereco = leitor["ENDERECO"].ToString();
                string tipoCliente = leitor["TIPOCLIENTE"].ToString();
                string cnh = leitor["CNH"].ToString();
                string email = leitor["EMAIL"].ToString();
                string telefone = leitor["TELEFONE"].ToString();

                cliente = new Cliente(nome, cpf, cnpj, cnh, email, endereco, telefone)
                {
                    Id = id
                };
            }

            return cliente;
        }

        protected override ValidationResult Validar(Cliente entidade)
        {
            return new ValidadorCliente().Validate(entidade);
        }

        protected override bool VerificarDuplicidade(Cliente entidade)
        {
            var clientes = SelecionarTodos();

            foreach (Cliente c in clientes)
            {
                if (entidade.Cpf != "-" && c.Cpf == entidade.Cpf  ) 
                    return true;

                if (entidade.Cnpj != "-" && c.Cnpj == entidade.Cnpj)
                    return true;

                if (c.Cnh == entidade.Cnh) 
                    return true;
            }

            return false;
        }
    }
}
