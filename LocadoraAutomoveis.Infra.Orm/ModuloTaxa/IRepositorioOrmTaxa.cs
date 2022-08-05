using LocadoraVeiculos.Dominio.Modulo_Taxa;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxa
{
    public interface IRepositorioTaxaOrm : IRepositorioBaseOrm<Taxa>
    {
        public Taxa SelecionarPorDescricao(string valor);
    }
}
