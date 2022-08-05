using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados
{
    public interface IRepositorioPlanoOrm : IRepositorioBaseOrm<Plano>
    {
        public Plano SelecionarPorValor(double valor);
        public Plano SelecionarPorGrupo(string valor);
    }
}
