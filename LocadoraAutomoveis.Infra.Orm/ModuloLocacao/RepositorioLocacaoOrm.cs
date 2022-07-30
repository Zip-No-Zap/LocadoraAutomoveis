﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;



namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioOrmLocacao
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Locacao> dbsetLocacaos;

        public RepositorioLocacaoOrm(LocadoraAutomoveisDbContext dbContext)
        {
            dbsetLocacaos = dbContext.Set<Locacao>();
        }

        public void Inserir(Locacao registro)
        {
            dbsetLocacaos.Add(registro);
        }

        public void Editar(Locacao registro)
        {
            dbsetLocacaos.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            dbsetLocacaos.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return dbsetLocacaos.FirstOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos(bool incluir = true)
        {
            return dbsetLocacaos
                .Include(x => x.ClienteLocacao)
                .Include(x => x.CondutorLocacao)
                .Include(x => x.VeiculoLocacao)
                .Include(x => x.Grupo)
                .Include(x => x.PlanoLocacao)
                .Include(x => x.ItensTaxa)
                .ToList();
        }

        public Locacao SelecionarPorAlgo(string valor)
        {
            return dbsetLocacaos.FirstOrDefault(x => x.CondutorLocacao.Cpf == valor);
        }

        public void RegistrarDevolucao(Locacao locacao)
        {

            // fazer
        }
    }

}
