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
        //Atributos
        int Codigo;
        string Nombre;
        int Rol;
        string Error;

        //Constructor
        public clsUsuarios()
        {
            Codigo = 0;
            Nombre = "";
            Error = "";
        }
        public clsUsuarios(string Nombre, int Rol)
        {
            this.Codigo = 0;
            this.Nombre = Nombre;
            this.Rol = Rol;
            this.Error = "";
        }
        //Funciones
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
                        this.Rol = int.Parse(reader["Rol"].ToString());
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

        public void GrabarUsuario(string Contraseña)
        {
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "INSERT INTO Usuarios (Nombre, Contraseña, Rol) VALUES (@nombre, @contraseña, @rol)";

            SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
            objCommand.Parameters.AddWithValue("@nombre", this.Nombre);
            objCommand.Parameters.AddWithValue("@contraseña", Contraseña);
            objCommand.Parameters.AddWithValue("@rol", this.Rol);
            objCommand.ExecuteNonQuery();
        }

        //Gets
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
