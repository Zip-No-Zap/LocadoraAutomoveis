using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioOrmCondutor
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Condutor> dbsetCondutor;

        public RepositorioCondutorOrm(LocadoraAutomoveisDbContext dbContext)
        {
            dbsetCondutor = dbContext.Set<Condutor>();
        }
        public void Inserir(Condutor registro)
        {
            dbsetCondutor.Add(registro);
        }
        public void Editar(Condutor registro)
        {
            dbsetCondutor.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            dbsetCondutor.Remove(registro);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return dbsetCondutor.FirstOrDefault(x => x.Id == id);
        }
       
        public List<Condutor> SelecionarTodos(bool incluir = false)
        {
            return dbsetCondutor.ToList();
        }
    }
}
