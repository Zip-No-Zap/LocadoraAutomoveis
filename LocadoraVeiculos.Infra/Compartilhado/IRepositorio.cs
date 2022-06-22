using FluentValidation.Results;
using LocadoraVeiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        ValidationResult Inserir(T entidade);
        ValidationResult Editar(T entidade);
        ValidationResult Excluir(T entidade);
        List<T> SelecionarTodos();
        T SelecionarPorId(int numero);
    }
}
