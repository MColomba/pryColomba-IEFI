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
        DateTime Fecha;
        double TiempoUso;

        public clsAuditoria(int Usuario)
        {
            this.Usuario = Usuario;
            this.Fecha = DateTime.Now;
            this.TiempoUso = 0;
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
    }
}
