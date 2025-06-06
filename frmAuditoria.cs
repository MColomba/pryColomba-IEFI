using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace pryColomba_IEFI
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
            cmbTipoListado.SelectedIndex = 0;
            CargarListado();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CargarListado()
        {
            dgvAuditoria.Rows.Clear();
            dgvAuditoria.Columns.Clear();

            clsAuditoria Auditoria = new clsAuditoria(0);
            switch (cmbTipoListado.SelectedIndex)
            {
                case 0:
                    List<clsAuditoria> ListaCompleta = Auditoria.ListarAuditoriaCompleto();

                    dgvAuditoria.Columns.Add("Codigo", "Codigo");
                    dgvAuditoria.Columns.Add("Nombre", "Nombre");
                    dgvAuditoria.Columns.Add("Fecha", "Fecha");
                    dgvAuditoria.Columns.Add("TiempoUso", "Tiempo de Uso");

                    foreach (var item in ListaCompleta)
                    {
                        dgvAuditoria.Rows.Add(item.GetUsuario(), item.GetNomUsuario(), item.GetFecha().ToString("dd/MM/yyyy"), item.GetTiempoUso());
                    }
                    break;
                case 1:
                    List<clsAuditoria> ListaResumida = Auditoria.ListarAuditoriaResumido();

                    dgvAuditoria.Columns.Add("Nombre", "Nombre");
                    dgvAuditoria.Columns.Add("TiempoUso", "Tiempo de Uso Total");

                    foreach (var item in ListaResumida)
                    {
                        dgvAuditoria.Rows.Add(item.GetNomUsuario(), item.GetTiempoUso());
                    }
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //revisar https://stackoverflow.com/questions/18182029/how-to-export-datagridview-data-instantly-to-excel-on-button-click
        }
    }
}
