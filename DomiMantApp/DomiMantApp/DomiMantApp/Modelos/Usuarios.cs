
namespace DomiMantApp.Modelos
{
    using System;

    public class Usuarios
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Tipo { get; set; }
        public string Registro { get; set; }
    }
}
