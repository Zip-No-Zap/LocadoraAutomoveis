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
        public override void DefinirParametros(Veiculo entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Veiculo> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Veiculo LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
