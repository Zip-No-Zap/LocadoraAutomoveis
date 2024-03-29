﻿using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Dominio.Modulo_Cliente;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Infra.Orm.ModuloLocacao
{
    public interface IRepositorioLocacaoOrm : IRepositorioBaseOrm<Locacao>
    {
        public Locacao SelecionarPorCliente(Cliente entidade);
        public Locacao SelecionarPorCondutor(Condutor entidade);
        public Locacao SelecionarPorVeiculo(Veiculo entidade);
        public void ExcluirFechadas(List<Locacao> registros);
    }
}
