using FluentValidation.Results;
using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor;
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
            var resultadoValidacao = Validar(condutor);


            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(condutor);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(condutor);

            return resultadoValidacao;
        }

        public void Excluir(Condutor condutor)
        {
             repositorioCondutor.Excluir(condutor);
        }

        public List<Condutor> SelecionarTodos()
        {
            return repositorioCondutor.SelecionarTodos();
        }
        public Condutor SelecionarPorId(int id)
        {
            return repositorioCondutor.SelecionarPorId(id);
        }


        public ValidationResult Validar(Condutor condutor)
        {
            validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            if (NomeDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "'Nome' duplicado"));

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cpf", "'Cpf' duplicado"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("Cnh", "'Cnh' duplicada"));


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
		
				CLIENTE.[ID] CLIENTE_ID,
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
            repositorioCondutor.PropriedadeValidar = "Cnh";

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
		
				CLIENTE.[ID] CLIENTE_ID,
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


                WHERE CONDUTOR.CPF = @CNHCONDUTOR";

            repositorioCondutor.PropriedadeParametro = "CPFCONDUTOR";
            repositorioCondutor.PropriedadeValidar = "Cpf";

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
		
				CLIENTE.[ID] CLIENTE_ID,
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
            repositorioCondutor.PropriedadeValidar = "Nome";

            var condutorEncontrado = repositorioCondutor.SelecionarPorParametro(repositorioCondutor.PropriedadeParametro, condutor);

            return condutorEncontrado != null &&
                   condutorEncontrado.Nome.Equals(condutor.Nome) &&
                  !condutorEncontrado.Id.Equals(condutor.Id);
        }

        #endregion
    }
}
