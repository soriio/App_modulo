using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_modulo
{
    public class SuministroDAL
    {
        public static int Agregar(Suministro sSuministro) 
        {
            int retorno = 0;
            using (SqlConnection conn = BDComun.ObtenerConexion())
            {
                SqlCommand Comando=new SqlCommand(string.Format("Insert Into supply ( EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACIÓN) values ('{0}', '{1}', '{2}', '{3}')",
                    sSuministro.EQUIPO, sSuministro.TRANSPORTE, sSuministro.INSTALACION, sSuministro.CONFIGURACION), conn);

                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }


        public static List<Suministro> BuscarSuministro(String sEQUIPO)
        {
            List<Suministro> Lista = new List<Suministro>();
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(String.Format("Select ID, EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACION from supply where EQUIPO like '%{0}%'", sEQUIPO), conexion);

                SqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read())
                {
                    Suministro sSuministro = new Suministro();
                    {
                        sSuministro.ID = reader.GetInt32(0);
                        sSuministro.EQUIPO = reader.IsDBNull(1) ? null : reader.GetString(1);
                        sSuministro.TRANSPORTE = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                        sSuministro.INSTALACION = reader.IsDBNull(3) ? null : reader.GetDecimal(3).ToString("N2");
                        sSuministro.CONFIGURACION = reader.IsDBNull(4) ? null : reader.GetDecimal(4).ToString("N2");

                    };
                    Lista.Add(sSuministro);
                }
                conexion.Close();
                return Lista;
            }
        }


        public static Suministro ObtenerSuministro(Int32 sID)
        {
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                Suministro sSuministro = new Suministro();
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select ID, EQUIPO, TRANSPORTE, INSTALACION, CONFIGURACION from supply where ID={0}", sID), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    {
                        sSuministro.ID = reader.GetInt32(0);
                        sSuministro.EQUIPO = reader.IsDBNull(1) ? null : reader.GetString(1);
                        sSuministro.TRANSPORTE = reader.IsDBNull(2) ? null : reader.GetDecimal(2).ToString("N2");
                        sSuministro.INSTALACION = reader.IsDBNull(3) ? null : reader.GetDecimal(3).ToString("N2");
                        sSuministro.CONFIGURACION = reader.IsDBNull(4) ? null : reader.GetDecimal(4).ToString("N2");
                    };
                }
                conexion.Close();
                return sSuministro;
            }
        }



        public static int Modicar(Suministro sSuministro)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE supply SET EQUIPO = '{0}', TRANSPORTE = '{1}', INSTALACION = '{2}', CONFIGURACION = '{3}' WHERE ID = '{4}'",
                    sSuministro.EQUIPO, sSuministro.TRANSPORTE, sSuministro.INSTALACION, sSuministro.CONFIGURACION, sSuministro.ID), conexion);

                comando.Parameters.AddWithValue("@EQUIPO", sSuministro.EQUIPO);
                comando.Parameters.AddWithValue("@TRANSPORTE", sSuministro.TRANSPORTE);
                comando.Parameters.AddWithValue("@INSTALACION", sSuministro.INSTALACION);
                comando.Parameters.AddWithValue("@CONFIGURACION", sSuministro.CONFIGURACION);
                comando.Parameters.AddWithValue("@ID", sSuministro.ID);

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
                SqlCommand comando = new SqlCommand(string.Format("Delete from supply where ID={0}", sID), conexion);
                retorno =comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }


    }
}
