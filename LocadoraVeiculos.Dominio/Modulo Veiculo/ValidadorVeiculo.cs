using FluentValidation;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraVeiculos.Dominio.Modulo_Veiculo
{
    public class ValidadorVeiculo : ValidadorBase<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .NotEmpty().WithMessage("'Modelo' não pode ser vazio")
                .MinimumLength(2).WithMessage("'Modelo' inválido, mínimo 2 caracteres");
            RuleFor(x => x.Placa)
                .NotEmpty().WithMessage("'Placa' não pode ser vazio")
                .MinimumLength(7).WithMessage("'Placa' inválido");
            RuleFor(x => x.Cor).NotEmpty().WithMessage("'Cor' não pode ser vazio");
            RuleFor(x => x.Ano)
                .NotEmpty().WithMessage("'Ano' não pode ser vazio");
                
            RuleFor(x => x.TipoCombustivel).NotEmpty().WithMessage("'Tipo Combustivel' não pode ser vazio");
            RuleFor(x => x.CapacidadeTanque).NotEmpty().WithMessage("'Capacidade Tanque' não pode ser vazio");
            RuleFor(x => x.GrupoPertencente).NotEmpty().WithMessage("'Grupo Percentente' não pode ser vazio");
            RuleFor(x => x.StatusVeiculo).NotEmpty().WithMessage("'Status Veiculo' não pode ser vazio");
            RuleFor(x => x.QuilometragemAtual)
                .NotEmpty().WithMessage("'Quilometragem Atual' não pode ser vazio")
                .GreaterThan(0).WithMessage("'Quilometragem Atual' inválido"); 

            RuleFor(x => x.Foto).NotEmpty().WithMessage("'Foto' não pode ser vazio");
        }
    }
}
