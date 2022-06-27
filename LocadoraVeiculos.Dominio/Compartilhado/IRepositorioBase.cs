using FluentValidation.Results;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase<T>
    {
        ValidationResult Inserir(T entidade);
        ValidationResult Editar(T entidade);
        ValidationResult Excluir(T entidade);
        List<T> SelecionarTodos();
        T SelecionarPorId(int numero);
    }
}
