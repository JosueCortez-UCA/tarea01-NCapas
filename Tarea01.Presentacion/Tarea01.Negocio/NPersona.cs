using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tarea01.Datos;
using Tarea01.Entidades;

namespace Tarea01.Negocio
{
    public class NPersona
    {
        // Método que hace uso del método de listar en la capa de datos.
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();
        }

        // Método que hace uso del método de insertar en la capa de datos.
        public static string Insertar(string Nombre, string Apellido, int Edad, string Telefono)
        {
            DPersona Datos = new DPersona();
            Persona Obj = new Persona();

            Obj.Nombre = Nombre;
            Obj.Apellido = Apellido;
            Obj.Edad = Edad;
            Obj.Telefono= Telefono;

            return Datos.Insertar(Obj);
        }
    }
}
