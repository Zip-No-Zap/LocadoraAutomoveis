using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Taxa;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LocadoraAutomoveis.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : IRepositorioTaxaOrm
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Taxa> dbsetTaxas;

        public RepositorioTaxaOrm(IContextoPersistencia dbContext)
        {
            _dbContext = (LocadoraAutomoveisDbContext)dbContext;
            dbsetTaxas = _dbContext.Set<Taxa>();
        }

        public void Inserir(Taxa registro)
        {
            dbsetTaxas.Add(registro);
        }

        public void Editar(Taxa registro)
        {
            dbsetTaxas.Update(registro);
        }

        public void Excluir(Taxa registro)
        {
            dbsetTaxas.Remove(registro);
        }

        public Taxa SelecionarPorId(Guid id)
        {
            //return dbsetTaxaes.Find(id); // uso de cache, não gera consulta no banco
            return dbsetTaxas.FirstOrDefault(x => x.Id == id);
        }

        public List<Taxa> SelecionarTodos(bool incluir = false)
        {
            return dbsetTaxas.ToList();
        }

        public Taxa SelecionarPorDescricao(string valor)
        {
            return dbsetTaxas.FirstOrDefault(x => x.Descricao == valor);
        }
    }
}
