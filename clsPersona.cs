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
        string Error;

        public clsPersona()
        {
            this.Error = "";
        }
        public void GrabarPersona()
        {

        }
         public void ModificarPersona()
        {

        }
        public void BuscarPersonaPorUsuario(int Codigo)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT * FROM Personas where Usuario = '" + Codigo + "'";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.Documento = reader["Documento"].ToString();
                        this.NombreCompleto = reader["NombreCompleto"].ToString();
                        this.Direccion = reader["Direccion"].ToString();
                        this.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                        this.Telefono = reader["Telefono"].ToString();
                    }
                }
                else
                {
                    Error = "No existe la persona";
                }
                Conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void BorrarPersona(int Codigo)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "DELETE FROM Personas WHERE Usuario = @codigo";

                SqlCommand cmd = new SqlCommand(strQuery, Conexion.GetConnection());
                cmd.Parameters.AddWithValue("@codigo", Codigo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
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
        public string GetError()
        {
            return this.Error;
        }
    }
}
