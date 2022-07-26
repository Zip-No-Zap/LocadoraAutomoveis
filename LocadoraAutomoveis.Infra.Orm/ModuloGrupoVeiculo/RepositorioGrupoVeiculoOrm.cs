﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoOrm : IRepositorioOrmGrupoVeiculo
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<GrupoVeiculo> dbsetGrupos;

        public RepositorioGrupoVeiculoOrm(LocadoraAutomoveisDbContext dbContext)
        {
            //_dbContext = dbContext;
            dbsetGrupos = dbContext.Set<GrupoVeiculo>();
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