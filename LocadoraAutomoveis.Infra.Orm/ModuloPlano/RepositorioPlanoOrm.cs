using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraVeiculos.Infra.BancoDados;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlano
{
    public class RepositorioPlanoOrm : IRepositorioPlanoOrm
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Plano> dbsetPlanos;

        public RepositorioPlanoOrm(IContextoPersistencia dbContext)
        {
            _dbContext =(LocadoraAutomoveisDbContext) dbContext;
            dbsetPlanos = _dbContext.Set<Plano>();
        }

        public void Inserir(Plano registro)
        {
            dbsetPlanos.Add(registro);
        }

        public void Editar(Plano registro)
        {
            dbsetPlanos.Update(registro);
        }

        public void Excluir(Plano registro)
        {
            dbsetPlanos.Remove(registro);
        }

        public Plano SelecionarPorId(Guid id)
        {
            //return dbsetPlanoes.Find(id); // uso de cache, não gera consulta no banco
            return dbsetPlanos.FirstOrDefault(x => x.Id == id);
        }

        public List<Plano> SelecionarTodos(bool incluiGrupo = true)
        {
            return dbsetPlanos
                .Include(x => x.Grupo)
                .ToList();
        }

        public Plano SelecionarPorValor(double valor)
        {
            return dbsetPlanos.FirstOrDefault(x => x.ValorDiario_Diario == valor);
        }

        public Plano SelecionarPorGrupo(string valor)
        {
            return dbsetPlanos.FirstOrDefault(x => x.Grupo.Nome == valor);
        }
    }
}
