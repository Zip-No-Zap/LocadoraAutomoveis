using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    internal class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

        }
    }
}
