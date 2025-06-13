using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace pryColomba_IEFI
{
    internal class clsPersona
    {
        string Documento;
        string NombreCompleto;
        string Direccion;
        DateTime FechaNacimiento;
        string Telefono;

        public clsPersona()
        {

        }
        public void GrabarPersona()
        {

        }
         public void ModificarPersona()
        {

        }
        public void BuscarPersonaPorUsuario(int Codigo)
        {
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "SELECT * FROM Personas where Usuario = '" + Codigo + "'";

            SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
            SqlDataReader reader = objCommand.ExecuteReader();

            while (reader.Read())
            {
                this.Documento = reader["Documento"].ToString();
                this.NombreCompleto = reader["NombreCompleto"].ToString();
                this.Direccion = reader["Direccion"].ToString();
                this.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                this.Telefono = reader["Telefono"].ToString();
            }
        }

        public void BorrarPersona()
        {

        }

        //Gets
        public string GetDocumento()
        {
            return this.Documento;
        }
        public string GetNombreCompleto()
        {
            return this.NombreCompleto;
        }
        public string GetDireccion()
        {
            return this.Direccion;
        }
        public DateTime GetFechaNacimiento()
        {
            return this.FechaNacimiento;
        }
        public string GetTelefono()
        {
            return this.Telefono;
        }
    }
}
