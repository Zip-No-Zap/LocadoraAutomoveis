using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositorioOrmVeiculo
    {
        private readonly LocadoraAutomoveisDbContext _dbContext;
        private DbSet<Veiculo> dbsetVeiculos;

        public RepositorioVeiculoOrm(LocadoraAutomoveisDbContext dbContext)
        {
            dbsetVeiculos = dbContext.Set<Veiculo>();
        }

        public void Inserir(Veiculo registro)
        {
            dbsetVeiculos.Add(registro);
        }
        public void Editar(Veiculo registro)
        {
            dbsetVeiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            dbsetVeiculos.Remove(registro);
        }



        public Veiculo SelecionarPorId(Guid id)
        {
            return dbsetVeiculos.FirstOrDefault(x => x.Id == id);
        }



        public List<Veiculo> SelecionarTodos(bool verificador)
        {
            if (verificador)
                return dbsetVeiculos.Include(x => x.GrupoPertencente).ToList();

            return dbsetVeiculos.ToList();
        }

        public Veiculo SelecionarPorPlaca(string placa)
        {
            return dbsetVeiculos.FirstOrDefault(x => x.Placa == placa);
        }
    }
}
