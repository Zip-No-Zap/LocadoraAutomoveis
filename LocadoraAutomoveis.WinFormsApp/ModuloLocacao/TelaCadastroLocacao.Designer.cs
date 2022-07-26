namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
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
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbCondutor = new System.Windows.Forms.GroupBox();
            this.tbVencimentoCnh = new System.Windows.Forms.TextBox();
            this.tbCondutor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbItens = new System.Windows.Forms.ComboBox();
            this.tbGrupo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdControlado = new System.Windows.Forms.RadioButton();
            this.rdLivre = new System.Windows.Forms.RadioButton();
            this.rdDiario = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbVeiculo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpDataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.dpDataLocacao = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDetalhar = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.gbCondutor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnLimpar);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(12, 790);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 98);
            this.panel1.TabIndex = 0;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Location = new System.Drawing.Point(209, 16);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(167, 65);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Location = new System.Drawing.Point(33, 16);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(167, 65);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // gbCondutor
            // 
            this.gbCondutor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gbCondutor.Controls.Add(this.tbVencimentoCnh);
            this.gbCondutor.Controls.Add(this.tbCondutor);
            this.gbCondutor.Controls.Add(this.label2);
            this.gbCondutor.Controls.Add(this.label1);
            this.gbCondutor.Controls.Add(this.cbCliente);
            this.gbCondutor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbCondutor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbCondutor.Location = new System.Drawing.Point(15, 21);
            this.gbCondutor.Name = "gbCondutor";
            this.gbCondutor.Size = new System.Drawing.Size(402, 310);
            this.gbCondutor.TabIndex = 1;
            this.gbCondutor.TabStop = false;
            this.gbCondutor.Text = "Dados Condutor";
            // 
            // tbVencimentoCnh
            // 
            this.tbVencimentoCnh.Enabled = false;
            this.tbVencimentoCnh.Location = new System.Drawing.Point(24, 241);
            this.tbVencimentoCnh.Name = "tbVencimentoCnh";
            this.tbVencimentoCnh.Size = new System.Drawing.Size(356, 31);
            this.tbVencimentoCnh.TabIndex = 6;
            // 
            // tbCondutor
            // 
            this.tbCondutor.Enabled = false;
            this.tbCondutor.Location = new System.Drawing.Point(24, 163);
            this.tbCondutor.Name = "tbCondutor";
            this.tbCondutor.Size = new System.Drawing.Size(356, 31);
            this.tbCondutor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(24, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Condutor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(24, 80);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(356, 33);
            this.cbCliente.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(39, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data Vencimento CNH";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbItens);
            this.groupBox1.Controls.Add(this.tbGrupo);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbVeiculo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dpDataDevolucao);
            this.groupBox1.Controls.Add(this.dpDataLocacao);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(434, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 383);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Locação";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(441, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "Itens Adicionais";
            // 
            // cbItens
            // 
            this.cbItens.FormattingEnabled = true;
            this.cbItens.Location = new System.Drawing.Point(441, 217);
            this.cbItens.Name = "cbItens";
            this.cbItens.Size = new System.Drawing.Size(220, 33);
            this.cbItens.TabIndex = 7;
            // 
            // tbGrupo
            // 
            this.tbGrupo.Enabled = false;
            this.tbGrupo.Location = new System.Drawing.Point(262, 154);
            this.tbGrupo.Name = "tbGrupo";
            this.tbGrupo.Size = new System.Drawing.Size(254, 31);
            this.tbGrupo.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(532, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 31);
            this.textBox1.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(532, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "Quilometragem Atual";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox2.Controls.Add(this.rdControlado);
            this.groupBox2.Controls.Add(this.rdLivre);
            this.groupBox2.Controls.Add(this.rdDiario);
            this.groupBox2.Location = new System.Drawing.Point(24, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 93);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plano";
            // 
            // rdControlado
            // 
            this.rdControlado.AutoSize = true;
            this.rdControlado.Location = new System.Drawing.Point(235, 36);
            this.rdControlado.Name = "rdControlado";
            this.rdControlado.Size = new System.Drawing.Size(131, 29);
            this.rdControlado.TabIndex = 2;
            this.rdControlado.TabStop = true;
            this.rdControlado.Text = "Controlado";
            this.rdControlado.UseVisualStyleBackColor = true;
            // 
            // rdLivre
            // 
            this.rdLivre.AutoSize = true;
            this.rdLivre.Location = new System.Drawing.Point(142, 36);
            this.rdLivre.Name = "rdLivre";
            this.rdLivre.Size = new System.Drawing.Size(77, 29);
            this.rdLivre.TabIndex = 1;
            this.rdLivre.TabStop = true;
            this.rdLivre.Text = "Livre";
            this.rdLivre.UseVisualStyleBackColor = true;
            // 
            // rdDiario
            // 
            this.rdDiario.AutoSize = true;
            this.rdDiario.Location = new System.Drawing.Point(39, 36);
            this.rdDiario.Name = "rdDiario";
            this.rdDiario.Size = new System.Drawing.Size(87, 29);
            this.rdDiario.TabIndex = 0;
            this.rdDiario.TabStop = true;
            this.rdDiario.Text = "Diário";
            this.rdDiario.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(262, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Veículo";
            // 
            // cbVeiculo
            // 
            this.cbVeiculo.FormattingEnabled = true;
            this.cbVeiculo.Location = new System.Drawing.Point(262, 76);
            this.cbVeiculo.Margin = new System.Windows.Forms.Padding(6);
            this.cbVeiculo.Name = "cbVeiculo";
            this.cbVeiculo.Size = new System.Drawing.Size(474, 33);
            this.cbVeiculo.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(262, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "Grupo";
            // 
            // dpDataDevolucao
            // 
            this.dpDataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataDevolucao.Location = new System.Drawing.Point(24, 154);
            this.dpDataDevolucao.MinDate = new System.DateTime(2022, 7, 25, 23, 59, 59, 0);
            this.dpDataDevolucao.Name = "dpDataDevolucao";
            this.dpDataDevolucao.Size = new System.Drawing.Size(222, 31);
            this.dpDataDevolucao.TabIndex = 8;
            // 
            // dpDataLocacao
            // 
            this.dpDataLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataLocacao.Location = new System.Drawing.Point(24, 78);
            this.dpDataLocacao.MinDate = new System.DateTime(2022, 7, 25, 23, 59, 59, 0);
            this.dpDataLocacao.Name = "dpDataLocacao";
            this.dpDataLocacao.Size = new System.Drawing.Size(222, 31);
            this.dpDataLocacao.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(24, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Devolução";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(24, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Locação";
            // 
            // btnDetalhar
            // 
            this.btnDetalhar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetalhar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalhar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDetalhar.Location = new System.Drawing.Point(15, 345);
            this.btnDetalhar.Name = "btnDetalhar";
            this.btnDetalhar.Size = new System.Drawing.Size(402, 59);
            this.btnDetalhar.TabIndex = 8;
            this.btnDetalhar.Text = "Detalhar";
            this.btnDetalhar.UseVisualStyleBackColor = false;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(441, 256);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(295, 101);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(667, 214);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 36);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(15, 447);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1196, 310);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados Condutor";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(24, 241);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(356, 31);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(24, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(356, 31);
            this.textBox3.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(24, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "Condutor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(24, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Cliente";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(356, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // TelaCadastroLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 900);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDetalhar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbCondutor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaCadastroLocacao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Locação";
            this.panel1.ResumeLayout(false);
            this.gbCondutor.ResumeLayout(false);
            this.gbCondutor.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbCondutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbVencimentoCnh;
        private System.Windows.Forms.TextBox tbCondutor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpDataLocacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdControlado;
        private System.Windows.Forms.RadioButton rdLivre;
        private System.Windows.Forms.RadioButton rdDiario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbVeiculo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpDataDevolucao;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbItens;
        private System.Windows.Forms.TextBox tbGrupo;
        private System.Windows.Forms.Button btnDetalhar;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}