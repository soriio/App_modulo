using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_modulo
{
    internal class SalarioDAL
    {

        public static int Agregar(Salario vSalario)
        {
            int retorno = 0;
            using (SqlConnection conn = BDComun.ObtenerConexion())
            {
                string ocupacion = string.IsNullOrEmpty(vSalario.OCUPACION) ? " " : vSalario.OCUPACION;
    string valorDia = string.IsNullOrEmpty(vSalario.VALORDIA) ? " " : vSalario.VALORDIA;


                SqlCommand Comando = new SqlCommand(string.Format("Insert Into Salary ( OCUPACION, VALORDIA) values ( '{0}', '{1}')",
                   vSalario.OCUPACION, vSalario.VALORDIA), conn);

                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static List<Salario> BuscarSalario(String vOCUPACION)
        {
            List<Salario> Lista = new List<Salario>();
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Select ID, OCUPACION, VALORDIA from Salary where OCUPACION like '%{0}%'", vOCUPACION), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Salario vSalario = new Salario();
                    {
                        vSalario.ID = reader.GetInt32(0);
                        vSalario.OCUPACION = reader.IsDBNull(1) ? null : reader.GetString(1);
                        vSalario.VALORDIA = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                    };
                    Lista.Add(vSalario);
                }
                conexion.Close();
                return Lista;
            }
        }

        public static Salario ObtenerSalario(Int32 vID)
        {
            using (SqlConnection conexion = BDComun.ObtenerConexion() )
            {
                Salario vSalario = new Salario();
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select ID, OCUPACION, VALORDIA from Salary where ID={0}", vID), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    {
                        vSalario.ID = reader.GetInt32(0);
                        vSalario.OCUPACION = reader.IsDBNull(1) ? null : reader.GetString(1);
                        vSalario.VALORDIA = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                    };
                }
                conexion.Close (); 
                return vSalario;
            }
        }

        public static int Modificar(Salario vSalario)
        {
            int retorno = 0;
            using(SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update Salary set OCUPACION='{0}', VALORDIA='{1}' where ID='{2}'",
                    vSalario.OCUPACION, vSalario.VALORDIA, vSalario.ID), conexion);
                comando.Parameters.AddWithValue("@ocupacion", vSalario.OCUPACION);
                comando.Parameters.AddWithValue("@valorDia", vSalario.VALORDIA);
                comando.Parameters.AddWithValue("@id", vSalario.ID);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int Eliminar(Int32 vID)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Delete from Salary where ID={0}", vID), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }
    }
}
