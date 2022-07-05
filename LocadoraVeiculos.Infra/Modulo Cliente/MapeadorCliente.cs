using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente entidade, SqlCommand cmd)
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
        public override Cliente ConverterRegistro(SqlDataReader leitor)
        {
            Cliente cliente = null;

            var id = Convert.ToInt32(leitor["CLIENTE_ID"]);
            var nome = Convert.ToString(leitor["CLIENTE_NOME"]);
            var cpf = Convert.ToString(leitor["CLIENTE_CPF"]);
            var cnpj = Convert.ToString(leitor["CLIENTE_CNPJ"]);
            var endereco = Convert.ToString(leitor["CLIENTE_ENDERECO"]);
            var tipoCliente = Convert.ToInt16(leitor["CLIENTE_TIPOCLIENTE"]);
            var email = Convert.ToString(leitor["CLIENTE_EMAIL"]);
            var telefone = Convert.ToString(leitor["CLIENTE_TELEFONE"]);

            cliente = new Cliente()
            {
                Id = id,
                Nome = nome, 
                Cpf = cpf, 
                Cnpj = cnpj,
                Email = email,
                Endereco = endereco, 
                Telefone = telefone, 
            };

            switch (tipoCliente)
            {
                case 0:
                    cliente.TipoCliente = EnumTipoCliente.PessoaFisica;
                    break;
                case 1:
                    cliente.TipoCliente = EnumTipoCliente.PessoaJuridica;

                    break;
                   
            }
            

            return cliente;
        }
        public override void DefinirParametroValidacao(string campoBd, Cliente entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue(campoBancoDados.ToUpper(), entidade.Nome);
        }

        public override List<Cliente> LerTodos(SqlDataReader leitor)
        {
            List<Cliente> clientes = new List<Cliente>();

            while (leitor.Read())
            {
                var id = Convert.ToInt32(leitor["CLIENTE_ID"]);
                var nome = Convert.ToString(leitor["CLIENTE_NOME"]);
                string cpf = Convert.ToString(leitor["CLIENTE_CPF"]);
                var cnpj = Convert.ToString(leitor["CLIENTE_CNPJ"]);
                var endereco = Convert.ToString(leitor["CLIENTE_ENDERECO"]);
                int tipoCliente = Convert.ToInt32(leitor["CLIENTE_TIPOCLIENTE"]);
                var email = Convert.ToString(leitor["CLIENTE_EMAIL"]);
                var telefone = Convert.ToString(leitor["CLIENTE_TELEFONE"]);
                Cliente cliente = new Cliente();

                switch (tipoCliente)
                {
                    case 0:
                        cliente.TipoCliente = EnumTipoCliente.PessoaFisica;
                        break;
                    case 1:
                        cliente.TipoCliente = EnumTipoCliente.PessoaJuridica;
                        break;
                        
                }

                cliente.Id = id;
                cliente.Nome = nome;
                cliente.Cpf = cpf;
                cliente.Cnpj = cnpj;
                cliente.Email = email;
                cliente.Endereco = endereco;
                cliente.Telefone = telefone;
                
                
                clientes.Add(cliente);
            }

            return clientes;
        }

        
    }
}
