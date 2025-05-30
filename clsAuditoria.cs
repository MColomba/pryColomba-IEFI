using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
