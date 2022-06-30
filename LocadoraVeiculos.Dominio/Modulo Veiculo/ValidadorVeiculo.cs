using FluentValidation;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;


namespace LocadoraVeiculos.Dominio.Modulo_Veiculo
{
    public class ValidadorVeiculo : ValidadorBase<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("'Modelo' não pode ser vazio");
            RuleFor(x => x.Placa).NotEmpty().WithMessage("'Placa' não pode ser vazio");
            RuleFor(x => x.Cor).NotEmpty().WithMessage("'Cor' não pode ser vazio");
            RuleFor(x => x.Ano).NotEmpty().WithMessage("'Ano' não pode ser vazio");
            RuleFor(x => x.TipoCombustivel).NotEmpty().WithMessage("'TipoCombustivel' não pode ser vazio");
            RuleFor(x => x.CapacidadeTanque).NotEmpty().WithMessage("'CapacidadeTanque' não pode ser vazio");
            RuleFor(x => x.GrupoPertencente).NotEmpty().WithMessage("'GrupoPercentente' não pode ser vazio");
            RuleFor(x => x.StatusVeiculo).NotEmpty().WithMessage("'StatusVeiculo' não pode ser vazio");
            RuleFor(x => x.QuilometragemAtual).NotEmpty().WithMessage("'QuilometragemAtual' não pode ser vazio");

        }
    }
}
