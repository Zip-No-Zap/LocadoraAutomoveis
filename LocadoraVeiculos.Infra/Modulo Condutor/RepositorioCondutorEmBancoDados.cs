using LocadoraVeiculos.Dominio.Modulo_Condutor;
using LocadoraVeiculos.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Modulo_Condutor
{
    public class RepositorioCondutorEmBancoDados : 
        RepositorioBase<Condutor, MapeadorCondutor, ValidadorCondutor>
    {

        protected override string Sql_insercao =>
			@"INSERT INTO [TBCONDUTOR]
           (
			   [NOME],
			   [CPF],
			   [CNH],
			   [VENCIMENTOCNH],
			   [EMAIL],
			   [ENDERECO],
			   [TELEFONE],
			   [CLIENTE_ID]
		   )
		    VALUES
			(
				@NOME,
				@CPF,
				@CNH,
			    @VENCIMENTOCNH, 
				@EMAIL, 
				@ENDERECO,
				@TELEFONE,
				@CLIENTE_ID
			);SELECT SCOPE_IDENTITY();
";

        protected override string Sql_edicao =>
			@"UPDATE [TBCONDUTOR]
				SET
					[NOME] = @NOME,
					[CPF] = @CPF,
					[CNH] = @CNH,
					[VENCIMENTOCNH] = @VENCIMENTOCNH,
					[EMAIL] = @EMAIL,
					[ENDERECO] = @ENDERECO,
					[TELEFONE] = @TELEFONE,
					[CLIENTE_ID] = @CLIENTE_ID
				WHERE
					[ID] = @ID";

		protected override string Sql_exclusao =>
			@"DELETE FROM [TBCONDUTOR]
                WHERE
                [ID] = @ID";

        protected override string Sql_selecao_por_id =>
			@"SELECT
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
            WHERE 
                CONDUTOR.[ID] = @ID";

        protected override string Sql_selecao_todos =>
			@"SELECT
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
                CLIENTE.ID = CONDUTOR.CLIENTE_ID";

        
    }
}
