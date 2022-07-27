using FluentResults;
using FluentValidation.Results;
using LocadoraAutomoveis.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Condutor
{
    public class ServicoCondutor
    {
        //readonly RepositorioCondutorEmBancoDados repositorioCondutor;
        readonly RepositorioCondutorOrm repositorioCondutor;
        readonly IContextoPersistencia contextoPersistOrm;
        ValidadorCondutor validadorCondutor;


        public ServicoCondutor(RepositorioCondutorOrm repositorioCondutor, IContextoPersistencia contextoPersistOrm)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir Condutor... {@condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor); // RepositorioCondutorOrm

                 Log.Logger.Information("Condutor inserido com sucesso. {@condutor}", condutor);
                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar inserir Condutor.";
                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);
                return Result.Fail(msgErro);
            }

            return resultadoValidacao;
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@condutor}", condutor);

            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                Log.Logger.Information("Condutor editado com sucesso. {@condutor}", condutor);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar editar Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@condutor}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);

                Log.Logger.Information("Condutor excluído com sucesso. {@condutor}", condutor);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha ao tentar excluir Condutor.";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";
                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar condutor";

                Log.Logger.Error(ex, msgErro + "{condutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result Validar(Condutor condutor)
        {

            var validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation 
            {
                erros.Add(new Error(item.ErrorMessage));
            }

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'CPF' duplicado"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnh", "'CNH' duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        #region Métodos privados


        private bool CnhDuplicada(Condutor condutor)
        {
    //        repositorioCondutor.Sql_selecao_por_parametro =
    //            @" SELECT
				//CONDUTOR.[ID] CONDUTOR_ID,
				//CONDUTOR.[NOME] CONDUTOR_NOME,
				//CONDUTOR.[CPF] CONDUTOR_CPF,
				//CONDUTOR.[CNH] CONDUTOR_CNH,
				//CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				//CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				//CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				//CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				//CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				//CLIENTE.[NOME] CLIENTE_NOME,
				//CLIENTE.[CPF] CLIENTE_CPF,
				//CLIENTE.[CNPJ] CLIENTE_CNPJ,
				//CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				//CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				//CLIENTE.[EMAIL] CLIENTE_EMAIL,
				//CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			 //   FROM
    //                [TBCONDUTOR] AS CONDUTOR INNER JOIN 
    //                [TBCLIENTE] AS CLIENTE
    //            ON
    //                CLIENTE.ID = CONDUTOR.CLIENTE_ID


    //            WHERE CONDUTOR.CNH = @CNHCONDUTOR";

    //        repositorioCondutor.PropriedadeParametro = "CNHCONDUTOR";
    //        repositorioCondutor.propriedadeValidar = "Cnh";

            var condutorEncontrado = repositorioCondutor.SelecionarPorCnh(condutor.Cnh);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cnh.Equals(condutor.Cnh) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool CpfDuplicado(Condutor condutor)
        {
    //        repositorioCondutor.Sql_selecao_por_parametro =
    //            @" SELECT
				//CONDUTOR.[ID] CONDUTOR_ID,
				//CONDUTOR.[NOME] CONDUTOR_NOME,
				//CONDUTOR.[CPF] CONDUTOR_CPF,
				//CONDUTOR.[CNH] CONDUTOR_CNH,
				//CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				//CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				//CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				//CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				//CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				//CLIENTE.[NOME] CLIENTE_NOME,
				//CLIENTE.[CPF] CLIENTE_CPF,
				//CLIENTE.[CNPJ] CLIENTE_CNPJ,
				//CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				//CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				//CLIENTE.[EMAIL] CLIENTE_EMAIL,
				//CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			 //   FROM
    //                [TBCONDUTOR] AS CONDUTOR INNER JOIN 
    //                [TBCLIENTE] AS CLIENTE
    //            ON
    //                CLIENTE.ID = CONDUTOR.CLIENTE_ID


    //            WHERE CONDUTOR.CPF = @CPFCONDUTOR";

    //        repositorioCondutor.PropriedadeParametro = "CPFCONDUTOR";
    //        repositorioCondutor.propriedadeValidar = "Cpf";

            var condutorEncontrado = repositorioCondutor.SelecionarPorCpf(condutor.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf.Equals(condutor.Cpf) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool NomeDuplicado(Condutor condutor)
        {
    //        repositorioCondutor.Sql_selecao_por_parametro =
    //            @" SELECT
				//CONDUTOR.[ID] CONDUTOR_ID,
				//CONDUTOR.[NOME] CONDUTOR_NOME,
				//CONDUTOR.[CPF] CONDUTOR_CPF,
				//CONDUTOR.[CNH] CONDUTOR_CNH,
				//CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				//CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				//CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				//CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				//CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				//CLIENTE.[NOME] CLIENTE_NOME,
				//CLIENTE.[CPF] CLIENTE_CPF,
				//CLIENTE.[CNPJ] CLIENTE_CNPJ,
				//CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				//CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				//CLIENTE.[EMAIL] CLIENTE_EMAIL,
				//CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			 //   FROM
    //                [TBCONDUTOR] AS CONDUTOR INNER JOIN 
    //                [TBCLIENTE] AS CLIENTE
    //            ON
    //                CLIENTE.ID = CONDUTOR.CLIENTE_ID


    //            WHERE CONDUTOR.NOME = @NOMECONDUTOR";

    //        repositorioCondutor.PropriedadeParametro = "NOMECONDUTOR";
    //        repositorioCondutor.propriedadeValidar = "Nome";

            var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome.Equals(condutor.Nome) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        #endregion
    }
}
