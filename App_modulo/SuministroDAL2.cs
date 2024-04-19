using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_modulo
{
    public class SuministroDAL2
    {
        public static int Agregar(Suministro2 sSuministro2)
        {
            int retorno = 0;
            using (SqlConnection conn = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into TIPO ( EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACIÓN, MANTENIMIENTO) values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    sSuministro2.EQUIPO, sSuministro2.TRANSPORTE, sSuministro2.INSTALACION, sSuministro2.CONFIGURACION, sSuministro2.MANTENIMIENTO), conn);

                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }


        public static List<Suministro2> BuscarSuministro2(String sEQUIPO)
        {
            List<Suministro2> Lista = new List<Suministro2>();
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Select ID, EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACION, MANTENIMIENTO from TIPO where EQUIPO like '%{0}%'", sEQUIPO), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Suministro2 sSuministro2 = new Suministro2();
                    {
                        sSuministro2.ID = reader.GetInt32(0);
                        sSuministro2.EQUIPO = reader.IsDBNull(1) ? null : reader.GetString(1);
                        sSuministro2.TRANSPORTE = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                        sSuministro2.INSTALACION = reader.IsDBNull(3) ? null : reader.GetDecimal(3).ToString("N2");
                        sSuministro2.CONFIGURACION = reader.IsDBNull(4) ? null : reader.GetDecimal(4).ToString("N2");
                        sSuministro2.MANTENIMIENTO = reader.IsDBNull(5) ? null : reader.GetDecimal(5).ToString("N2");

                    };
                    Lista.Add(sSuministro2);
                }
                conexion.Close();
                return Lista;
            }
        }


        public static Suministro2 ObtenerSuministro2(Int32 sID)
        {
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                Suministro2 sSuministro2 = new Suministro2();
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select ID, EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACION, MANTENIMIENTO from TIPO where ID={0}", sID), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    {
                        sSuministro2.ID = reader.GetInt32(0);
                        sSuministro2.EQUIPO = reader.IsDBNull(1) ? null : reader.GetString(1);
                        sSuministro2.TRANSPORTE = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                        sSuministro2.INSTALACION = reader.IsDBNull(3) ? null : reader.GetDecimal(3).ToString("N2");
                        sSuministro2.CONFIGURACION = reader.IsDBNull(4) ? null : reader.GetDecimal(4).ToString("N2");
                        sSuministro2.MANTENIMIENTO = reader.IsDBNull(5) ? null : reader.GetDecimal(5).ToString("N2");
                    };
                }
                conexion.Close();
                return sSuministro2;
            }
        }


        public static int Modicar(Suministro2 sSuministro2)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE TIPO SET EQUIPO = '{0}', TRANSPORTE = '{1}', INSTALACION = '{2}', CONFIGURACION = '{3}', MANTENIMIENTO = '{4}' WHERE ID = '{5}'",
                    sSuministro2.EQUIPO, sSuministro2.TRANSPORTE, sSuministro2.INSTALACION, sSuministro2.CONFIGURACION,sSuministro2.MANTENIMIENTO, sSuministro2.ID), conexion);

                comando.Parameters.AddWithValue("@EQUIPO", sSuministro2.EQUIPO);
                comando.Parameters.AddWithValue("@TRANSPORTE", sSuministro2.TRANSPORTE);
                comando.Parameters.AddWithValue("@INSTALACION", sSuministro2.INSTALACION);
                comando.Parameters.AddWithValue("@CONFIGURACION", sSuministro2.CONFIGURACION);
                comando.Parameters.AddWithValue("@MANTENIMIENTO", sSuministro2.MANTENIMIENTO);
                comando.Parameters.AddWithValue("@ID", sSuministro2.ID);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }


        public static int Eliminar(Int32 sID)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Delete from TIPO where ID={0}", sID), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }



    }
}
