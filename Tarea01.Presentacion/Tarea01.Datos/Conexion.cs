using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tarea01.Datos
{
    public class Conexion
    {
        // Declaración de variables para la conexión al servidor
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;

        private static Conexion Con = null;

        // Datos para hacer la conexión al servidor
        private Conexion()
        {
            this.Base = "tarea01";
            this.Servidor = "192.168.1.2";
            this.Usuario = "sa";
            this.Clave = "aoz0110";
            this.Seguridad = true;
        }

        // Método para crear la conexión
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = "Server =" + this.Servidor + " ; Database = " + this.Base + ";";

                if (this.Seguridad) // Seguridad de Windows
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security = SSPI;";
                }
                else // Seguridad de SQL Server
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id = " + this.Usuario + "; Password = " + this.Clave + ";";
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        // Método para instanciar una conexión
        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }

            return Con;
        }
    }
}
