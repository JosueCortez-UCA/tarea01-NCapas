using System;
using System.Data;
using System.Data.SqlClient;
using Tarea01.Entidades;

namespace Tarea01.Datos
{
    public class DPersona
    {
        // Método para listar las personas.
        public DataTable Listar()
        {
            SqlDataReader Resultados;
            DataTable Tabla = new DataTable();

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("listar_personas", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;

                SqlCon.Open();
                Resultados = Comando.ExecuteReader();
                Tabla.Load(Resultados);

                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        // Método para insertar
        public string Insertar(Persona Obj)
        {
            string Rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("insertar_personas_sinrol", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("@apellido", SqlDbType.VarChar).Value = Obj.Apellido;
                Comando.Parameters.Add("@edad", SqlDbType.VarChar).Value = Obj.Edad;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.Telefono;

                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Rpta;
        }
    }
}
