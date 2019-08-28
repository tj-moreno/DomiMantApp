


namespace DomiMantApp.Modelos
{    
    public class Direccion_Contactos:ModeloBase
    {        
        public string UsuarioID { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public string Descripcion { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }        
    }

    public class Direcciones : Direccion_Contactos
    {
        public string Direccion {
            get {
                return Descripcion;
            }
            set {
                value.ToString();
            }
        }
        public string Contacto {
            get {
                return NombreContacto;
            }
            set {
                value.ToString();
            }
        }
        public string DireccionTelefono {
            get {
                return Telefono;
            }
            set {
                value.ToString();
            }
        }
    }
}
