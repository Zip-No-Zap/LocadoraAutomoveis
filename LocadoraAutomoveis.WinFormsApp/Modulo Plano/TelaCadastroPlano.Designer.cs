namespace LocadoraAutomoveis.WinFormsApp.Modulo_Plano
{
    partial class TelaCadastroPlano
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.btnAddGrupo = new System.Windows.Forms.Button();
            this.tabControlPlano = new System.Windows.Forms.TabControl();
            this.tabPageDiario = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tbValorKmRodado_Diario = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValorDiario_Diario = new System.Windows.Forms.MaskedTextBox();
            this.tabPageLivre = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tbValorDiario_Livre = new System.Windows.Forms.MaskedTextBox();
            this.tabPageControlado = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLimiteQuilometragem = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKmRodado_Controlado = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbValorDiario_Controlado = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControlPlano.SuspendLayout();
            this.tabPageDiario.SuspendLayout();
            this.tabPageLivre.SuspendLayout();
            this.tabPageControlado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(296, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupo Veículo";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(314, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 34);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Items.AddRange(new object[] {
            "Econômico",
            "Esportivo",
            "PCD",
            "UBER",
            "USV"});
            this.cbGrupo.Location = new System.Drawing.Point(16, 56);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(321, 33);
            this.cbGrupo.TabIndex = 0;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(16, 28);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(123, 25);
            this.lblGrupo.TabIndex = 1;
            this.lblGrupo.Text = "Grupo Veículo";
            // 
            // btnAddGrupo
            // 
            this.btnAddGrupo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddGrupo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGrupo.Location = new System.Drawing.Point(343, 56);
            this.btnAddGrupo.Name = "btnAddGrupo";
            this.btnAddGrupo.Size = new System.Drawing.Size(112, 34);
            this.btnAddGrupo.TabIndex = 2;
            this.btnAddGrupo.Text = "Adicionar";
            this.btnAddGrupo.UseVisualStyleBackColor = false;
            this.btnAddGrupo.Click += new System.EventHandler(this.btnAddGrupo_Click);
            // 
            // tabControlPlano
            // 
            this.tabControlPlano.Controls.Add(this.tabPageDiario);
            this.tabControlPlano.Controls.Add(this.tabPageLivre);
            this.tabControlPlano.Controls.Add(this.tabPageControlado);
            this.tabControlPlano.Location = new System.Drawing.Point(12, 128);
            this.tabControlPlano.Name = "tabControlPlano";
            this.tabControlPlano.SelectedIndex = 0;
            this.tabControlPlano.Size = new System.Drawing.Size(443, 337);
            this.tabControlPlano.TabIndex = 3;
            // 
            // tabPageDiario
            // 
            this.tabPageDiario.Controls.Add(this.label3);
            this.tabPageDiario.Controls.Add(this.tbValorKmRodado_Diario);
            this.tabPageDiario.Controls.Add(this.label2);
            this.tabPageDiario.Controls.Add(this.tbValorDiario_Diario);
            this.tabPageDiario.Location = new System.Drawing.Point(4, 34);
            this.tabPageDiario.Name = "tabPageDiario";
            this.tabPageDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiario.Size = new System.Drawing.Size(435, 299);
            this.tabPageDiario.TabIndex = 0;
            this.tabPageDiario.Text = "Diário";
            this.tabPageDiario.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor por Km Rodado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbValorKmRodado_Diario
            // 
            this.tbValorKmRodado_Diario.Location = new System.Drawing.Point(17, 143);
            this.tbValorKmRodado_Diario.Mask = "R$";
            this.tbValorKmRodado_Diario.Name = "tbValorKmRodado_Diario";
            this.tbValorKmRodado_Diario.Size = new System.Drawing.Size(230, 31);
            this.tbValorKmRodado_Diario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Diário";
            // 
            // tbValorDiario_Diario
            // 
            this.tbValorDiario_Diario.Location = new System.Drawing.Point(17, 51);
            this.tbValorDiario_Diario.Mask = "R$";
            this.tbValorDiario_Diario.Name = "tbValorDiario_Diario";
            this.tbValorDiario_Diario.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Diario.TabIndex = 0;
            // 
            // tabPageLivre
            // 
            this.tabPageLivre.Controls.Add(this.label4);
            this.tabPageLivre.Controls.Add(this.tbValorDiario_Livre);
            this.tabPageLivre.Location = new System.Drawing.Point(4, 34);
            this.tabPageLivre.Name = "tabPageLivre";
            this.tabPageLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLivre.Size = new System.Drawing.Size(435, 299);
            this.tabPageLivre.TabIndex = 1;
            this.tabPageLivre.Text = "Livre";
            this.tabPageLivre.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor Diário";
            // 
            // tbValorDiario_Livre
            // 
            this.tbValorDiario_Livre.Location = new System.Drawing.Point(17, 51);
            this.tbValorDiario_Livre.Mask = "R$";
            this.tbValorDiario_Livre.Name = "tbValorDiario_Livre";
            this.tbValorDiario_Livre.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Livre.TabIndex = 2;
            // 
            // tabPageControlado
            // 
            this.tabPageControlado.Controls.Add(this.label7);
            this.tabPageControlado.Controls.Add(this.tbLimiteQuilometragem);
            this.tabPageControlado.Controls.Add(this.label5);
            this.tabPageControlado.Controls.Add(this.tbKmRodado_Controlado);
            this.tabPageControlado.Controls.Add(this.label6);
            this.tabPageControlado.Controls.Add(this.tbValorDiario_Controlado);
            this.tabPageControlado.Location = new System.Drawing.Point(4, 34);
            this.tabPageControlado.Name = "tabPageControlado";
            this.tabPageControlado.Size = new System.Drawing.Size(435, 299);
            this.tabPageControlado.TabIndex = 2;
            this.tabPageControlado.Text = "Controlado";
            this.tabPageControlado.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(14, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Limite Quilometragem";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // tbLimiteQuilometragem
            // 
            this.tbLimiteQuilometragem.Location = new System.Drawing.Point(17, 234);
            this.tbLimiteQuilometragem.Name = "tbLimiteQuilometragem";
            this.tbLimiteQuilometragem.Size = new System.Drawing.Size(230, 31);
            this.tbLimiteQuilometragem.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Valor por Km Rodado";
            // 
            // tbKmRodado_Controlado
            // 
            this.tbKmRodado_Controlado.Location = new System.Drawing.Point(17, 143);
            this.tbKmRodado_Controlado.Mask = "R$";
            this.tbKmRodado_Controlado.Name = "tbKmRodado_Controlado";
            this.tbKmRodado_Controlado.Size = new System.Drawing.Size(230, 31);
            this.tbKmRodado_Controlado.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(14, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor Diário";
            // 
            // tbValorDiario_Controlado
            // 
            this.tbValorDiario_Controlado.Location = new System.Drawing.Point(17, 51);
            this.tbValorDiario_Controlado.Mask = "R$";
            this.tbValorDiario_Controlado.Name = "tbValorDiario_Controlado";
            this.tbValorDiario_Controlado.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Controlado.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(16, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 91);
            this.panel1.TabIndex = 4;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(135, 16);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(112, 59);
            this.btnLimpar.TabIndex = 9;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(17, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 59);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // TelaCadastroPlano
            // 
            this.ClientSize = new System.Drawing.Size(467, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlPlano);
            this.Controls.Add(this.btnAddGrupo);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cbGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaCadastroPlano";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Cobrança";
            this.tabControlPlano.ResumeLayout(false);
            this.tabPageDiario.ResumeLayout(false);
            this.tabPageDiario.PerformLayout();
            this.tabPageLivre.ResumeLayout(false);
            this.tabPageLivre.PerformLayout();
            this.tabPageControlado.ResumeLayout(false);
            this.tabPageControlado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Button btnAddGrupo;
        private System.Windows.Forms.TabControl tabControlPlano;
        private System.Windows.Forms.TabPage tabPageDiario;
        private System.Windows.Forms.TabPage tabPageLivre;
        private System.Windows.Forms.TabPage tabPageControlado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbValorKmRodado_Diario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbValorDiario_Diario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbValorDiario_Livre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbLimiteQuilometragem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbKmRodado_Controlado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbValorDiario_Controlado;
    }
}