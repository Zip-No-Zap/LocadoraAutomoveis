using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;


namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public interface IRepositorioOrmLocacao : IRepositorioOrmBase<Locacao>
    {
        public void RegistrarDevolucao(Locacao locacao);
        public Locacao SelecionarPorCliente(Cliente entidade);
        public Locacao SelecionarPorCondutor(Condutor entidade);
        public Locacao SelecionarPorVeiculo(Veiculo entidade);
    }
}
