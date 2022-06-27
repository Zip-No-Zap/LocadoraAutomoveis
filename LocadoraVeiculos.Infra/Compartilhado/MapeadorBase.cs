using LocadoraVeiculos.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract List<T> LerTodos(SqlDataReader leitor);

        public abstract T LerUnico(SqlDataReader leitor);

        public abstract void DefinirParametros(T entidade, SqlCommand cmd);
    }
}
