namespace LocadoraAutomoveis.WinFormsApp.ModuloLocacao
{
    partial class TelaDevolucao
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtKmAtualDevolucao = new System.Windows.Forms.TextBox();
            this.lblQuilometragem = new System.Windows.Forms.Label();
            this.dpDataDevolvido = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTanque = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(12, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 88);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(18, 11);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(168, 65);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtKmAtualDevolucao
            // 
            this.txtKmAtualDevolucao.Location = new System.Drawing.Point(30, 152);
            this.txtKmAtualDevolucao.Margin = new System.Windows.Forms.Padding(2);
            this.txtKmAtualDevolucao.Name = "txtKmAtualDevolucao";
            this.txtKmAtualDevolucao.Size = new System.Drawing.Size(251, 31);
            this.txtKmAtualDevolucao.TabIndex = 12;
            this.txtKmAtualDevolucao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKmAtualDevolucao_KeyPress);
            // 
            // lblQuilometragem
            // 
            this.lblQuilometragem.AutoSize = true;
            this.lblQuilometragem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblQuilometragem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuilometragem.Location = new System.Drawing.Point(31, 125);
            this.lblQuilometragem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuilometragem.Name = "lblQuilometragem";
            this.lblQuilometragem.Size = new System.Drawing.Size(160, 21);
            this.lblQuilometragem.TabIndex = 10;
            this.lblQuilometragem.Text = "Quilometragem Atual";
            // 
            // dpDataDevolvido
            // 
            this.dpDataDevolvido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataDevolvido.Location = new System.Drawing.Point(31, 57);
            this.dpDataDevolvido.Margin = new System.Windows.Forms.Padding(2);
            this.dpDataDevolvido.MinDate = new System.DateTime(2022, 7, 25, 23, 59, 59, 0);
            this.dpDataDevolvido.Name = "dpDataDevolvido";
            this.dpDataDevolvido.Size = new System.Drawing.Size(250, 31);
            this.dpDataDevolvido.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Data Devolução";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(30, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nível Tanque";
            // 
            // cmbTanque
            // 
            this.cmbTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTanque.FormattingEnabled = true;
            this.cmbTanque.Items.AddRange(new object[] {
            "0 %",
            "25 %",
            "50 %",
            "75 %",
            "100 %"});
            this.cmbTanque.Location = new System.Drawing.Point(30, 237);
            this.cmbTanque.Margin = new System.Windows.Forms.Padding(6);
            this.cmbTanque.Name = "cmbTanque";
            this.cmbTanque.Size = new System.Drawing.Size(251, 33);
            this.cmbTanque.TabIndex = 13;
            // 
            // TelaDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 452);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTanque);
            this.Controls.Add(this.dpDataDevolvido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKmAtualDevolucao);
            this.Controls.Add(this.lblQuilometragem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaDevolucao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução";
            this.Load += new System.EventHandler(this.TelaDevolucao_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtKmAtualDevolucao;
        private System.Windows.Forms.Label lblQuilometragem;
        private System.Windows.Forms.DateTimePicker dpDataDevolvido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTanque;
    }
}