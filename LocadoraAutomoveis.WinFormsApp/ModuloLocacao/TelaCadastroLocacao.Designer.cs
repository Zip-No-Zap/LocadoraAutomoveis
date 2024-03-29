﻿namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    partial class TelaCadastroLocacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrarDevolucao = new System.Windows.Forms.Button();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbCondutor = new System.Windows.Forms.GroupBox();
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalPrevisto = new System.Windows.Forms.Label();
            this.lblTotalMarcador = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.cmbPlano = new System.Windows.Forms.ComboBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.listTaxasAdicionais = new System.Windows.Forms.CheckedListBox();
            this.txtKmAtual = new System.Windows.Forms.TextBox();
            this.lblQuilometragem = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.dpDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtPDF = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.gbCondutor.SuspendLayout();
            this.gb.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnRegistrarDevolucao);
            this.panel1.Controls.Add(this.btnDesmarcar);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(48, 831);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 98);
            this.panel1.TabIndex = 8;
            // 
            // btnRegistrarDevolucao
            // 
            this.btnRegistrarDevolucao.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegistrarDevolucao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarDevolucao.Location = new System.Drawing.Point(575, 16);
            this.btnRegistrarDevolucao.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarDevolucao.Name = "btnRegistrarDevolucao";
            this.btnRegistrarDevolucao.Size = new System.Drawing.Size(168, 65);
            this.btnRegistrarDevolucao.TabIndex = 12;
            this.btnRegistrarDevolucao.Text = "Registrar Devolução";
            this.btnRegistrarDevolucao.UseVisualStyleBackColor = false;
            this.btnRegistrarDevolucao.Visible = false;
            this.btnRegistrarDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDesmarcar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesmarcar.Location = new System.Drawing.Point(391, 16);
            this.btnDesmarcar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(168, 65);
            this.btnDesmarcar.TabIndex = 11;
            this.btnDesmarcar.Text = "Desmarcar Itens";
            this.btnDesmarcar.UseVisualStyleBackColor = false;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click_1);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(209, 16);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(168, 65);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(30, 16);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(168, 65);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbCondutor
            // 
            this.gbCondutor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbCondutor.Controls.Add(this.cmbCondutor);
            this.gbCondutor.Controls.Add(this.label2);
            this.gbCondutor.Controls.Add(this.label1);
            this.gbCondutor.Controls.Add(this.cmbClientes);
            this.gbCondutor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbCondutor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbCondutor.Location = new System.Drawing.Point(48, 30);
            this.gbCondutor.Margin = new System.Windows.Forms.Padding(2);
            this.gbCondutor.Name = "gbCondutor";
            this.gbCondutor.Padding = new System.Windows.Forms.Padding(2);
            this.gbCondutor.Size = new System.Drawing.Size(801, 126);
            this.gbCondutor.TabIndex = 9;
            this.gbCondutor.TabStop = false;
            this.gbCondutor.Text = "Dados Condutor";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.DisplayMember = "Nome";
            this.cmbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondutor.FormattingEnabled = true;
            this.cmbCondutor.Location = new System.Drawing.Point(425, 62);
            this.cmbCondutor.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(332, 33);
            this.cmbCondutor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(425, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Condutor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // cmbClientes
            // 
            this.cmbClientes.DisplayMember = "Nome";
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(41, 62);
            this.cmbClientes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(352, 33);
            this.cmbClientes.TabIndex = 0;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(416, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "Plano";
            // 
            // gb
            // 
            this.gb.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gb.Controls.Add(this.panel2);
            this.gb.Controls.Add(this.lblTotalMarcador);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.cmbGrupoVeiculo);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.cmbPlano);
            this.gb.Controls.Add(this.btnCalcular);
            this.gb.Controls.Add(this.listTaxasAdicionais);
            this.gb.Controls.Add(this.txtKmAtual);
            this.gb.Controls.Add(this.lblQuilometragem);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.cmbVeiculo);
            this.gb.Controls.Add(this.label6);
            this.gb.Controls.Add(this.dpDataDevolucao);
            this.gb.Controls.Add(this.dpDataLocacao);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.label5);
            this.gb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gb.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gb.Location = new System.Drawing.Point(48, 175);
            this.gb.Margin = new System.Windows.Forms.Padding(2);
            this.gb.Name = "gb";
            this.gb.Padding = new System.Windows.Forms.Padding(2);
            this.gb.Size = new System.Drawing.Size(801, 618);
            this.gb.TabIndex = 10;
            this.gb.TabStop = false;
            this.gb.Text = "Dados Locação";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblTotalPrevisto);
            this.panel2.Location = new System.Drawing.Point(550, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 34);
            this.panel2.TabIndex = 43;
            // 
            // lblTotalPrevisto
            // 
            this.lblTotalPrevisto.AutoSize = true;
            this.lblTotalPrevisto.Location = new System.Drawing.Point(25, 3);
            this.lblTotalPrevisto.Name = "lblTotalPrevisto";
            this.lblTotalPrevisto.Size = new System.Drawing.Size(46, 25);
            this.lblTotalPrevisto.TabIndex = 41;
            this.lblTotalPrevisto.Text = "0,00";
            // 
            // lblTotalMarcador
            // 
            this.lblTotalMarcador.AutoSize = true;
            this.lblTotalMarcador.Location = new System.Drawing.Point(393, 557);
            this.lblTotalMarcador.Name = "lblTotalMarcador";
            this.lblTotalMarcador.Size = new System.Drawing.Size(151, 25);
            this.lblTotalMarcador.TabIndex = 42;
            this.lblTotalMarcador.Text = "Total Previsto R$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(32, 241);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "Itens Adicionais";
            // 
            // cmbGrupoVeiculo
            // 
            this.cmbGrupoVeiculo.DisplayMember = "Nome";
            this.cmbGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculo.FormattingEnabled = true;
            this.cmbGrupoVeiculo.Location = new System.Drawing.Point(34, 128);
            this.cmbGrupoVeiculo.Margin = new System.Windows.Forms.Padding(6);
            this.cmbGrupoVeiculo.Name = "cmbGrupoVeiculo";
            this.cmbGrupoVeiculo.Size = new System.Drawing.Size(353, 33);
            this.cmbGrupoVeiculo.TabIndex = 4;
            this.cmbGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoVeiculo_SelectedIndexChanged);
            // 
            // cmbPlano
            // 
            this.cmbPlano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlano.FormattingEnabled = true;
            this.cmbPlano.Items.AddRange(new object[] {
            "Diário",
            "Livre",
            "Controlado"});
            this.cmbPlano.Location = new System.Drawing.Point(416, 198);
            this.cmbPlano.Margin = new System.Windows.Forms.Padding(6);
            this.cmbPlano.Name = "cmbPlano";
            this.cmbPlano.Size = new System.Drawing.Size(340, 33);
            this.cmbPlano.TabIndex = 7;
            this.cmbPlano.SelectedIndexChanged += new System.EventHandler(this.cmbPlano_SelectedIndexChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCalcular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCalcular.Location = new System.Drawing.Point(35, 552);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(165, 47);
            this.btnCalcular.TabIndex = 8;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // listTaxasAdicionais
            // 
            this.listTaxasAdicionais.AccessibleName = "";
            this.listTaxasAdicionais.CheckOnClick = true;
            this.listTaxasAdicionais.FormattingEnabled = true;
            this.listTaxasAdicionais.Location = new System.Drawing.Point(34, 267);
            this.listTaxasAdicionais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listTaxasAdicionais.Name = "listTaxasAdicionais";
            this.listTaxasAdicionais.Size = new System.Drawing.Size(723, 256);
            this.listTaxasAdicionais.TabIndex = 35;
            // 
            // txtKmAtual
            // 
            this.txtKmAtual.Enabled = false;
            this.txtKmAtual.Location = new System.Drawing.Point(34, 198);
            this.txtKmAtual.Margin = new System.Windows.Forms.Padding(2);
            this.txtKmAtual.Name = "txtKmAtual";
            this.txtKmAtual.Size = new System.Drawing.Size(349, 31);
            this.txtKmAtual.TabIndex = 6;
            // 
            // lblQuilometragem
            // 
            this.lblQuilometragem.AutoSize = true;
            this.lblQuilometragem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblQuilometragem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuilometragem.Location = new System.Drawing.Point(35, 171);
            this.lblQuilometragem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuilometragem.Name = "lblQuilometragem";
            this.lblQuilometragem.Size = new System.Drawing.Size(160, 21);
            this.lblQuilometragem.TabIndex = 8;
            this.lblQuilometragem.Text = "Quilometragem Atual";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(416, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Veículo";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.DisplayMember = "Modelo";
            this.cmbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(416, 130);
            this.cmbVeiculo.Margin = new System.Windows.Forms.Padding(6);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(340, 33);
            this.cmbVeiculo.TabIndex = 5;
            this.cmbVeiculo.SelectedIndexChanged += new System.EventHandler(this.cmbVeiculo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(34, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Grupo";
            // 
            // dpDataDevolucao
            // 
            this.dpDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataDevolucao.Location = new System.Drawing.Point(419, 59);
            this.dpDataDevolucao.Margin = new System.Windows.Forms.Padding(2);
            this.dpDataDevolucao.MinDate = new System.DateTime(2022, 7, 25, 23, 59, 59, 0);
            this.dpDataDevolucao.Name = "dpDataDevolucao";
            this.dpDataDevolucao.Size = new System.Drawing.Size(338, 31);
            this.dpDataDevolucao.TabIndex = 3;
            // 
            // dpDataLocacao
            // 
            this.dpDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataLocacao.Location = new System.Drawing.Point(34, 59);
            this.dpDataLocacao.Margin = new System.Windows.Forms.Padding(2);
            this.dpDataLocacao.MinDate = new System.DateTime(2022, 7, 25, 23, 59, 59, 0);
            this.dpDataLocacao.Name = "dpDataLocacao";
            this.dpDataLocacao.Size = new System.Drawing.Size(352, 31);
            this.dpDataLocacao.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(416, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Devolução";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(32, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Locação";
            // 
            // rtPDF
            // 
            this.rtPDF.Location = new System.Drawing.Point(934, 30);
            this.rtPDF.Name = "rtPDF";
            this.rtPDF.Size = new System.Drawing.Size(286, 668);
            this.rtPDF.TabIndex = 11;
            this.rtPDF.Text = "";
            this.rtPDF.Visible = false;
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 970);
            this.Controls.Add(this.rtPDF);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.gbCondutor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "TelaCadastroLocacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locação";
            this.Load += new System.EventHandler(this.TelaCadastroLocacao_Load);
            this.panel1.ResumeLayout(false);
            this.gbCondutor.ResumeLayout(false);
            this.gbCondutor.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.CheckedListBox listTaxasAdicionais;
        private System.Windows.Forms.TextBox txtKmAtual;
        private System.Windows.Forms.Label lblQuilometragem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpDataDevolucao;
        private System.Windows.Forms.DateTimePicker dpDataLocacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbCondutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPlano;
        private System.Windows.Forms.ComboBox cmbCondutor;
        private System.Windows.Forms.ComboBox cmbGrupoVeiculo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalPrevisto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.RichTextBox rtPDF;
        private System.Windows.Forms.Button btnRegistrarDevolucao;
        private System.Windows.Forms.Label lblTotalMarcador;
    }
}