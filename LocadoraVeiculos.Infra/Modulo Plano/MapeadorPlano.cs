using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Plano
{
    public class MapeadorPlano : MapeadorBase<Plano>
    {
        public override void DefinirParametros(Plano entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override void DefinirParametroValidacao(string campoBd, Plano entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Plano> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Plano LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
