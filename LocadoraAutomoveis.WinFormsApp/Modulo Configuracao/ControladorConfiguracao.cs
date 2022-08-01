
using LocadoraAutomoveis.WinFormsApp.Compartilhado;
using LocadoraAutomoveis.Infra.Logs;
using System.Windows.Forms;
using LocadoraVeiculos.Dominio.Modulo_Configuracao;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Configuracao
{
    public  class ControladorConfiguracao : ControladorBase
    {
        private readonly Configuracao configuracao;

        public ControladorConfiguracao(Configuracao configuracao)
        {
            this.configuracao = configuracao;
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
