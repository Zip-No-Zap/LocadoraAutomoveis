using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public interface IRepositorioOrmLocacao : IRepositorioOrmBase<Locacao>
    {
        public Locacao SelecionarPorAlgo(string valor);
    }
}
