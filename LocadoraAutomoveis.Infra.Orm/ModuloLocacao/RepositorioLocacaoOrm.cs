using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;



namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioLocacaoOrm
    {
        private DbSet<Locacao> dbsetLocacoes;
        private readonly LocadoraAutomoveisDbContext _dbContext;

        public RepositorioLocacaoOrm(IContextoPersistencia dbContext)
        {
            _dbContext = (LocadoraAutomoveisDbContext)dbContext;
            dbsetLocacoes = _dbContext.Set<Locacao>();
        }

        public void Inserir(Locacao registro)
        {
            dbsetLocacoes.Add(registro);
        }

        public void Editar(Locacao registro)
        {
            dbsetLocacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            dbsetLocacoes.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return dbsetLocacoes.FirstOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos(bool incluir = true)
        {
            return dbsetLocacoes
                .Include(x => x.ClienteLocacao)
                .Include(x => x.CondutorLocacao)
                .Include(x => x.VeiculoLocacao)
                .Include(x => x.VeiculoLocacao.GrupoPertencente)
                .Include(x => x.Grupo)
                .Include(x => x.PlanoLocacao)
                .Include(x => x.ItensTaxa)
                .ToList();
        }

        public void RegistrarDevolucao(Locacao locacao)
        {
            //TODO : fazer RegistrarDevolucao
        }

        public Locacao SelecionarPorCliente(Cliente entidade)
        {
            return dbsetLocacoes.FirstOrDefault(x => x.ClienteLocacao.Equals(entidade));
        }

        public Locacao SelecionarPorCondutor(Condutor entidade)
        {
            return dbsetLocacoes.FirstOrDefault(x => x.CondutorLocacao.Equals(entidade));
        }

        public Locacao SelecionarPorVeiculo(Veiculo entidade)
        {
            return dbsetLocacoes.FirstOrDefault(x => x.VeiculoLocacao.Equals(entidade));
        }
    }
}
