using LocadoraVeiculos.Dominio.Modulo_Plano;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraVeiculos.Infra.BancoDados
{
    public interface IRepositorioOrmPlano : IRepositorioOrmBase<Plano>
    {
        public Plano SelecionarPorValor(float valor);
        public Plano SelecionarPorGrupo(string valor);
    }
}
