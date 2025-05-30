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
        int Usuario;
        string NomUsuario;
        DateTime Fecha;
        double TiempoUso;
        string Error;

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
            this.NomUsuario= string.Empty;
            this.Fecha = Fecha;
            this.TiempoUso= TiempoUso;
            this.Error = string.Empty;
        }
        public void SetTiempoUso(DateTime Actual)
        {
            this.TiempoUso = Fecha.Subtract(Actual).Minutes;
        }
        public void GrabarAuditoria()
        {
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "INSERT INTO Auditoria (Usuario, Fecha, TiempoUso) VALUES (@usuario, @fecha, @tiempoUso)";

            SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
            SqlDataReader reader = objCommand.ExecuteReader();
            objCommand.Parameters.AddWithValue("@usuario", this.Usuario);
            objCommand.Parameters.AddWithValue("@fecha", this.Fecha.Date);
            objCommand.Parameters.AddWithValue("@tiempoUso", TiempoUso);
            objCommand.ExecuteNonQuery();
        }
        public List<clsAuditoria> ListarAuditoriaCompleto()
        {
            List<clsAuditoria> ListaCompleta = new List<clsAuditoria>();
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "Select a.Usuario, u.Nombre, a.Fecha, a.TiempoUso from Auditoria a JOIN Usuarios u on u.Codigo = a.Usuario";
            SqlCommand objCommand = new SqlCommand(strQuery, Conexion.GetConnection());
            SqlDataReader reader = objCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsAuditoria item = new clsAuditoria(int.Parse(reader["Usuario"].ToString()),reader["Nombre"].ToString(), DateTime.Parse(reader["Fecha"].ToString()), double.Parse(reader["TiempoUso"].ToString()));
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
        public List<clsAuditoria> ListarAuditoriaResumido()
        {
            List<clsAuditoria> ListaCompleta = new List<clsAuditoria>();
            clsConexionBD Conexion = new clsConexionBD();

            string strQuery = "Select a.Usuario, u.Nombre, a.Fecha, sum(a.TiempoUso) as TiempoUsoTotal from Auditoria a JOIN Usuarios u on u.Codigo = a.Usuario ORDER BY a.Usuario GROUP BY a.Usuario, u.Nombre, a.Fecha, a.TiempoUso";
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
