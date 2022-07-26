using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioOrmCondutor
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Condutor> dbsetPlanos;

        public void Inserir(Condutor registro)
        {
            throw new NotImplementedException();
        }
        public void Editar(Condutor registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Condutor registro)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Condutor SelecionarPorParametro(string valor)
        {
            throw new NotImplementedException();
        }

        public List<Condutor> SelecionarTodos(bool verificador)
        {
            throw new NotImplementedException();
        }
    }
}
