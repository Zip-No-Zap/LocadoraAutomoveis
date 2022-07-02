using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Cliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                var id = Convert.ToInt32(leitor["CONDUTOR_ID"]);
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
        public override void DefinirParametroValidacao(string campoBd, Condutor entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Condutor> LerTodos(SqlDataReader leitor)
        {
            List<Condutor> condutores = new();

            while (leitor.Read())
            {
                var id = Convert.ToInt32(leitor["CONDUTOR_ID"]);
                var nome = Convert.ToString(leitor["CONDUTOR_NOME"]);
                var cpf = Convert.ToString(leitor["CONDUTOR_CPF"]);
                var cnh = Convert.ToString(leitor["CONDUTOR_CNH"]);
                var vencimentoCnh = Convert.ToDateTime(leitor["CONDUTOR_VENCIMENTOCNH"]);
                var email = Convert.ToString(leitor["CONDUTOR_EMAIL"].ToString());
                var telefone = Convert.ToString(leitor["CONDUTOR_TELEFONE"]);
                var endereco = Convert.ToString(leitor["CONDUTOR_ENDERECO"]);
                
                Condutor condutor = new Condutor();
                condutor.Id = id;
                condutor.Nome = nome;
                condutor.Cpf = cpf;
                condutor.Cnh = cnh;
                condutor.VencimentoCnh = vencimentoCnh;
                condutor.Email = email;
                condutor.Telefone = telefone;
                condutor.Endereco = endereco;

                condutor.Cliente = new MapeadorCliente().ConverterRegistro(leitor);

                condutores.Add(condutor);

            }

            return condutores;

        }

    }
}
