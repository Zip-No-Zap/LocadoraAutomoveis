using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
using Serilog;
using System;
using System.Collections.Generic;

namespace LocadoraAutomoveis.Aplicacao.Modulo_Condutor
{
    public class ServicoCondutor
    {
        readonly RepositorioCondutorEmBancoDados repositorioCondutor;
        ValidadorCondutor validadorCondutor;

        public ServicoCondutor(RepositorioCondutorEmBancoDados repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor; 
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir Condutor... {@condutor}", condutor);
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Information("Condutor inserido com sucesso. {@condutor}", condutor);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar inserir Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@condutor}", condutor);
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Information("Condutor editado com sucesso. {@condutor}", condutor);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    Log.Logger.Warning("Falha ao tentar editar Condutor. {CondutorId} -> Motivo: {erro}", condutor.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public void Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@condutor}", condutor);
            repositorioCondutor.Excluir(condutor);

            var condutorExcluido = SelecionarPorId(condutor.Id);

            if (condutorExcluido == null)
                Log.Logger.Information("Condutor excluído com sucesso. {@condutor} -> ", condutor);
            else
                Log.Logger.Warning("Falha ao excluir Condutor. {Condutor} -> Motivo: {erro}", condutor);
        }

        public List<Condutor> SelecionarTodos()
        {
            List<Condutor> condutores = new();

            Log.Logger.Debug("Tentando obter todos Condutor...");

            try
            {
                condutores = repositorioCondutor.SelecionarTodos();
            }
            catch(Exception ex)
            {
                string msgErro = "falha no sistema ao tentar selecioanr todos os condutores";
                Log.Logger.Error(ex, msgErro);
            }

            if (condutores.Count > 0)
            {
                Log.Logger.Information("Todos os condutores foram obtidos com sucesso. {CondutorCount}", condutores.Count);
                return condutores;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter todos Condutor. {CondutorsCount} -> ", condutores.Count);
                return condutores;
            }
        }
        public Condutor SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando obter um condutor...");

            var condutor = repositorioCondutor.SelecionarPorId(id);

            if (condutor != null)
            {
                Log.Logger.Information("Condutor foi obtido com sucesso.");
                return condutor;
            }
            else
            {
                Log.Logger.Warning("Falha ao tentar obter um condutor. {Condutor}");
                return condutor;
            }
        }


        public ValidationResult Validar(Condutor condutor)
        {
            validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'CPF' duplicado"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnh", "'CNH' duplicada"));


            return resultadoValidacao;
        }


        #region Métodos privados
            

        private bool CnhDuplicada(Condutor condutor)
        {
            repositorioCondutor.Sql_selecao_por_parametro =
                @" SELECT
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF] CLIENTE_CPF,
				CLIENTE.[CNPJ] CLIENTE_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			    FROM
                    [TBCONDUTOR] AS CONDUTOR INNER JOIN 
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID


                WHERE CONDUTOR.CNH = @CNHCONDUTOR";

            repositorioCondutor.PropriedadeParametro = "CNHCONDUTOR";
            repositorioCondutor.propriedadeValidar = "Cnh";

            var condutorEncontrado = repositorioCondutor.SelecionarPorParametro(repositorioCondutor.PropriedadeParametro, condutor);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cnh.Equals(condutor.Cnh) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            repositorioCondutor.Sql_selecao_por_parametro =
                @" SELECT
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF] CLIENTE_CPF,
				CLIENTE.[CNPJ] CLIENTE_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			    FROM
                    [TBCONDUTOR] AS CONDUTOR INNER JOIN 
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID


                WHERE CONDUTOR.CPF = @CPFCONDUTOR";

            repositorioCondutor.PropriedadeParametro = "CPFCONDUTOR";
            repositorioCondutor.propriedadeValidar = "Cpf";

            var condutorEncontrado = repositorioCondutor.SelecionarPorParametro(repositorioCondutor.PropriedadeParametro, condutor);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf.Equals(condutor.Cpf) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            repositorioCondutor.Sql_selecao_por_parametro =
                @" SELECT
				CONDUTOR.[ID] CONDUTOR_ID,
				CONDUTOR.[NOME] CONDUTOR_NOME,
				CONDUTOR.[CPF] CONDUTOR_CPF,
				CONDUTOR.[CNH] CONDUTOR_CNH,
				CONDUTOR.[VENCIMENTOCNH] CONDUTOR_VENCIMENTOCNH,
				CONDUTOR.[EMAIL]CONDUTOR_EMAIL,
				CONDUTOR.[ENDERECO] CONDUTOR_ENDERECO,
				CONDUTOR.[TELEFONE] CONDUTOR_TELEFONE,
				CONDUTOR.[CLIENTE_ID] CONDUTOR_CLIENTE_ID,
		
				CLIENTE.[NOME] CLIENTE_NOME,
				CLIENTE.[CPF] CLIENTE_CPF,
				CLIENTE.[CNPJ] CLIENTE_CNPJ,
				CLIENTE.[ENDERECO] CLIENTE_ENDERECO,
				CLIENTE.[TIPOCLIENTE] CLIENTE_TIPOCLIENTE,
				CLIENTE.[EMAIL] CLIENTE_EMAIL,
				CLIENTE.[TELEFONE] CLIENTE_TELEFONE

			    FROM
                    [TBCONDUTOR] AS CONDUTOR INNER JOIN 
                    [TBCLIENTE] AS CLIENTE
                ON
                    CLIENTE.ID = CONDUTOR.CLIENTE_ID


                WHERE CONDUTOR.NOME = @NOMECONDUTOR";

            repositorioCondutor.PropriedadeParametro = "NOMECONDUTOR";
            repositorioCondutor.propriedadeValidar = "Nome";

            var condutorEncontrado = repositorioCondutor.SelecionarPorParametro(repositorioCondutor.PropriedadeParametro, condutor);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome.Equals(condutor.Nome) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        #endregion
    }
}
