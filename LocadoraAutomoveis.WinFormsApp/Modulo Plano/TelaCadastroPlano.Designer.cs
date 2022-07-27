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
            this.tabControlPlano = new System.Windows.Forms.TabControl();
            this.tabPageDiario = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbValorKmRodado_Diario = new System.Windows.Forms.TextBox();
            this.tbValorDiario_Diario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageLivre = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tbValorDiario_Livre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageControlado = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbKmRodado_Controlado = new System.Windows.Forms.TextBox();
            this.tbValorDiario_Controlado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLimiteQuilometragem = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblIDGrupo = new System.Windows.Forms.Label();
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
            this.tabPageDiario.Controls.Add(this.label12);
            this.tabPageDiario.Controls.Add(this.label11);
            this.tabPageDiario.Controls.Add(this.tbValorKmRodado_Diario);
            this.tabPageDiario.Controls.Add(this.tbValorDiario_Diario);
            this.tabPageDiario.Controls.Add(this.label3);
            this.tabPageDiario.Controls.Add(this.label2);
            this.tabPageDiario.Location = new System.Drawing.Point(4, 34);
            this.tabPageDiario.Name = "tabPageDiario";
            this.tabPageDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiario.Size = new System.Drawing.Size(435, 299);
            this.tabPageDiario.TabIndex = 0;
            this.tabPageDiario.Text = "Diário";
            this.tabPageDiario.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(22, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 21);
            this.label12.TabIndex = 15;
            this.label12.Text = "R$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(22, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 21);
            this.label11.TabIndex = 14;
            this.label11.Text = "R$";
            // 
            // tbValorKmRodado_Diario
            // 
            this.tbValorKmRodado_Diario.Location = new System.Drawing.Point(52, 139);
            this.tbValorKmRodado_Diario.Name = "tbValorKmRodado_Diario";
            this.tbValorKmRodado_Diario.Size = new System.Drawing.Size(230, 31);
            this.tbValorKmRodado_Diario.TabIndex = 5;
            this.tbValorKmRodado_Diario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorKmRodado_Diario_KeyPress);
            // 
            // tbValorDiario_Diario
            // 
            this.tbValorDiario_Diario.Location = new System.Drawing.Point(52, 47);
            this.tbValorDiario_Diario.Name = "tbValorDiario_Diario";
            this.tbValorDiario_Diario.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Diario.TabIndex = 4;
            this.tbValorDiario_Diario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorDiario_Diario_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(49, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor por Km Rodado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(49, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Diário";
            // 
            // tabPageLivre
            // 
            this.tabPageLivre.Controls.Add(this.label10);
            this.tabPageLivre.Controls.Add(this.tbValorDiario_Livre);
            this.tabPageLivre.Controls.Add(this.label4);
            this.tabPageLivre.Location = new System.Drawing.Point(4, 34);
            this.tabPageLivre.Name = "tabPageLivre";
            this.tabPageLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLivre.Size = new System.Drawing.Size(435, 299);
            this.tabPageLivre.TabIndex = 1;
            this.tabPageLivre.Text = "Livre";
            this.tabPageLivre.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(23, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 21);
            this.label10.TabIndex = 14;
            this.label10.Text = "R$";
            // 
            // tbValorDiario_Livre
            // 
            this.tbValorDiario_Livre.Location = new System.Drawing.Point(52, 47);
            this.tbValorDiario_Livre.Name = "tbValorDiario_Livre";
            this.tbValorDiario_Livre.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Livre.TabIndex = 5;
            this.tbValorDiario_Livre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorDiario_Livre_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(49, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor Diário";
            // 
            // tabPageControlado
            // 
            this.tabPageControlado.Controls.Add(this.label9);
            this.tabPageControlado.Controls.Add(this.label8);
            this.tabPageControlado.Controls.Add(this.tbKmRodado_Controlado);
            this.tabPageControlado.Controls.Add(this.tbValorDiario_Controlado);
            this.tabPageControlado.Controls.Add(this.label7);
            this.tabPageControlado.Controls.Add(this.tbLimiteQuilometragem);
            this.tabPageControlado.Controls.Add(this.label5);
            this.tabPageControlado.Controls.Add(this.label6);
            this.tabPageControlado.Location = new System.Drawing.Point(4, 34);
            this.tabPageControlado.Name = "tabPageControlado";
            this.tabPageControlado.Size = new System.Drawing.Size(435, 299);
            this.tabPageControlado.TabIndex = 2;
            this.tabPageControlado.Text = "Controlado";
            this.tabPageControlado.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(23, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "R$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(23, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "R$";
            // 
            // tbKmRodado_Controlado
            // 
            this.tbKmRodado_Controlado.Location = new System.Drawing.Point(52, 139);
            this.tbKmRodado_Controlado.Name = "tbKmRodado_Controlado";
            this.tbKmRodado_Controlado.Size = new System.Drawing.Size(230, 31);
            this.tbKmRodado_Controlado.TabIndex = 12;
            this.tbKmRodado_Controlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKmRodado_Controlado_KeyPress);
            // 
            // tbValorDiario_Controlado
            // 
            this.tbValorDiario_Controlado.Location = new System.Drawing.Point(52, 47);
            this.tbValorDiario_Controlado.Name = "tbValorDiario_Controlado";
            this.tbValorDiario_Controlado.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario_Controlado.TabIndex = 10;
            this.tbValorDiario_Controlado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValorDiario_Controlado_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(49, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Limite Quilometragem";
            // 
            // tbLimiteQuilometragem
            // 
            this.tbLimiteQuilometragem.Location = new System.Drawing.Point(52, 230);
            this.tbLimiteQuilometragem.Name = "tbLimiteQuilometragem";
            this.tbLimiteQuilometragem.Size = new System.Drawing.Size(230, 31);
            this.tbLimiteQuilometragem.TabIndex = 8;
            this.tbLimiteQuilometragem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLimiteQuilometragem_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(49, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Valor por Km Rodado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(49, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Valor Diário";
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
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
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
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // lblIDGrupo
            // 
            this.lblIDGrupo.AutoSize = true;
            this.lblIDGrupo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblIDGrupo.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblIDGrupo.Location = new System.Drawing.Point(343, 64);
            this.lblIDGrupo.Name = "lblIDGrupo";
            this.lblIDGrupo.Size = new System.Drawing.Size(121, 21);
            this.lblIDGrupo.TabIndex = 5;
            this.lblIDGrupo.Text = "receberIDGrupo";
            this.lblIDGrupo.Visible = false;
            // 
            // TelaCadastroPlano
            // 
            this.ClientSize = new System.Drawing.Size(467, 588);
            this.Controls.Add(this.lblIDGrupo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlPlano);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.cbGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaCadastroPlano";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de Cobrança";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaCadastroPlano_FormClosing);
            this.Load += new System.EventHandler(this.TelaCadastroPlano_Load);
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
        private System.Windows.Forms.TabControl tabControlPlano;
        private System.Windows.Forms.TabPage tabPageDiario;
        private System.Windows.Forms.TabPage tabPageLivre;
        private System.Windows.Forms.TabPage tabPageControlado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox tbLimiteQuilometragem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbValorDiario_Diario;
        private System.Windows.Forms.TextBox tbValorKmRodado_Diario;
        private System.Windows.Forms.TextBox tbValorDiario_Livre;
        private System.Windows.Forms.TextBox tbKmRodado_Controlado;
        private System.Windows.Forms.TextBox tbValorDiario_Controlado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIDGrupo;
    }
}