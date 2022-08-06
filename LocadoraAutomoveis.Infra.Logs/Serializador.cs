using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;

namespace LocadoraAutomoveis.Infra.Logs
{
    public class Serializador
    {
        readonly List<Configuracao> _entidade;
        string _diretorio;
        string _tipoEntidade;

        public Serializador()
        {

        }

        public Serializador(List<Configuracao> entidade) : base()
        {
            _entidade = entidade;
            _diretorio = ObterDiretorio();
        }

        public void GuardarArquivo()
        {
            try
            {
                string folder = @"C:\temp\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    _diretorio = ObterDiretorio();
                }

                var escreverNoArquivo = JsonConvert.SerializeObject(_entidade, Formatting.Indented);

                using (var writer = new StreamWriter(_diretorio))
                {
                    writer.Write(escreverNoArquivo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Configuracao> ObterArquivo()
        {
            try
            {
                string pegaArquivo;
                string folder = @"C:\temp\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    _diretorio = ObterDiretorio();
                }

                using (var reader = new StreamReader(_diretorio))
                {
                    pegaArquivo = reader.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<List<Configuracao>>(pegaArquivo);
            }
            catch (System.IO.FileNotFoundException)
            {
                return null;
            }
        }
      
        #region privados

        private string ObterDiretorio()
        {
            return @"C:\temp\ConfiguracaoCombustivel.json";
        }

        #endregion

    }

}