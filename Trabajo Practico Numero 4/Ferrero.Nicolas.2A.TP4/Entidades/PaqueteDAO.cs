using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static PaqueteDAO()
        {

        }

        public static bool Insertar(Paquete p)
        {
            bool rta = false;
            int comando = 0;

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Nicolas Ferrero')", conn);

            try
            {
                conn.Open();
                comando = cmd.ExecuteNonQuery();
                if(comando > 0)
                {
                    rta = true;
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return rta;
        }
    }
}
