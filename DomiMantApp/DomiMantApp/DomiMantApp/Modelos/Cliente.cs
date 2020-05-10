
namespace DomiMantApp.Modelos
{
    using System;
    using System.Collections.Generic;
    public class Cliente:ModeloBase
    {
        public string MecanicoID { get; set; }        
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Emails { get; set; }
        public string Cedula { get; set; }
    }

    public class ClientesView : Cliente { 
    public string ClienteID {
            get {
                if (string.IsNullOrEmpty(Codigo))
                {
                    return Id.ToString();
                }

                return Codigo;
            }
            set {
                value.ToString();
            }
        }
    public string FullName {
            get {
                if (!string.IsNullOrEmpty(Nombres))
                {
                    return Nombres + ' ' + Apellidos;
                }

                return Nombres;
            }
            set {
                value.ToString();
            }
        }
    }
}
