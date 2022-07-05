namespace LocadoraAutomoveis.WinFormsApp.Modulo_Condutor
{
    partial class TelaCadastroCondutor
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
            this.cbClienteECondutor = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.tbCnh = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataVencimentoCnh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCpf = new System.Windows.Forms.MaskedTextBox();
            this.tbTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEndereco = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbClienteECondutor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbClientes);
            this.panel1.Controls.Add(this.tbCnh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDataVencimentoCnh);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCpf);
            this.panel1.Controls.Add(this.tbTelefone);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbNome);
            this.panel1.Controls.Add(this.tbEmail);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbEndereco);
            this.panel1.Location = new System.Drawing.Point(26, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 372);
            this.panel1.TabIndex = 0;
            // 
            // cbClienteECondutor
            // 
            this.cbClienteECondutor.AutoSize = true;
            this.cbClienteECondutor.Enabled = false;
            this.cbClienteECondutor.Location = new System.Drawing.Point(245, 43);
            this.cbClienteECondutor.Name = "cbClienteECondutor";
            this.cbClienteECondutor.Size = new System.Drawing.Size(166, 24);
            this.cbClienteECondutor.TabIndex = 90;
            this.cbClienteECondutor.Text = "Cliente é o condutor";
            this.cbClienteECondutor.UseVisualStyleBackColor = true;
            this.cbClienteECondutor.CheckedChanged += new System.EventHandler(this.cbClienteECondutor_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(14, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 89;
            this.label5.Text = "Cliente";
            // 
            // cmbClientes
            // 
            this.cmbClientes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cmbClientes.DisplayMember = "Nome";
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(14, 41);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(218, 28);
            this.cmbClientes.TabIndex = 88;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // tbCnh
            // 
            this.tbCnh.Location = new System.Drawing.Point(15, 311);
            this.tbCnh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCnh.Mask = "00000000000";
            this.tbCnh.Name = "tbCnh";
            this.tbCnh.Size = new System.Drawing.Size(217, 27);
            this.tbCnh.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 288);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 86;
            this.label3.Text = "CNH";
            // 
            // txtDataVencimentoCnh
            // 
            this.txtDataVencimentoCnh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataVencimentoCnh.Location = new System.Drawing.Point(245, 311);
            this.txtDataVencimentoCnh.Name = "txtDataVencimentoCnh";
            this.txtDataVencimentoCnh.Size = new System.Drawing.Size(223, 27);
            this.txtDataVencimentoCnh.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(238, 287);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 84;
            this.label2.Text = "Vencimento CNH";
            // 
            // tbCpf
            // 
            this.tbCpf.Location = new System.Drawing.Point(15, 148);
            this.tbCpf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCpf.Mask = "000.000.000-00";
            this.tbCpf.Name = "tbCpf";
            this.tbCpf.Size = new System.Drawing.Size(224, 27);
            this.tbCpf.TabIndex = 83;
            // 
            // tbTelefone
            // 
            this.tbTelefone.Location = new System.Drawing.Point(245, 148);
            this.tbTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTelefone.Mask = "(99) 00000-0000";
            this.tbTelefone.Name = "tbTelefone";
            this.tbTelefone.Size = new System.Drawing.Size(223, 27);
            this.tbTelefone.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 78;
            this.label1.Text = "Nome";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(245, 125);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 19);
            this.label10.TabIndex = 82;
            this.label10.Text = "Telefone";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(14, 93);
            this.tbNome.Margin = new System.Windows.Forms.Padding(2);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(454, 27);
            this.tbNome.TabIndex = 74;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(16, 209);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(452, 27);
            this.tbEmail.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(16, 188);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 19);
            this.label9.TabIndex = 81;
            this.label9.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 79;
            this.label4.Text = "CPF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(16, 238);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 80;
            this.label6.Text = "Endereço";
            // 
            // tbEndereco
            // 
            this.tbEndereco.Location = new System.Drawing.Point(16, 259);
            this.tbEndereco.Margin = new System.Windows.Forms.Padding(2);
            this.tbEndereco.Name = "tbEndereco";
            this.tbEndereco.Size = new System.Drawing.Size(452, 27);
            this.tbEndereco.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btnLimpar);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Location = new System.Drawing.Point(26, 415);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 72);
            this.panel2.TabIndex = 52;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(108, 11);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(90, 47);
            this.btnLimpar.TabIndex = 8;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(14, 11);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 47);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TelaCadastroCondutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 513);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TelaCadastroCondutor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Condutor";
            this.Load += new System.EventHandler(this.TelaCadastroCondutor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbClienteECondutor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.MaskedTextBox tbCnh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDataVencimentoCnh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbCpf;
        private System.Windows.Forms.MaskedTextBox tbTelefone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEndereco;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnOK;
    }
}