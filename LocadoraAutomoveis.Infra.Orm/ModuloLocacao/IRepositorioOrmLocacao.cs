using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public interface IRepositorioOrmLocacao : IRepositorioOrmBase<Locacao>
    {
        public void RegistrarDevolucao(Locacao locacao);
        public Locacao SelecionarPorAlgo(string valor);
    }
}
