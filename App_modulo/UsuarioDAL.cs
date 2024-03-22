using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_modulo
{
    internal class UsuarioDAL
    {

        public static int CrearCuentas(string pUsuario, string pContraseña)
        {
            int resultado = 0;
            SqlConnection Conn = BDComun.ObtenerConexion();

            SqlCommand Comando = new SqlCommand(string.Format("Insert Into Usuario (Nombre, Contraseña) values ('{0}', PwdEncrypt('{1}'))", pUsuario, pContraseña), Conn);

            resultado = Comando.ExecuteNonQuery();
            Conn.Close();
            return resultado;
        }



        public static int Autentificar(String pUsuario, String pContraseña) 
        {
            int resultado = -1;

            SqlConnection conexion = BDComun.ObtenerConexion();

            SqlCommand comando = new SqlCommand(string.Format(
                "Select * From Usuario where Nombre = '{0}' and PwdCompare('{1}', Contraseña) = 1", pUsuario, pContraseña), conexion);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read()) 
            {
                resultado = 50;
            }

            conexion.Close();
            return resultado;
            
        }




    }
}
