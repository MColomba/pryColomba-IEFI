namespace pryColomba_IEFI
{
    partial class frmAuditoria
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
            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.mnuModulos = new System.Windows.Forms.MenuStrip();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.detalleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBuscarUsuario = new System.Windows.Forms.Label();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.mnuModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAuditoria
            // 
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            this.dgvAuditoria.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditoria.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvAuditoria.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAuditoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoria.Location = new System.Drawing.Point(12, 73);
            this.dgvAuditoria.Name = "dgvAuditoria";
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoria.Size = new System.Drawing.Size(379, 353);
            this.dgvAuditoria.TabIndex = 0;
            // 
            // mnuModulos
            // 
            this.mnuModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mnuModulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuario,
            this.mnuSalir});
            this.mnuModulos.Location = new System.Drawing.Point(0, 0);
            this.mnuModulos.Name = "mnuModulos";
            this.mnuModulos.Size = new System.Drawing.Size(404, 24);
            this.mnuModulos.TabIndex = 1;
            this.mnuModulos.Text = "mnuModulos";
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detalleToolStripMenuItem,
            this.resumenToolStripMenuItem});
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(59, 20);
            this.mnuUsuario.Text = "Usuario";
            // 
            // detalleToolStripMenuItem
            // 
            this.detalleToolStripMenuItem.Name = "detalleToolStripMenuItem";
            this.detalleToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.detalleToolStripMenuItem.Text = "Detalle";
            // 
            // resumenToolStripMenuItem
            // 
            this.resumenToolStripMenuItem.Name = "resumenToolStripMenuItem";
            this.resumenToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.resumenToolStripMenuItem.Text = "Resumen";
            // 
            // lblBuscarUsuario
            // 
            this.lblBuscarUsuario.AutoSize = true;
            this.lblBuscarUsuario.Location = new System.Drawing.Point(13, 39);
            this.lblBuscarUsuario.Name = "lblBuscarUsuario";
            this.lblBuscarUsuario.Size = new System.Drawing.Size(79, 13);
            this.lblBuscarUsuario.TabIndex = 2;
            this.lblBuscarUsuario.Text = "Buscar Usuario";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Location = new System.Drawing.Point(98, 36);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtBuscarUsuario.TabIndex = 3;
            // 
            // btnRecargar
            // 
            this.btnRecargar.BackColor = System.Drawing.Color.LightGray;
            this.btnRecargar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargar.Location = new System.Drawing.Point(204, 36);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(20, 20);
            this.btnRecargar.TabIndex = 4;
            this.btnRecargar.UseVisualStyleBackColor = false;
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(41, 20);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // frmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.txtBuscarUsuario);
            this.Controls.Add(this.lblBuscarUsuario);
            this.Controls.Add(this.dgvAuditoria);
            this.Controls.Add(this.mnuModulos);
            this.MainMenuStrip = this.mnuModulos;
            this.Name = "frmAuditoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.mnuModulos.ResumeLayout(false);
            this.mnuModulos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditoria;
        private System.Windows.Forms.MenuStrip mnuModulos;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuario;
        private System.Windows.Forms.ToolStripMenuItem detalleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenToolStripMenuItem;
        private System.Windows.Forms.Label lblBuscarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
    }
}