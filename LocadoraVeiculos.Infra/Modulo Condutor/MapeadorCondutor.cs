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
        public override void DefinirParametros(Condutor entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override void DefinirParametroValidacao(string campoBd, Condutor entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Condutor> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Condutor LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
