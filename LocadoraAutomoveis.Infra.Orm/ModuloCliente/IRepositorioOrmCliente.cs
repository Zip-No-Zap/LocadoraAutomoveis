using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    public interface IRepositorioClienteOrm : IRepositorioBaseOrm<Cliente>
    {
        Cliente SelecionarPorNome(string nome);

        Cliente SelecionarPorCnpj(string cnpj);

        Cliente SelecionarPorCpf(string cpf);

    }
}
