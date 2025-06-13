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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.Hide();

            clsUsuarios UsuarioLog = new clsUsuarios();
            if (UsuarioLog.ValidarUsuario(txtUsuario.Text, txtContraseña.Text) != false)
            {
                frmPrincipal Principal = new frmPrincipal(UsuarioLog.GetCodigo(), UsuarioLog.GetNombre(), UsuarioLog.GetRol());
                Principal.ShowDialog();
                Principal = null;
                this.Show();
            }
            else
            {
                MessageBox.Show(UsuarioLog.GetError(), "Error Inicio Sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Show();
                txtUsuario.Clear();
                txtContraseña.Clear();
            } 
        }
    }
}
