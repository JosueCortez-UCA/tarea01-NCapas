namespace Tarea01.Entidades
{
    // Entidad persona de la base de datos
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
    }
}
