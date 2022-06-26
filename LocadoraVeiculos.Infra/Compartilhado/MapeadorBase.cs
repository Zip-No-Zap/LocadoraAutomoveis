using LocadoraVeiculos.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        protected abstract List<T> LerTodos(SqlDataReader leitor);

        protected abstract T LerUnico(SqlDataReader leitor);
    }
}
