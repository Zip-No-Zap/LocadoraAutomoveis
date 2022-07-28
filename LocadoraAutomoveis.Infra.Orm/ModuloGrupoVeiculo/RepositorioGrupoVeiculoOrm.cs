using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoOrm : IRepositorioOrmGrupoVeiculo
    {
        private DbSet<GrupoVeiculo> dbsetGrupos;

        private readonly LocadoraAutomoveisDbContext _dbContext;

        public RepositorioGrupoVeiculoOrm(LocadoraAutomoveisDbContext dbContext)
        {
            _dbContext = dbContext;
            dbsetGrupos = _dbContext.Set<GrupoVeiculo>();
        }

        public void Inserir(GrupoVeiculo registro)
        {
            dbsetGrupos.Add(registro);
        }
        public void Editar(GrupoVeiculo registro)
        {
            dbsetGrupos.Update(registro);
        }

        public void Excluir(GrupoVeiculo registro)
        {
            dbsetGrupos.Remove(registro);
        }

        public GrupoVeiculo SelecionarPorId(Guid id)
        {
            return dbsetGrupos.FirstOrDefault(x => x.Id == id);
            //return dbsetGrupos.Find(id) // busca só no cache

        }

        public GrupoVeiculo SelecionarPorNome(string grupoVeiculo)
        {
            return dbsetGrupos.FirstOrDefault(x => x.Nome == grupoVeiculo);
        }

        public List<GrupoVeiculo> SelecionarTodos(bool verificador = false)
        {
            return dbsetGrupos.ToList();
        }
    }
}
