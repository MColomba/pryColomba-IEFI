using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryColomba_IEFI
{
    public partial class frmPrincipal : Form
    {
        clsAuditoria Auditoria;
        int CodigoUsuario;
        int Rol;

        public frmPrincipal(int Codigo, string Nombre, int Rol)
        {
            InitializeComponent();
            CodigoUsuario = Codigo;
            lblUsuario.Text = Nombre;
            lblFecha.Text = DateTime.Now.ToString();
            this.Rol = Rol;
            if (Rol != 1)
            {
                mnuAdministracion.Visible = false;
            }
            IniciarAuditoria();
        }
        public void IniciarAuditoria()
        {
            Auditoria = new clsAuditoria(CodigoUsuario);
        }
        public void TerminarAuditoria()
        {
            Auditoria.SetTiempoUso(DateTime.Now);
            Auditoria.GrabarAuditoria();
        }

        private void mnuCerrar_Click(object sender, EventArgs e)
        {
            TerminarAuditoria();
            this.Close();
        }

        private void mnuAdminAuditoria_Click(object sender, EventArgs e)
        {
            frmAuditoria Auditoria = new frmAuditoria();
            Auditoria.ShowDialog();
        }

        private void mnuAdminUsuarios_Click(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();
            Usuario.ShowDialog();
        }
    }
}
