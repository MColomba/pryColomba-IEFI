namespace pryColomba_IEFI
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.mnuModulos = new System.Windows.Forms.MenuStrip();
            this.mnuTareas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdminAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrar = new System.Windows.Forms.ToolStripMenuItem();
            this.sstConexion = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuModulos.SuspendLayout();
            this.sstConexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuModulos
            // 
            this.mnuModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mnuModulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTareas,
            this.mnuAdministracion,
            this.mnuCerrar});
            this.mnuModulos.Location = new System.Drawing.Point(0, 0);
            this.mnuModulos.Name = "mnuModulos";
            this.mnuModulos.Size = new System.Drawing.Size(800, 24);
            this.mnuModulos.TabIndex = 0;
            this.mnuModulos.Text = "mnuModulos";
            // 
            // mnuTareas
            // 
            this.mnuTareas.Name = "mnuTareas";
            this.mnuTareas.Size = new System.Drawing.Size(51, 20);
            this.mnuTareas.Text = "Tareas";
            // 
            // mnuAdministracion
            // 
            this.mnuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdminUsuarios,
            this.mnuAdminAuditoria});
            this.mnuAdministracion.Name = "mnuAdministracion";
            this.mnuAdministracion.Size = new System.Drawing.Size(100, 20);
            this.mnuAdministracion.Text = "Administracion";
            // 
            // mnuAdminUsuarios
            // 
            this.mnuAdminUsuarios.Name = "mnuAdminUsuarios";
            this.mnuAdminUsuarios.Size = new System.Drawing.Size(123, 22);
            this.mnuAdminUsuarios.Text = "Usuarios";
            this.mnuAdminUsuarios.Click += new System.EventHandler(this.mnuAdminUsuarios_Click);
            // 
            // mnuAdminAuditoria
            // 
            this.mnuAdminAuditoria.Name = "mnuAdminAuditoria";
            this.mnuAdminAuditoria.Size = new System.Drawing.Size(123, 22);
            this.mnuAdminAuditoria.Text = "Auditoria";
            this.mnuAdminAuditoria.Click += new System.EventHandler(this.mnuAdminAuditoria_Click);
            // 
            // mnuCerrar
            // 
            this.mnuCerrar.Name = "mnuCerrar";
            this.mnuCerrar.Size = new System.Drawing.Size(88, 20);
            this.mnuCerrar.Text = "Cerrar Sesion";
            this.mnuCerrar.Click += new System.EventHandler(this.mnuCerrar_Click);
            // 
            // sstConexion
            // 
            this.sstConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.sstConexion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.lblFecha});
            this.sstConexion.Location = new System.Drawing.Point(0, 428);
            this.sstConexion.Name = "sstConexion";
            this.sstConexion.Size = new System.Drawing.Size(800, 22);
            this.sstConexion.TabIndex = 1;
            this.sstConexion.Text = "statusStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(47, 17);
            this.lblUsuario.Text = "Usuario";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 17);
            this.lblFecha.Text = "Fecha";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.sstConexion);
            this.Controls.Add(this.mnuModulos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuModulos;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla Principal";
            this.mnuModulos.ResumeLayout(false);
            this.mnuModulos.PerformLayout();
            this.sstConexion.ResumeLayout(false);
            this.sstConexion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuModulos;
        private System.Windows.Forms.ToolStripMenuItem mnuTareas;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem mnuAdminUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuAdminAuditoria;
        private System.Windows.Forms.StatusStrip sstConexion;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrar;
    }
}