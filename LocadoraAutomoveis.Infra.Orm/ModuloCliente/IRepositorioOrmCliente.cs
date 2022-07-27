using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    public interface IRepositorioOrmCliente : IRepositorioOrmBase<Cliente>
    {
        Cliente SelecionarPorNome(string nome);

        Cliente SelecionarPorCnpj(string cnpj);

        Cliente SelecionarPorCpf(string cpf);

    }
}
