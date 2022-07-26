using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;


namespace LocadoraAutomoveis.Infra.Orm.ModuloFuncionario
{
    public interface IRepositorioOrmFuncionario : IRepositorioOrmBase<Funcionario>
    {
        Funcionario SelecionarPorLogin(string valor);

        Funcionario SelecionarPorNome(string valor);

    }
}
