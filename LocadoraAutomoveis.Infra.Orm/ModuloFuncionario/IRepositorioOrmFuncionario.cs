using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraAutomoveis.Infra.Orm.ModuloFuncionario
{
    public interface IRepositorioOrmFuncionario : IRepositorioOrmBase<Funcionario>
    {
        public Funcionario SelecionarPorParametroLogin(string valor);
    }
}
