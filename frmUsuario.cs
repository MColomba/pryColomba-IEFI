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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            CargarListado();
        }

        public void CargarListado()
        {
            dgvUsuarios.Rows.Clear();

            clsUsuarios ListaUsuarios = new clsUsuarios();
            List<clsUsuarios> Lista = ListaUsuarios.ListarUsuarios();

            foreach(var item in Lista)
            {
                dgvUsuarios.Rows.Add(item.GetCodigo(), item.GetNombre(), item.GetNombreRol());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
