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
            this.planoDeCobrançaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblStatusPrincipal = new System.Windows.Forms.ToolStripLabel();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.toolStripPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnInserir = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnExcluir = new System.Windows.Forms.ToolStripButton();
            this.lblToolStripPrincipal = new System.Windows.Forms.ToolStripLabel();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1651, 24);
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
            this.veículoToolStripMenuItem});
            this.taxaToolStripMenuItem,
            this.planoDeCobrançaToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastroToolStripMenuItem.Text = "Cadastro";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.funcionarioToolStripMenuItem.Text = "Funcionário";
            this.funcionarioToolStripMenuItem.Click += new System.EventHandler(this.funcionarioToolStripMenuItem_Click);
            // 
            // grupoDeVeículoToolStripMenuItem
            // 
            this.grupoDeVeículoToolStripMenuItem.Name = "grupoDeVeículoToolStripMenuItem";
            this.grupoDeVeículoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grupoDeVeículoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.grupoDeVeículoToolStripMenuItem.Text = "Grupo de Veículo";
            this.grupoDeVeículoToolStripMenuItem.Click += new System.EventHandler(this.grupoDeVeículoToolStripMenuItem_Click);
            // 
            // taxaToolStripMenuItem
            // 
            this.taxaToolStripMenuItem.Name = "taxaToolStripMenuItem";
            this.taxaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.taxaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.taxaToolStripMenuItem.Text = "Taxa";
            this.taxaToolStripMenuItem.Click += new System.EventHandler(this.taxaToolStripMenuItem_Click);
            // 
            // planoDeCobrançaToolStripMenuItem
            // 
            this.planoDeCobrançaToolStripMenuItem.Name = "planoDeCobrançaToolStripMenuItem";
            this.planoDeCobrançaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.planoDeCobrançaToolStripMenuItem.Text = "Plano de Cobrança";
            this.planoDeCobrançaToolStripMenuItem.Click += new System.EventHandler(this.planoDeCobrançaToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusPrincipal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 832);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1651, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblStatusPrincipal
            // 
            this.lblStatusPrincipal.Name = "lblStatusPrincipal";
            this.lblStatusPrincipal.Size = new System.Drawing.Size(77, 22);
            this.lblStatusPrincipal.Text = "Tela Principal";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Location = new System.Drawing.Point(0, 92);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1639, 714);
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
            this.lblToolStripPrincipal});
            this.toolStripPrincipal.Location = new System.Drawing.Point(0, 24);
            this.toolStripPrincipal.Name = "toolStripPrincipal";
            this.toolStripPrincipal.Size = new System.Drawing.Size(1651, 31);
            this.toolStripPrincipal.TabIndex = 3;
            // 
            // btnInserir
            // 
            this.btnInserir.Enabled = false;
            this.btnInserir.Image = ((System.Drawing.Image)(resources.GetObject("btnInserir.Image")));
            this.btnInserir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(28, 28);
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(28, 28);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(28, 28);
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblToolStripPrincipal
            // 
            this.lblToolStripPrincipal.Name = "lblToolStripPrincipal";
            this.lblToolStripPrincipal.Size = new System.Drawing.Size(54, 28);
            this.lblToolStripPrincipal.Text = "Cadastro";
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            this.veículoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.veículoToolStripMenuItem.Text = "Veículo";
            this.veículoToolStripMenuItem.Click += new System.EventHandler(this.veículoToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 857);
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
        private System.Windows.Forms.ToolStripMenuItem veículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeCobrançaToolStripMenuItem;
    }
}
