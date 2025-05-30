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
        public frmPrincipal(int Codigo, string Nombre)
        {
            InitializeComponent();
            CodigoUsuario = Codigo;
            lblUsuario.Text = Nombre;
            lblFecha.Text = DateTime.Now.ToString();
        }
        public void IniciarAuditoria()
        {

        }
        public void TerminarAuditoria()
        {

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
    }
}
