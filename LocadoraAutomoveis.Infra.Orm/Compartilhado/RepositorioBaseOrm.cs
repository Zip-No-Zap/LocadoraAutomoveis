

namespace LocadoraAutomoveis.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBaseOrm
    {
        protected abstract string Sql_insercao { get; }
        protected abstract string Sql_edicao { get; }
        protected abstract string Sql_exclusao { get; }
        protected abstract string Sql_selecao_por_id { get; }
        protected abstract string Sql_selecao_todos { get; }
        public string Sql_selecao_por_parametro { get; set; }

        public string propriedadeValidar = "";
    }
}
