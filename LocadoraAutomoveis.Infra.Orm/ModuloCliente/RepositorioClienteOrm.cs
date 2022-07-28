using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : IRepositorioOrmCliente
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Cliente> dbsetClientes;

        public RepositorioClienteOrm(LocadoraAutomoveisDbContext dbContext)
        {
            _dbContext = dbContext;
            dbsetClientes = _dbContext.Set<Cliente>();
        }

        public void Inserir(Cliente registro)
        {
            dbsetClientes.Add(registro);
        }

        public void Editar(Cliente registro)
        {
            dbsetClientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            dbsetClientes.Remove(registro);
        }

        public Cliente SelecionarPorId(Guid id)
        {
            //return dbsetClientes.Find(id);
            return dbsetClientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> SelecionarTodos(bool verificador = false)
        {
            return dbsetClientes.ToList();
        }

        public Cliente SelecionarPorNome(string nome)
        {
            return dbsetClientes.FirstOrDefault(x => x.Nome == nome);
        }

        public Cliente SelecionarPorCnpj(string cnpj)
        {
            return dbsetClientes.FirstOrDefault(x => x.Cnpj == cnpj);
        }

        public Cliente SelecionarPorCpf(string cpf)
        {
            return dbsetClientes.FirstOrDefault(x => x.Cpf == cpf);
        }
    }
}
