﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryColomba_IEFI
{
    internal class clsConexionBD
    {
        string strConnection = "Server=localhost;Database=IEFI;Trusted_Connection=True;";
        SqlConnection objConnection;
        string strError;

        public clsConexionBD()
        {
            try
            {
                objConnection = new SqlConnection(strConnection);
                objConnection.Open();
                strError = "";
            }
            catch (Exception ex)
            {
                strError = "Error al conectar con la base de datos: " + ex.Message;
            }

        }
        public void CloseConnection()
        {
            this.objConnection.Close();
        }
        public SqlConnection GetConnection()
        {
            return objConnection;
        }
        public string GetError()
        {
            return strError;
        }
    }
}
