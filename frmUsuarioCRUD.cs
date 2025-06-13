using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryColomba_IEFI
{
    public partial class frmUsuarioCRUD : Form
    {
        int Modo;
        int CodigoUsuario;
        clsUsuarios Usuario;
        clsPersona Persona;
        public frmUsuarioCRUD(int modo, int codigoUsuario)
        {
            InitializeComponent();
            Modo = modo;
            CodigoUsuario = codigoUsuario;
            Usuario = new clsUsuarios();
            Persona = new clsPersona();
            CargarModo();
        }
        private void CargarModo()
        {
            switch (Modo)
            {
                //Consultar
                case 0:
                    this.Text += "Consulta";
                    CargarDatos();
                    //No se puede tocar ningun dato
                    txtUsuario.Enabled = false;
                    cmbRol.Enabled = false;
                    txtContraseña.Enabled = false;
                    txtDocumento.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    txtDireccion.Enabled = false;
                    dtpFechaNacimiento.Enabled = false;
                    txtTelefono.Enabled = false;
                    //No se puede tocar grabar por accidente
                    btnGrabar.Visible = false;
                    break;
                //Agregar
                case 1:
                    this.Text += "Agregar";
                    CargarCmbRol();
                    break;
                //Modificar
                case 2:
                    this.Text += "Modificar";
                    CargarDatos();
                    break;
                //Error
                default:
                    MessageBox.Show("Error al inicializar el formulario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        public void CargarDatos()
        {
            Usuario.BuscarUsuario(CodigoUsuario);
            if (Usuario.GetError() == "")
            {
                txtUsuario.Text = Usuario.GetNombre();
                if (CargarCmbRol() == true)
                {
                    cmbRol.SelectedIndex = Usuario.GetRol() - 1;
                }
                txtContraseña.Text = Usuario.GetContraseña();
                Persona.BuscarPersonaPorUsuario(CodigoUsuario);
                if (Persona.GetError() == "")
                {
                    txtDocumento.Text = Persona.GetDocumento();
                    txtNombreCompleto.Text = Persona.GetNombreCompleto();
                    txtDireccion.Text = Persona.GetDireccion();
                    dtpFechaNacimiento.Value = Persona.GetFechaNacimiento();
                    txtTelefono.Text = Persona.GetTelefono();
                }
                else
                {
                    MessageBox.Show(Persona.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(Usuario.GetError(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }        
        }
        public bool Validar()
        {
            bool valida = true;
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Falta completar el campo Usuario", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Falta completar el campo Contraseña", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Falta completar el campo Rol", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (txtDocumento.Text == "")
            {
                MessageBox.Show("Falta completar el campo Documento", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (txtNombreCompleto.Text == "")
            {
                MessageBox.Show("Falta completar el campo Apellido, Nombre", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Falta completar el campo Direccion", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (dtpFechaNacimiento.Value >= DateTime.Now)
            {
                MessageBox.Show("Fecha Incorrecta", "Fecha Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Falta completar el campo Telefono", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                valida = false;
            }
            return valida;
        }
        public bool CargarCmbRol()
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT * FROM Roles";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();

                while (reader.Read())
                {
                    cmbRol.Items.Insert(int.Parse(reader["Codigo"].ToString()) - 1, reader["NombreRol"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el combo de Roles", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                return false;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            switch (Modo)
            {
                //Consultar
                case 0:
                    MessageBox.Show("No se deberia de poder ver este boton a la hora de consultar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                //Agregar
                case 1:
                    if (Validar() == true)
                    {
                        Usuario.GrabarUsuario(txtUsuario.Text, txtContraseña.Text, cmbRol.SelectedIndex + 1);
                        int auxCodigo = Usuario.BuscarCodUsuarioPorNombre(txtUsuario.Text);
                        Persona.GrabarPersona(auxCodigo, txtDocumento.Text, txtNombreCompleto.Text, txtDireccion.Text, dtpFechaNacimiento.Value, txtTelefono.Text);
                    }
                    break;
                //Modificar
                case 2:
                    if (Validar() == true)
                    {
                        Usuario.ModificarUsuario(CodigoUsuario, txtUsuario.Text, txtContraseña.Text, cmbRol.SelectedIndex + 1);
                        Persona.ModificarPersona(CodigoUsuario, txtDocumento.Text, txtNombreCompleto.Text, txtDireccion.Text, dtpFechaNacimiento.Value, txtTelefono.Text);
                    }
                    break;
                //Error
                default:
                    MessageBox.Show("Error en boton Grabar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            this.Close();
        }
    }
}
