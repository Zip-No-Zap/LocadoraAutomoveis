using GeradorTestes.WinApp.Compartilhado;
using LocadoraVeiculos.Dominio.Modulo_Plano;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    public partial class PlanoControl : UserControl
    {
        public PlanoControl()
        {
            InitializeComponent();

            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Visible = false},
                new DataGridViewTextBoxColumn { DataPropertyName = "NomeGrupo", HeaderText = "Grupo Veículo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Diario", HeaderText = "Diário:\nValor diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Diario", HeaderText = "Diário:\nValor por Km rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Livre", HeaderText = "Livre:\nValor por Km Rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDiario_Controlado", HeaderText = "Controlado:\nValor Diário"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPorKm_Controlado", HeaderText = "Controlado:\nValor por Km rodado"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteQuilometragem_Controlado", HeaderText = "Controlado:\n Limite quilometragem"},
            };

            return colunas;
        }

        public Guid ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Plano> registros)
        {
            grid.Rows.Clear();

            foreach (var registro in registros)
            {
                grid.Rows.Add(
                    registro.Id,
                    registro.Grupo.Nome,
                    registro.ValorDiario_Diario.ToString("N2"),
                    registro.ValorPorKm_Diario.ToString("N2"),
                    registro.ValorDiario_Livre.ToString("N2"),
                    registro.ValorDiario_Controlado.ToString("N2"),
                    registro.ValorPorKm_Controlado.ToString("N2"),
                    registro.LimiteQuilometragem_Controlado.ToString()

                   );
            }
        }
    }
}
