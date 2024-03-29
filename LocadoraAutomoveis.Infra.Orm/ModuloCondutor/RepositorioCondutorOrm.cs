﻿using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioCondutorOrm
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Condutor> dbsetCondutor;

        public RepositorioCondutorOrm(IContextoPersistencia dbContext)
        {
            _dbContext =(LocadoraAutomoveisDbContext) dbContext;
            dbsetCondutor = _dbContext.Set<Condutor>();
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
            //return dbsetCondutor.Find(id); // busca no cache somente
        }
       
        public List<Condutor> SelecionarTodos(bool incluir = true)
        {
            return dbsetCondutor
                .Include(x => x.Cliente)
                .ToList();
        }

        public Condutor SelecionarPorNome(string nome)
        {
            return dbsetCondutor.FirstOrDefault(x => x.Nome == nome);
        }

        public Condutor SelecionarPorCnh(string cnh)
        {
            return dbsetCondutor.FirstOrDefault(x => x.Cnh == cnh);
        }

        public Condutor SelecionarPorCpf(string cpf)
        {
            return dbsetCondutor.FirstOrDefault(x => x.Cpf == cpf);
        }
    }
}
