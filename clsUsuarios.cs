using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryColomba_IEFI
{
    internal class clsUsuarios
    {
        int Codigo;
        string Nombre;
        string Error;

        public clsUsuarios()
        {
            Codigo = 0;
            Nombre = "";
            Error = "";
        }
        public bool ValidarUsuario(string Nombre, string Contraseña)
        {
            bool Validado = false;
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "SELECT * FROM Usuarios where NOMBRE = '" + Nombre +"'";

            SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
            SqlDataReader reader = objCommand.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["Contraseña"].ToString() == Contraseña)
                    {
                        this.Codigo = Convert.ToInt32(reader["Codigo"]);
                        this.Nombre = reader["Nombre"].ToString();
                        Validado = true;
                    }
                    else
                    {
                        Error = "Contraseña Incorrecta";
                        Validado = false;
                    }
                }
            }
            else
            {
                Error = "No existe el usuario";
                Validado = false;
            }
            Conexion.CloseConnection();

            return Validado;
        }
        public string GetError()
        {
            return this.Error;
        }
        public string GetNombre()
        {
            return this.Nombre;
        }
        public int GetCodigo()
        {
            return this.Codigo;
        }
    }
}
