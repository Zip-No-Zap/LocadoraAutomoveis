using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Funcionario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LocadoraAutomoveis.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositorioOrmFuncionario
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Funcionario> dbsetFuncionarios;

        public RepositorioFuncionarioOrm(LocadoraAutomoveisDbContext dbContext)
        {
            dbsetFuncionarios = dbContext.Set<Funcionario>();
        }

        public void Inserir(Funcionario registro)
        {
            dbsetFuncionarios.Add(registro);
        }

        public void Editar(Funcionario registro)
        {
            dbsetFuncionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            dbsetFuncionarios.Remove(registro);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            //return dbsetFuncionarioes.Find(id); // uso de cache, não gera consulta no banco
            return dbsetFuncionarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Funcionario> SelecionarTodos(bool incluir)
        {
            return dbsetFuncionarios.ToList();
        }

        public Funcionario SelecionarPorLogin(string valor)
        {
            return dbsetFuncionarios.FirstOrDefault(x => x.Login == valor);
        }

        public Funcionario SelecionarPorNome(string valor)
        {
            return dbsetFuncionarios.FirstOrDefault(x => x.Nome == valor);
        }
    }
}
