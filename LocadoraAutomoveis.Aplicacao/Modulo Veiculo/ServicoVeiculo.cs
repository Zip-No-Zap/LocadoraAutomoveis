using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Veiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Veiculo;
using System.Collections.Generic;

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

            if (ModeloDuplicado(veiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Modelo", "'Modelo' duplicado"));

            return resultadoValidacao;
        }

        #region privates

        private bool PlacaDuplicada(Veiculo veiculo)
        {
            repositorioVeiculo.Sql_selecao_por_parametro = @"SELECT  

                                                                V.[ID],
                                                                V.[MODELO], 
                                                                V.[PLACA], 
                                                                V.[COR], 
                                                                V.[ANO],
                                                                V.[TIPOCOMBUSTIVEL],
                                                                V.[CAPACIDADETANQUE],
                                                                V.[STATUS],
                                                                V.[QUILOMETRAGEMATUAL],
                                                                V.[FOTO],
                                                                V.[IDGRUPOVEICULO],

                                                                GV.[NOMEGRUPO]

                                                            FROM TBVEICULO AS V
                                                            INNER JOIN TBGRUPOVEICULO AS GV

                                                                ON V.IDGRUPOVEICULO = GV.ID

                                                            WHERE PLACA = @PLACAVEICULO";

            repositorioVeiculo.PropriedadeParametro = "PLACAVEICULO";

            var veiculoEncontrado = repositorioVeiculo.SelecionarPorParametro(repositorioVeiculo.PropriedadeParametro, veiculo);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa.Equals(veiculo.Placa) &&
                  !veiculoEncontrado.Id.Equals(veiculo.Id);
        }

        private bool ModeloDuplicado(Veiculo veiculo)
        {
            repositorioVeiculo.Sql_selecao_por_parametro = @"SELECT  
                                                                    V.[ID],
                                                                    V.[MODELO], 
                                                                    V.[PLACA], 
                                                                    V.[COR], 
                                                                    V.[ANO],
                                                                    V.[TIPOCOMBUSTIVEL],
                                                                    V.[CAPACIDADETANQUE],
                                                                    V.[STATUS],
                                                                    V.[QUILOMETRAGEMATUAL],
                                                                    V.[FOTO],
                                                                    V.[IDGRUPOVEICULO],

                                                                    GV.[NOMEGRUPO]

                                                                FROM TBVEICULO AS V
                                                                INNER JOIN TBGRUPOVEICULO AS GV

                                                                    ON V.IDGRUPOVEICULO = GV.ID

                                                                WHERE MODELO = @MODELOVEICULO";

            repositorioVeiculo.PropriedadeParametro = "MODELOVEICULO";

            var veiculoEncontrado = repositorioVeiculo.SelecionarPorParametro(repositorioVeiculo.PropriedadeParametro, veiculo);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa.Equals(veiculo.Placa) &&
                  !veiculoEncontrado.Id.Equals(veiculo.Id);
        }

        #endregion
    }
}
