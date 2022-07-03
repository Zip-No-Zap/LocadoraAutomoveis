using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Veiculo
{
    public class ServicoVeiculo
    {
        readonly RepositorioVeiculoEmBancoDados repositorioVeiculo;
        ValidadorVeiculo validadorVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo veiculo)
        {
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Inserir(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Veiculo veiculo)
        {
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Editar(veiculo);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Veiculo veiculo)
        {
            var resultadoValidacao = Validar(veiculo);

            if (resultadoValidacao.IsValid)
                repositorioVeiculo.Excluir(veiculo);

            return resultadoValidacao;
        }

        public List<Veiculo> SelecionarTodos()
        {
            return repositorioVeiculo.SelecionarTodos();
        }

        public Veiculo SelecionarPorId(int id)
        {
            return repositorioVeiculo.SelecionarPorId(id);
        }

        public ValidationResult Validar(Veiculo veiculo)
        {
            validadorVeiculo = new ValidadorVeiculo();

            var resultadoValidacao = validadorVeiculo.Validate(veiculo);

            if (PlacaDuplicada(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Placa", "'Placa' duplicada"));


            return resultadoValidacao;
        }


        #region privates

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            repositorioVeiculo.Sql_selecao_por_parametro = @"SELECT * FROM TBVEICULO WHERE PLACA = @PLACAVEICULO";
            repositorioVeiculo.PropriedadeParametro = "PLACAVEICULO";

            var funcionarioEncontrado = repositorioVeiculo.SelecionarPorParametro(repositorioVeiculo.PropriedadeParametro, veiculo);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Placa.Equals(veiculo.Placa) &&
                  !funcionarioEncontrado.Id.Equals(veiculo.Id);
        }

        #endregion
    }
}
