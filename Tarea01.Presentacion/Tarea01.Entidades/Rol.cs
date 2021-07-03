namespace Tarea01.Entidades
{
    // Entidad rol de la base de datos, aun que no se utilice de momento se dejó declarada para futuras actualizaciones.
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
