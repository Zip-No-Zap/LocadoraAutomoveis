﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
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
            dbsetGrupos = dbContext.Set<GrupoVeiculo>();
        }

        public void Inserir(GrupoVeiculo registro)
        {
            dbsetGrupos.Add(registro);

            _dbContext.SaveChanges();
        }
        public void Editar(GrupoVeiculo registro)
        {
            dbsetGrupos.Update(registro);

            _dbContext.SaveChanges();
        }

        public void Excluir(GrupoVeiculo registro)
        {
            dbsetGrupos.Remove(registro);

            _dbContext.SaveChanges();
        }

        public GrupoVeiculo SelecionarPorId(Guid id)
        {
            //return dbsetGrupos.FirstOrDefault(x => x.Id == id);
            return dbsetGrupos.Find(id);

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
