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
            this.tabPageLivre = new System.Windows.Forms.TabPage();
            this.tabPageControlado = new System.Windows.Forms.TabPage();
            this.tbValorDiario = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.tabControlPlano.SuspendLayout();
            this.tabPageDiario.SuspendLayout();
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
            this.tabControlPlano.Size = new System.Drawing.Size(975, 489);
            this.tabControlPlano.TabIndex = 3;
            // 
            // tabPageDiario
            // 
            this.tabPageDiario.Controls.Add(this.label3);
            this.tabPageDiario.Controls.Add(this.maskedTextBox1);
            this.tabPageDiario.Controls.Add(this.label2);
            this.tabPageDiario.Controls.Add(this.tbValorDiario);
            this.tabPageDiario.Location = new System.Drawing.Point(4, 34);
            this.tabPageDiario.Name = "tabPageDiario";
            this.tabPageDiario.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiario.Size = new System.Drawing.Size(967, 451);
            this.tabPageDiario.TabIndex = 0;
            this.tabPageDiario.Text = "Diário";
            this.tabPageDiario.UseVisualStyleBackColor = true;
            // 
            // tabPageLivre
            // 
            this.tabPageLivre.Location = new System.Drawing.Point(4, 34);
            this.tabPageLivre.Name = "tabPageLivre";
            this.tabPageLivre.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLivre.Size = new System.Drawing.Size(967, 451);
            this.tabPageLivre.TabIndex = 1;
            this.tabPageLivre.Text = "Livre";
            this.tabPageLivre.UseVisualStyleBackColor = true;
            // 
            // tabPageControlado
            // 
            this.tabPageControlado.Location = new System.Drawing.Point(4, 34);
            this.tabPageControlado.Name = "tabPageControlado";
            this.tabPageControlado.Size = new System.Drawing.Size(967, 451);
            this.tabPageControlado.TabIndex = 2;
            this.tabPageControlado.Text = "Controlado";
            this.tabPageControlado.UseVisualStyleBackColor = true;
            // 
            // tbValorDiario
            // 
            this.tbValorDiario.Location = new System.Drawing.Point(19, 77);
            this.tbValorDiario.Mask = "R$";
            this.tbValorDiario.Name = "tbValorDiario";
            this.tbValorDiario.Size = new System.Drawing.Size(230, 31);
            this.tbValorDiario.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor Diário";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Valor Diário";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(19, 169);
            this.maskedTextBox1.Mask = "R$";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(230, 31);
            this.maskedTextBox1.TabIndex = 2;
            // 
            // TelaCadastroPlano
            // 
            this.ClientSize = new System.Drawing.Size(1008, 681);
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbValorDiario;
    }
}