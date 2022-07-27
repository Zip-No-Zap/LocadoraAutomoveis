using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public interface IRepositorioOrmCondutor : IRepositorioOrmBase<Condutor>
    {

        Condutor SelecionarPorNome(string nome);

        Condutor SelecionarPorCnh(string cnh);

        Condutor SelecionarPorCpf(string cpf);
    }
}
