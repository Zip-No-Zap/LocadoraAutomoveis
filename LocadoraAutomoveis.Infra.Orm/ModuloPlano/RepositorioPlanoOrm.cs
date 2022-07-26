using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraVeiculos.Infra.BancoDados;

namespace LocadoraAutomoveis.Infra.Orm.ModuloPlano
{
    public class RepositorioPlanoOrm : IRepositorioOrmPlano
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Plano> dbsetPlanos;

        public RepositorioPlanoOrm(LocadoraAutomoveisDbContext dbContext)
        {
            //_dbContext = dbContext;
            dbsetPlanos = dbContext.Set<Plano>();
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

        public List<Plano> SelecionarTodos(bool incluiGrupo)
        {
            if (incluiGrupo)
                return dbsetPlanos.Include(x => x.Grupo).ToList();

            return dbsetPlanos.ToList();
        }

        public Plano SelecionarPorParametro(string valor)
        {
            return dbsetPlanos.FirstOrDefault(x => x.ValorDiario_Diario == float.Parse(valor));
        }
    }
}
