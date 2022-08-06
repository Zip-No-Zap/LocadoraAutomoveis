namespace LocadoraAutomoveis.WinFormsApp
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grupoDeVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarPreçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combustívelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblStatusPrincipal = new System.Windows.Forms.ToolStripLabel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.toolStripPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDevolucao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSeparar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluirFechadas = new System.Windows.Forms.ToolStripButton();
            this.lblToolStripPrincipal = new System.Windows.Forms.ToolStripLabel();
            this.menuPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.locaçãoToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1798, 33);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.funcionarioToolStripMenuItem,
            this.grupoDeVeículoToolStripMenuItem,
            this.taxaToolStripMenuItem,
            this.condutorToolStripMenuItem,
            this.veículoToolStripMenuItem,
            this.planoDeCobrançaToolStripMenuItem,
            this.configurarPreçosToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.funcionarioToolStripMenuItem.Text = "Funcionário";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // grupoDeVeículoToolStripMenuItem
            // 
            this.grupoDeVeículoToolStripMenuItem.Name = "grupoDeVeículoToolStripMenuItem";
            this.grupoDeVeículoToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.grupoDeVeículoToolStripMenuItem.Text = "Grupo de Veículo";
            this.grupoDeVeículoToolStripMenuItem.Click += new System.EventHandler(this.grupoDeVeículoToolStripMenuItem_Click);
            // 
            // taxaToolStripMenuItem
            // 
            this.taxaToolStripMenuItem.Name = "taxaToolStripMenuItem";
            this.taxaToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.taxaToolStripMenuItem.Text = "Taxa";
            this.taxaToolStripMenuItem.Click += new System.EventHandler(this.taxaToolStripMenuItem_Click);
            // 
            // condutorToolStripMenuItem
            // 
            this.condutorToolStripMenuItem.Name = "condutorToolStripMenuItem";
            this.condutorToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.condutorToolStripMenuItem.Text = "Condutor";
            this.condutorToolStripMenuItem.Click += new System.EventHandler(this.condutorToolStripMenuItem_Click);
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            this.veículoToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.veículoToolStripMenuItem.Text = "Veículo";
            this.veículoToolStripMenuItem.Click += new System.EventHandler(this.veículoToolStripMenuItem_Click);
            // 
            // planoDeCobrançaToolStripMenuItem
            // 
            this.planoDeCobrançaToolStripMenuItem.Name = "planoDeCobrançaToolStripMenuItem";
            this.planoDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.planoDeCobrançaToolStripMenuItem.Text = "Plano de Cobrança";
            this.planoDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planoDeCobrançaToolStripMenuItem_Click);
            // 
            // configurarPreçosToolStripMenuItem
            // 
            this.configurarPreçosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combustívelToolStripMenuItem});
            this.configurarPreçosToolStripMenuItem.Name = "configurarPreçosToolStripMenuItem";
            this.configurarPreçosToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.configurarPreçosToolStripMenuItem.Text = "Configurar Preços";
            // 
            // combustívelToolStripMenuItem
            // 
            this.combustívelToolStripMenuItem.Name = "combustívelToolStripMenuItem";
            this.combustívelToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.combustívelToolStripMenuItem.Text = "Combustível";
            this.combustívelToolStripMenuItem.Click += new System.EventHandler(this.combustívelToolStripMenuItem_Click);
            // 
            // locaçãoToolStripMenuItem
            // 
            this.locaçãoToolStripMenuItem.Name = "locaçãoToolStripMenuItem";
            this.locaçãoToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.locaçãoToolStripMenuItem.Text = "Locação";
            this.locaçãoToolStripMenuItem.Click += new System.EventHandler(this.locacaoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusPrincipal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 827);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1798, 30);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblStatusPrincipal
            // 
            this.lblStatusPrincipal.Name = "lblStatusPrincipal";
            this.lblStatusPrincipal.Size = new System.Drawing.Size(121, 25);
            this.lblStatusPrincipal.Text = "Tela Principal";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Location = new System.Drawing.Point(0, 92);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1786, 714);
            this.panelPrincipal.TabIndex = 2;
            // 
            // toolStripPrincipal
            // 
            this.toolStripPrincipal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInserir,
            this.btnEditar,
            this.btnExcluir,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.btnDevolucao,
            this.toolStripSeparator1,
            this.btnSeparar,
            this.btnExcluirFechadas,
            this.lblToolStripPrincipal});
            this.toolStripPrincipal.Location = new System.Drawing.Point(0, 33);
            this.toolStripPrincipal.Name = "toolStripPrincipal";
            this.toolStripPrincipal.Size = new System.Drawing.Size(1798, 33);
            this.toolStripPrincipal.TabIndex = 3;
            // 
            // btnInserir
            // 
            this.btnInserir.Enabled = false;
            this.btnInserir.Image = ((System.Drawing.Image)(resources.GetObject("btnInserir.Image")));
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(34, 28);
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(34, 28);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(34, 28);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // btnDevolucao
            // 
            this.btnDevolucao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDevolucao.Enabled = false;
            this.btnDevolucao.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucao.Image")));
            this.btnDevolucao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDevolucao.Name = "btnDevolucao";
            this.btnDevolucao.Size = new System.Drawing.Size(34, 28);
            this.btnDevolucao.Click += new System.EventHandler(this.btnDevolucao_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // btnSeparar
            // 
            this.btnSeparar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeparar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeparar.Image")));
            this.btnSeparar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeparar.Name = "btnSeparar";
            this.btnSeparar.Size = new System.Drawing.Size(34, 28);
            this.btnSeparar.Click += new System.EventHandler(this.btnSeparar_Click);
            // 
            // btnExcluirFechadas
            // 
            this.btnExcluirFechadas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcluirFechadas.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirFechadas.Image")));
            this.btnExcluirFechadas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluirFechadas.Name = "btnExcluirFechadas";
            this.btnExcluirFechadas.Size = new System.Drawing.Size(34, 28);
            this.btnExcluirFechadas.Click += new System.EventHandler(this.btnExcluirFechadas_Click);
            // 
            // lblToolStripPrincipal
            // 
            this.lblToolStripPrincipal.Margin = new System.Windows.Forms.Padding(20, 2, 0, 3);
            this.lblToolStripPrincipal.Name = "lblToolStripPrincipal";
            this.lblToolStripPrincipal.Size = new System.Drawing.Size(83, 28);
            this.lblToolStripPrincipal.Text = "Cadastro";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1798, 857);
            this.Controls.Add(this.toolStripPrincipal);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locadora de Veículos 1.0";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripPrincipal.ResumeLayout(false);
            this.toolStripPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grupoDeVeículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taxaToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ToolStrip toolStripPrincipal;
        private System.Windows.Forms.ToolStripButton btnInserir;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnExcluir;
        private System.Windows.Forms.ToolStripLabel lblToolStripPrincipal;
        private System.Windows.Forms.ToolStripLabel lblStatusPrincipal;
        private System.Windows.Forms.ToolStripMenuItem condutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeCobrançaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarPreçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combustívelToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnDevolucao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSeparar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExcluirFechadas;
    }
}
