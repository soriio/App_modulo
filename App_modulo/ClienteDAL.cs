using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace App_modulo
{
    public class ClienteDAL
    {
        public static int Agregar(Cliente pCliente)
        {
            int retorno = 0;
            using (SqlConnection conn = BDComun.ObtenerConexion())
            {
                SqlCommand Comando=new SqlCommand(string.Format("Insert Into CLIENTES_CONSOLIDADOS ( CONTACTO, CLIENTE, TELEFONO, CELULAR, CORREO, CARGO, DIRECCION, NIT, CUIDAD, VENDEDOR) values ('{0}', '{1}', '{2}', '{3}', '{4}','{5}', '{6}', '{7}', '{8}', '{9}')",
                    pCliente.CONTACTO, pCliente.CLIENTE, pCliente.TELEFONO, pCliente.CELULAR, pCliente.CORREO, pCliente.CARGO, pCliente.DIRECCION, pCliente.NIT, pCliente.CUIDAD, pCliente.VENDEDOR),conn);

                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }

         
        public static List<Cliente> BuscarCliente(String pCONTACTO) 
        {
            List<Cliente> Lista = new List<Cliente>();
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select ID, CONTACTO, CLIENTE, TELEFONO, CELULAR, CORREO, CARGO, DIRECCION, NIT, CUIDAD, VENDEDOR from CLIENTES_CONSOLIDADOS where CONTACTO like '%{0}%'", pCONTACTO), conexion);

                SqlDataReader reader = comando.ExecuteReader();
                
                while (reader.Read()) 
                {
                    Cliente pClients = new Cliente
                    {
                        ID = reader.GetInt32(0),
                        CONTACTO = reader.IsDBNull(1) ? null : reader.GetString(1),
                        CLIENTE = reader.IsDBNull(2) ? null : reader.GetString(2),
                        TELEFONO = reader.IsDBNull(3) ? null : reader.GetString(3),
                        CELULAR = reader.IsDBNull(4) ? null : reader.GetDouble(4).ToString(),
                        CORREO = reader.IsDBNull(5) ? null : reader.GetString(5),
                        CARGO = reader.IsDBNull(6) ? null : reader.GetString(6),
                        DIRECCION = reader.IsDBNull(7) ? null : reader.GetString(7),
                        NIT = reader.IsDBNull(8) ? null : reader.GetString(8),
                        CUIDAD = reader.IsDBNull(9) ? null : reader.GetString(9),
                        VENDEDOR = reader.IsDBNull(10) ? null : reader.GetString(10)
                    };

                    Lista.Add(pClients);
                }
                conexion.Close();
                return Lista;
            }
        }


        public static Cliente ObtenerCliente(Int32 pID)
        {
          
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                Cliente pClients = new Cliente();
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select ID, CONTACTO, CLIENTE, TELEFONO, CELULAR, CORREO, CARGO, DIRECCION, NIT, CUIDAD, VENDEDOR from CLIENTES_CONSOLIDADOS where  ID={0}", pID), conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    {
                        pClients.ID = reader.GetInt32(0);
                        pClients.CONTACTO = reader.IsDBNull(1) ? null : reader.GetString(1);
                        pClients.CLIENTE = reader.IsDBNull(2) ? null : reader.GetString(2);
                        pClients.TELEFONO = reader.IsDBNull(3) ? null : reader.GetString(3);
                        pClients.CELULAR = reader.IsDBNull(4) ? null : reader.GetDouble(4).ToString();
                        pClients.CORREO = reader.IsDBNull(5) ? null : reader.GetString(5);
                        pClients.CARGO = reader.IsDBNull(6) ? null : reader.GetString(6);
                        pClients.DIRECCION = reader.IsDBNull(7) ? null : reader.GetString(7);
                        pClients.NIT = reader.IsDBNull(8) ? null : reader.GetString(8);
                        pClients.CUIDAD = reader.IsDBNull(9) ? null : reader.GetString(9);
                        pClients.VENDEDOR = reader.IsDBNull(10) ? null : reader.GetString(10);
                    };

                }
                conexion.Close();
                return pClients;
            }
        }



        public static int Modificar(Cliente pCliente)
        {
            int retorno = 0;
            using(SqlConnection  conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update CLIENTES_CONSOLIDADOS set CONTACTO='{0}', CLIENTE='{1}', TELEFONO='{2}', CELULAR='{3}', CORREO='{4}', CARGO='{5}', DIRECCION='{6}', NIT='{7}', CUIDAD='{8}', VENDEDOR='{9}' where ID={10}",
                pCliente.CONTACTO, pCliente.CLIENTE, pCliente.TELEFONO, pCliente.CELULAR, pCliente.CORREO, pCliente.CARGO, pCliente.DIRECCION, pCliente.NIT, pCliente.CUIDAD, pCliente.VENDEDOR, pCliente.ID), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }


        public static int Eliminar(Int32 pID)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Delete from CLIENTES_CONSOLIDADOS where ID={0}", pID), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }


    }
}
