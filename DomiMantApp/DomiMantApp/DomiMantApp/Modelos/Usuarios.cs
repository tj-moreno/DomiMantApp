
namespace DomiMantApp.Modelos
{
    using System;
    using System.Collections.Generic;

    public class Usuarios:ModeloBase
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Emails { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Tipo { get; set; }
        public string Cedula { get; set; }
        public bool EnSeccion { get; set; }
        public bool Recordar { get; set; }        
    }

    public class Suplidor : Usuarios
    {
        public List<Clientes> Clientes { get; set; }
    }

    public class Cliente : Usuarios
    {
        public List<Vehiculos> Vehiculos { get; set; }
        public List<Direccion_Contactos> Direcciones { get; set; }
    }
}
