using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryColomba_IEFI
{
    internal class clsUsuarios
    {
        //Atributos
        int Codigo;
        string Nombre;
        int Rol;
        string Contraseña;
        string NombreRol;
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
        public clsUsuarios(int Codigo, string Nombre, int CodigoRol, string NombreRol)
        {
            this.Codigo = Codigo;
            this.Nombre = Nombre;
            this.Rol = CodigoRol;
            this.NombreRol = NombreRol;
            this.Error = "";
        }
        //Funciones
        public bool ValidarUsuario(string Nombre, string Contraseña)
        {
            try
            {
                bool Validado = false;
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT * FROM Usuarios where NOMBRE = '" + Nombre + "'";

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
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public void GrabarUsuario(string Contraseña)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "INSERT INTO Usuarios (Nombre, Contraseña, Rol) VALUES (@nombre, @contraseña, @rol)";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                objCommand.Parameters.AddWithValue("@nombre", this.Nombre);
                objCommand.Parameters.AddWithValue("@contraseña", Contraseña);
                objCommand.Parameters.AddWithValue("@rol", this.Rol);
                objCommand.ExecuteNonQuery();
                Conexion.CloseConnection();
            }
            catch(Exception ex)
            {
                Error = ex.Message;
            }
        }
        public void BuscarUsuario(int Codigo)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT * FROM Usuarios where Codigo = '" + Codigo + "'";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.Nombre = reader["Nombre"].ToString();
                        this.Rol = int.Parse(reader["Rol"].ToString());
                        this.Contraseña = reader["Contraseña"].ToString();
                    }
                }
                else
                {
                    Error = "No existe el usuario";
                }
                Conexion.CloseConnection();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void EliminarUsuario(int Codigo)
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "DELETE FROM Usuarios WHERE Codigo = @codigo";

                SqlCommand cmd = new SqlCommand(strQuery, Conexion.GetConnection());
                cmd.Parameters.AddWithValue("@codigo", Codigo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public void ModificarUsuario()
        {

        }
        public List<clsUsuarios> ListarUsuarios()
        {
            try
            {
                List<clsUsuarios> Lista = new List<clsUsuarios>();

                clsConexionBD Conexion = new clsConexionBD();
                clsUsuarios item;

                string strQuery = "SELECT u.Codigo, u.Nombre, r.Codigo as CodigoRol, r.NombreRol FROM Usuarios u JOIN Roles r on r.Codigo = u.Rol";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = new clsUsuarios(int.Parse(reader["Codigo"].ToString()), reader["Nombre"].ToString(), int.Parse(reader["CodigoRol"].ToString()), reader["NombreRol"].ToString());
                        Lista.Add(item);
                    }
                }
                else
                {
                    Lista = null;
                }

                return Lista;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
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
        public string GetContraseña()
        {
            return this.Contraseña;
        }
        public int GetCodigo()
        {
            return this.Codigo;
        }
        public int GetRol()
        {
            return this.Rol;
        }
        public string GetNombreRol()
        {
            return this.NombreRol;
        }
    }
}
