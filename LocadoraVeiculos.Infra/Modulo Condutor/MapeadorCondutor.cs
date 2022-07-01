using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
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

        public override void DefinirParametroValidacao(string campoBd, Condutor entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Condutor> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Condutor ConverterRegistro(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
