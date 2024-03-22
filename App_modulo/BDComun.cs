using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using App_modulo.Properties;
using System.Configuration;

namespace App_modulo
{
    public class BDComun
        
    {
        public static string ObtenerString()
        {
            return Settings.Default.ModuloDBConnectionString;
        }
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection(ObtenerString());
            Conn.Open();

            return Conn;
        }
    }
}
