using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor
{
    public class MapeadorCondutor : MapeadorBase<Condutor>
    {
        public override void ConfigurarParametros(Condutor entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("CPF", entidade.Cpf);
            cmd.Parameters.AddWithValue("ENDERECO", entidade.Endereco);
            cmd.Parameters.AddWithValue("EMAIL", entidade.Email);
            cmd.Parameters.AddWithValue("TELEFONE", entidade.Telefone);
            cmd.Parameters.AddWithValue("CNH", entidade.Cnh);
            cmd.Parameters.AddWithValue("VENCIMENTOCNH", entidade.VencimentoCnh);

            cmd.Parameters.AddWithValue("CLIENTE_ID", entidade.Cliente.Id);
        }
       
        public override Condutor ConverterRegistro(SqlDataReader leitor)
        {
            Condutor condutor = null;
            if (leitor.Read())
            {
                var id = Guid.Parse(leitor["CONDUTOR_ID"].ToString());
                var nome = Convert.ToString(leitor["CONDUTOR_NOME"]);
                var cpf = Convert.ToString(leitor["CONDUTOR_CPF"]);
                var cnh = Convert.ToString(leitor["CONDUTOR_CNH"]);
                var vencimentoCnh = Convert.ToDateTime(leitor["CONDUTOR_VENCIMENTOCNH"]);
                var email = Convert.ToString(leitor["CONDUTOR_EMAIL"].ToString());
                var telefone = Convert.ToString(leitor["CONDUTOR_TELEFONE"]);
                var endereco = Convert.ToString(leitor["CONDUTOR_ENDERECO"]);

                condutor = new Condutor();

                condutor.Id = id;
                condutor.Nome = nome;
                condutor.Cpf = cpf;
                condutor.Cnh = cnh;
                condutor.VencimentoCnh = vencimentoCnh;
                condutor.Email = email;
                condutor.Telefone = telefone;
                condutor.Endereco = endereco;

                condutor.Cliente = new MapeadorCliente().ConverterRegistro(leitor);
            }

            return condutor;
        }
        public override void DefinirParametroValidacao(string campoBd, Condutor entidade, SqlCommand cmd, string propriedade)
        {
            switch (propriedade)
            {
                case "NOME":
                    cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Nome);
                    break;

                case "CPF":
                    cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Cpf);
                    break;

                case "CNH":
                    cmd.Parameters.AddWithValue(campoBd.ToUpper(), entidade.Cnh);
                    break;

                default:
                    break;
            }
        }

        public override List<Condutor> LerTodos(SqlDataReader leitor)
        {
            List<Condutor> condutores = new();

            while (leitor.Read())
            {
                var id = Guid.Parse(leitor["CONDUTOR_ID"].ToString());
                var nome = Convert.ToString(leitor["CONDUTOR_NOME"]);
                var cpf = Convert.ToString(leitor["CONDUTOR_CPF"]);
                var cnh = Convert.ToString(leitor["CONDUTOR_CNH"]);
                var vencimentoCnh = Convert.ToDateTime(leitor["CONDUTOR_VENCIMENTOCNH"]);
                var email = Convert.ToString(leitor["CONDUTOR_EMAIL"].ToString());
                var telefone = Convert.ToString(leitor["CONDUTOR_TELEFONE"]);
                var endereco = Convert.ToString(leitor["CONDUTOR_ENDERECO"]);

                var clienteId = Guid.Parse(leitor["CONDUTOR_CLIENTE_ID"].ToString());
                string clienteNome = Convert.ToString(leitor["CLIENTE_NOME"]);
                string clienteCpf = Convert.ToString(leitor["CLIENTE_CPF"]);
                string clienteCnpj = Convert.ToString(leitor["CLIENTE_CNPJ"]);
                string clienteEndereco = Convert.ToString(leitor["CLIENTE_ENDERECO"]);
                int clienteTipo = Convert.ToInt32(leitor["CLIENTE_TIPOCLIENTE"]);
                string clienteEmail = Convert.ToString(leitor["CLIENTE_EMAIL"]);
                string clienteTelefone = Convert.ToString(leitor["CLIENTE_TELEFONE"]);

                Condutor condutor = new Condutor();
                condutor.Id = id;
                condutor.Nome = nome;
                condutor.Cpf = cpf;
                condutor.Cnh = cnh;
                condutor.VencimentoCnh = vencimentoCnh;
                condutor.Email = email;
                condutor.Telefone = telefone;
                condutor.Endereco = endereco;

                condutor.Cliente = new()
                {
                    Id = clienteId,
                    Nome = clienteNome,
                    Cpf = clienteCpf,
                    Cnpj = clienteCnpj,
                    Endereco = clienteEndereco,
                    Email = clienteEmail,
                    Telefone = clienteTelefone
                };

                switch (clienteTipo)
                {
                    case 0:
                        condutor.Cliente.TipoCliente = EnumTipoCliente.PessoaFisica;
                        break;

                    case 1:
                        condutor.Cliente.TipoCliente = EnumTipoCliente.PessoaJuridica;
                        break;

                    default:
                        break;
                }

                condutores.Add(condutor);
            }

            return condutores;
        }
    }
}
