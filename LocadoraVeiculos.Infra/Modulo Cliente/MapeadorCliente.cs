using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void DefinirParametros(Cliente entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("CPF", entidade.Cpf);
            cmd.Parameters.AddWithValue("CNPJ", entidade.Cnpj);
            cmd.Parameters.AddWithValue("ENDERECO", entidade.Endereco);
            cmd.Parameters.AddWithValue("TIPOCLIENTE", entidade.TipoCliente);
            cmd.Parameters.AddWithValue("EMAIL", entidade.Email);
            cmd.Parameters.AddWithValue("TELEFONE", entidade.Telefone);
        }

        public override void DefinirParametroValidacao(string campoBd, Cliente entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Cliente> LerTodos(SqlDataReader leitor)
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
                string email = leitor["EMAIL"].ToString();
                string telefone = leitor["TELEFONE"].ToString();


                Cliente cliente = new Cliente(nome, cpf, cnpj, email, endereco, telefone)
                {
                    Id = id
                };

                clientes.Add(cliente);
            }

            return clientes;
        }

        public override Cliente ConverterRegistro(SqlDataReader leitor)
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
                string email = leitor["EMAIL"].ToString();
                string telefone = leitor["TELEFONE"].ToString();

                cliente = new Cliente(nome, cpf, cnpj, email, endereco, telefone)
                {
                    Id = id
                };
            }

            return cliente;
        }
    }
}
