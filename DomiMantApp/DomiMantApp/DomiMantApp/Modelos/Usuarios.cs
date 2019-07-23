﻿
namespace DomiMantApp.Modelos
{
    using System;
    using System.Collections.Generic;
    using static DomiMantApp.Globals.Variables;

    public class Usuarios:ModeloBase
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Emails { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Cedula { get; set; }
        public bool EnSeccion { get; set; }
        public bool Recordar { get; set; }
    }

    public class Suplidor : Usuarios
    {
        public List<Clientes> Clientes { get; set; }
    }

    public class Clients : Usuarios
    {
        public List<Vehiculos> Vehiculos { get; set; }
        public List<Direccion_Contactos> Direcciones { get; set; }
    }
}
