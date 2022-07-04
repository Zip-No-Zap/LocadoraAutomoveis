namespace LocadoraAutomoveis.WinFormsApp.Modulo_Veiculo
{
    partial class TelaCadastroVeiculo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbModelo = new System.Windows.Forms.TextBox();
            this.txbPlaca = new System.Windows.Forms.TextBox();
            this.txbCor = new System.Windows.Forms.TextBox();
            this.txbAno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoCombustivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbQuilometragemAtual = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnAdicionarFoto = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblIDGrupo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Placa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cor";
            // 
            // txbModelo
            // 
            this.txbModelo.Location = new System.Drawing.Point(31, 63);
            this.txbModelo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbModelo.Name = "txbModelo";
            this.txbModelo.Size = new System.Drawing.Size(303, 31);
            this.txbModelo.TabIndex = 3;
            this.txbModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbModelo_KeyPress);
            this.txbModelo.Leave += new System.EventHandler(this.txbModelo_Leave);
            // 
            // txbPlaca
            // 
            this.txbPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbPlaca.Location = new System.Drawing.Point(31, 158);
            this.txbPlaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbPlaca.MaxLength = 7;
            this.txbPlaca.Name = "txbPlaca";
            this.txbPlaca.Size = new System.Drawing.Size(303, 31);
            this.txbPlaca.TabIndex = 4;
            this.txbPlaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPlaca_KeyPress);
            // 
            // txbCor
            // 
            this.txbCor.Location = new System.Drawing.Point(31, 254);
            this.txbCor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCor.Name = "txbCor";
            this.txbCor.Size = new System.Drawing.Size(303, 31);
            this.txbCor.TabIndex = 5;
            this.txbCor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCor_KeyPress);
            // 
            // txbAno
            // 
            this.txbAno.Location = new System.Drawing.Point(31, 345);
            this.txbAno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbAno.MaxLength = 4;
            this.txbAno.Name = "txbAno";
            this.txbAno.Size = new System.Drawing.Size(303, 31);
            this.txbAno.TabIndex = 7;
            this.txbAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbAno_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 315);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ano";
            // 
            // cmbTipoCombustivel
            // 
            this.cmbTipoCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCombustivel.FormattingEnabled = true;
            this.cmbTipoCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Gás",
            "Álcool"});
            this.cmbTipoCombustivel.Location = new System.Drawing.Point(30, 448);
            this.cmbTipoCombustivel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoCombustivel.Name = "cmbTipoCombustivel";
            this.cmbTipoCombustivel.Size = new System.Drawing.Size(304, 33);
            this.cmbTipoCombustivel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 418);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo Combustível";
            // 
            // txbCapacidadeTanque
            // 
            this.txbCapacidadeTanque.Location = new System.Drawing.Point(30, 549);
            this.txbCapacidadeTanque.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCapacidadeTanque.Name = "txbCapacidadeTanque";
            this.txbCapacidadeTanque.Size = new System.Drawing.Size(304, 31);
            this.txbCapacidadeTanque.TabIndex = 11;
            this.txbCapacidadeTanque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCapacidadeTanque_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 519);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Capacidade Tanque";
            // 
            // txbQuilometragemAtual
            // 
            this.txbQuilometragemAtual.Location = new System.Drawing.Point(390, 549);
            this.txbQuilometragemAtual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbQuilometragemAtual.Name = "txbQuilometragemAtual";
            this.txbQuilometragemAtual.Size = new System.Drawing.Size(303, 31);
            this.txbQuilometragemAtual.TabIndex = 13;
            this.txbQuilometragemAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbQuilometragemAtual_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 519);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Quilometragem Atual";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 418);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Alugado",
            "Reservado",
            "Disponível",
            "Em Manutenção",
            "Indisponível"});
            this.cmbStatus.Location = new System.Drawing.Point(392, 448);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(301, 33);
            this.cmbStatus.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 315);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Grupo Pertencente";
            // 
            // cmbGrupoVeiculo
            // 
            this.cmbGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculo.FormattingEnabled = true;
            this.cmbGrupoVeiculo.Location = new System.Drawing.Point(393, 345);
            this.cmbGrupoVeiculo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbGrupoVeiculo.Name = "cmbGrupoVeiculo";
            this.cmbGrupoVeiculo.Size = new System.Drawing.Size(300, 33);
            this.cmbGrupoVeiculo.TabIndex = 16;
            this.cmbGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoVeiculo_SelectedIndexChanged_1);
            // 
            // pbFoto
            // 
            this.pbFoto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbFoto.Location = new System.Drawing.Point(393, 63);
            this.pbFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(302, 174);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 18;
            this.pbFoto.TabStop = false;
            // 
            // btnAdicionarFoto
            // 
            this.btnAdicionarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarFoto.Location = new System.Drawing.Point(393, 247);
            this.btnAdicionarFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdicionarFoto.Name = "btnAdicionarFoto";
            this.btnAdicionarFoto.Size = new System.Drawing.Size(302, 44);
            this.btnAdicionarFoto.TabIndex = 19;
            this.btnAdicionarFoto.Text = "Adicionar foto";
            this.btnAdicionarFoto.UseVisualStyleBackColor = true;
            this.btnAdicionarFoto.Click += new System.EventHandler(this.btnAdicionarFoto_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(393, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Foto";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(19, 14);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 70);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(147, 14);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(120, 70);
            this.btnLimpar.TabIndex = 22;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblIDGrupo
            // 
            this.lblIDGrupo.AutoSize = true;
            this.lblIDGrupo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblIDGrupo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIDGrupo.Location = new System.Drawing.Point(394, 383);
            this.lblIDGrupo.Name = "lblIDGrupo";
            this.lblIDGrupo.Size = new System.Drawing.Size(120, 25);
            this.lblIDGrupo.TabIndex = 23;
            this.lblIDGrupo.Text = "pegaIDGrupo";
            this.lblIDGrupo.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Location = new System.Drawing.Point(31, 615);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 102);
            this.panel1.TabIndex = 24;
            // 
            // TelaCadastroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIDGrupo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnAdicionarFoto);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbGrupoVeiculo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txbQuilometragemAtual);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbCapacidadeTanque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoCombustivel);
            this.Controls.Add(this.txbAno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbCor);
            this.Controls.Add(this.txbPlaca);
            this.Controls.Add(this.txbModelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroVeiculo_FormClosing_1);
            this.Load += new System.EventHandler(this.TelaCadastroVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbModelo;
        private System.Windows.Forms.TextBox txbPlaca;
        private System.Windows.Forms.TextBox txbCor;
        private System.Windows.Forms.TextBox txbAno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoCombustivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbCapacidadeTanque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbQuilometragemAtual;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGrupoVeiculo;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnAdicionarFoto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblIDGrupo;
        private System.Windows.Forms.Panel panel1;
    }
}