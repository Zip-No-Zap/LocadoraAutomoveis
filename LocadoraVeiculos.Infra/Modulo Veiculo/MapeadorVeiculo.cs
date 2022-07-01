using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override void DefinirParametroValidacao(string campoBd, Veiculo entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Veiculo> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
