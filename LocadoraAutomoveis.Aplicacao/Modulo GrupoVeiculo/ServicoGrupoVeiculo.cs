using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_GrupoVeiculo;
using LocadoraVeiculos.Infra.BancoDados.Modulo_GrupoVeiculo;
using Serilog;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_GrupoVeiculo
{
    public class ServicoGrupoVeiculo
    {
        readonly RepositorioGrupoVeiculoEmBancoDados repositorioGrupoVeiculo;
        ValidadorGrupoVeiculo validadorGrupoVeiculo;


        public ServicoGrupoVeiculo(RepositorioGrupoVeiculoEmBancoDados repositorioGrupoVeiculo)
        {
            this.repositorioGrupoVeiculo = repositorioGrupoVeiculo;
        }

        public ValidationResult Inserir(GrupoVeiculo grupoVeiculo)
        {
            Log.Logger.Debug("Tentando inserir Grupo de Veículo... {@grupo}", grupoVeiculo);
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculo.Inserir(grupoVeiculo);
                Log.Logger.Information("Grupo de Veículo inserido com sucesso. {@grupo}", grupoVeiculo);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar inserir Grupo de Veículo. {GrupoNome} -> Motivo: {erro}", grupoVeiculo.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoVeiculo grupoVeiculo)
        {
            Log.Logger.Debug("Tentando editar Grupo de Veículo... {@grupo}", grupoVeiculo);
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculo.Editar(grupoVeiculo);
                Log.Logger.Information("Grupo de Veículo editado com sucesso. {@grupo}", grupoVeiculo);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Grupo de Veículo. {GrupoNome} -> Motivo: {erro}", grupoVeiculo.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Excluir(GrupoVeiculo grupoVeiculo)
        {
            Log.Logger.Debug("Tentando excluir Grupo de Veículo... {@grupo}", grupoVeiculo);
            var resultadoValidacao = Validar(grupoVeiculo);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculo.Excluir(grupoVeiculo);
                Log.Logger.Information("Grupo de Veículo excluído com sucesso. {@grupo}", grupoVeiculo);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar excluir Grupo de Veículo. {GrupoNome} -> Motivo: {erro}", grupoVeiculo.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando obter todos Grupo de Veículo...");

            var grupos = repositorioGrupoVeiculo.SelecionarTodos();

            if (grupos.Count > 0)
            {
                Log.Logger.Information("Todos os grupos foram obtidos com sucesso. {GrupoCount}", grupos.Count);
                return grupos;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos os grupos. {GrupoCount} -> ", grupos.Count);
                return grupos;
            }
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            Log.Logger.Debug("Tentando obter um Grupo de Veículo...");

            var grupo = repositorioGrupoVeiculo.SelecionarPorId(id);

            if (grupo != null)
            {
                Log.Logger.Information("Grupo foi obtido com sucesso.");
                return grupo;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um grupo. {grupo}");
                return grupo;
            }
            return repositorioGrupoVeiculo.SelecionarPorId(id);
        }

        public ValidationResult Validar(GrupoVeiculo grupoVeiculo)
        {
            validadorGrupoVeiculo = new ValidadorGrupoVeiculo();

            var resultadoValidacao = validadorGrupoVeiculo.Validate(grupoVeiculo);

            if (NomeDuplicado(grupoVeiculo))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));


            return resultadoValidacao;
        }


        #region privates

        private bool NomeDuplicado(GrupoVeiculo grupoVeiculo)
        {
            repositorioGrupoVeiculo.Sql_selecao_por_parametro = @"SELECT * FROM TBGRUPOVEICULO WHERE NOMEGRUPO = @NOME";
            repositorioGrupoVeiculo.PropriedadeParametro = "Nome";

            var funcionarioEncontrado = repositorioGrupoVeiculo.SelecionarPorParametro(repositorioGrupoVeiculo.PropriedadeParametro, grupoVeiculo);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome.Equals(grupoVeiculo.Nome) &&
                  !funcionarioEncontrado.Id.Equals(grupoVeiculo.Id);
        }

        #endregion
    }
}
