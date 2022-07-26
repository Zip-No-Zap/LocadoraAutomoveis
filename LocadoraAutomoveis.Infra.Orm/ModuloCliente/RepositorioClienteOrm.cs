using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioOrmCliente
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Cliente> dbsetClientes;

        public void Inserir(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente registro)
        {
            throw new NotImplementedException();
        }

       
        public Cliente SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente SelecionarPorParametro(string valor)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> SelecionarTodos(bool verificador)
        {
            throw new NotImplementedException();
        }
    }
}
