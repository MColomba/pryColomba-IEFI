using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryColomba_IEFI
{
    internal class clsAuditoria
    {
        //Atributos
        int Usuario;
        string NomUsuario;
        DateTime Fecha;
        double TiempoUso;
        string Error;

        //Constructores
        public clsAuditoria(int Usuario)
        {
            this.Usuario = Usuario;
            this.NomUsuario = string.Empty;
            this.Fecha = DateTime.Now;
            this.TiempoUso = 0;
            this.Error = "";
        }
        public clsAuditoria(int Usuario, string NomUsuario, DateTime Fecha, double TiempoUso)
        {
            this.Usuario = Usuario;
            this.NomUsuario = NomUsuario;
            this.Fecha = Fecha;
            this.TiempoUso= TiempoUso;
            this.Error = "";
        }

        //Sets
        public void SetTiempoUso(DateTime Actual)
        {
            this.TiempoUso = Actual.Subtract(Fecha).Minutes;
        }

        //Funciones
        public void GrabarAuditoria()
        {
            try
            {
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "INSERT INTO Auditoria (Usuario, Fecha, TiempoUso) VALUES (@usuario, @fecha, @tiempoUso)";

                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                objCommand.Parameters.AddWithValue("@usuario", this.Usuario);
                objCommand.Parameters.AddWithValue("@fecha", this.Fecha.Date);
                objCommand.Parameters.AddWithValue("@tiempoUso", TiempoUso);
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public List<clsAuditoria> ListarAuditoriaCompleto()
        {
            try
            {
                List<clsAuditoria> ListaCompleta = new List<clsAuditoria>();
                clsConexionBD Conexion = new clsConexionBD();
                clsAuditoria item;

                string strQuery = "Select a.Usuario, u.Nombre, a.Fecha, a.TiempoUso from Auditoria a JOIN Usuarios u on u.Codigo = a.Usuario";
                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item = new clsAuditoria(int.Parse(reader["Usuario"].ToString()), reader["Nombre"].ToString(), DateTime.Parse(reader["Fecha"].ToString()), double.Parse(reader["TiempoUso"].ToString()));
                        ListaCompleta.Add(item);
                    }
                }
                else
                {
                    Error = "No hay registros";
                    return null;
                }
                Conexion.CloseConnection();

                return ListaCompleta;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
            
        }
        public List<clsAuditoria> ListarAuditoriaResumido()
        {
            try
            {
                List<clsAuditoria> ListaCompleta = new List<clsAuditoria>();
                clsConexionBD Conexion = new clsConexionBD();

                string strQuery = "SELECT a.Usuario, u.Nombre, a.Fecha, SUM(a.TiempoUso) AS TiempoUsoTotal FROM Auditoria a JOIN (SELECT DISTINCT Codigo, Nombre FROM Usuarios) u ON u.Codigo = a.Usuario GROUP BY a.Usuario, u.Nombre, a.Fecha ORDER BY a.Usuario";
                SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
                SqlDataReader reader = objCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clsAuditoria item = new clsAuditoria(int.Parse(reader["Usuario"].ToString()), reader["Nombre"].ToString(), DateTime.Parse(reader["Fecha"].ToString()), double.Parse(reader["TiempoUsoTotal"].ToString()));
                        ListaCompleta.Add(item);
                    }
                }
                else
                {
                    Error = "No hay registros";
                    return null;
                }
                Conexion.CloseConnection();

                return ListaCompleta;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }

        //Gets
        public int GetUsuario()
        {
           return this.Usuario;
        }
        public string GetNomUsuario()
        {
            return this.NomUsuario;
        }
        public DateTime GetFecha()
        {
            return this.Fecha;
        }
        public double GetTiempoUso()
        {
            return this.TiempoUso;
        }
    }
}
