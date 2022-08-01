
using LocadoraAutomoveis.Infra.Logs;
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Configuracao;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public  class ControladorConfiguracao : ControladorBase
    {
       //private readonly ConfiguracaoLogger configuracao;

        public ControladorConfiguracao(ConfiguracaoLogger configuracao)
        {
            //this.configuracao = configuracao;
        }

        public override void Editar()
        {

        }

        public override void Excluir()
        {

        }

        public override void Inserir()
        {
        }

        public override ConfiguracaoToolStripBase ObtemConfiguracaoToolStrip()
        {
            return new ConfiguracaoStripConfiguracao();
        }

        public override UserControl ObtemListagem()
        {
            return new ConfiguracaoControl(configuracao);
        }
    }
}
