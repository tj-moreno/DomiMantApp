﻿
namespace DomiMantApp.Modelos
{    
    public class Servicios:ModeloBase
    {
        public string Codigo { get; set; }
        public string SuplidorID { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public bool Garantia { get; set; }
        public double Tiempogarantia { get; set; }
    }
}
