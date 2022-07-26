

using System.Collections.Generic;
using LocadoraVeiculos.Dominio;
using System;

namespace LocadoraVeiculos.Infra.BancoDados.Compartilhado
{
    public interface IRepositorioOrmBase<T> where T : EntidadeBase<T>
    {
        void Inserir(T registro);
        void Editar(T registro);
        void Excluir(T registro);
        T SelecionarPorId(Guid id);
        List<T> SelecionarTodos(bool verificador);

    }
}
