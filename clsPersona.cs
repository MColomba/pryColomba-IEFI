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
        public void GrabarPersona(int Codigo, string Documento, string NombreCompleto, string Direccion, DateTime FechaNacimiento, string Telefono)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "INSERT INTO Personas (Usuario, Documento, NombreCompleto, Direccion, FechaNacimiento, Telefono) VALUES (@usuario, @documento, @nombre, @direccion, @fecha, @telefono)";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                objCommand.Parameters.AddWithValue("@usuario", Codigo);
                objCommand.Parameters.AddWithValue("@documento", Documento);
                objCommand.Parameters.AddWithValue("@nombre", NombreCompleto);
                objCommand.Parameters.AddWithValue("@direccion", Direccion);
                objCommand.Parameters.AddWithValue("@fecha", FechaNacimiento.Date);
                objCommand.Parameters.AddWithValue("@telefono", Telefono);
                objCommand.ExecuteNonQuery();
                Conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public void ModificarPersona(int Codigo, string Documento, string NombreCompleto, string Direccion, DateTime FechaNacimiento, string Telefono)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "UPDATE Personas SET Documento = @documento, NombreCompleto = @nombre, Direccion = @direccion, FechaNacimiento = @fecha, Telefono = @telefono where Usuario = @codigo";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                objCommand.Parameters.AddWithValue("@codigo", Codigo);
                objCommand.Parameters.AddWithValue("@documento", Documento);
                objCommand.Parameters.AddWithValue("@nombre", NombreCompleto);
                objCommand.Parameters.AddWithValue("@direccion", Direccion);
                objCommand.Parameters.AddWithValue("@fecha", FechaNacimiento.Date);
                objCommand.Parameters.AddWithValue("@telefono", Telefono);
                objCommand.ExecuteNonQuery();
                Conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public void BuscarPersonaPorUsuario(int Codigo)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT * FROM Personas where Usuario = " + Codigo;

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
