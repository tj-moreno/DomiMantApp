
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

    public class ServiciosView: Servicios
    {
        public string MostrarDescripcion {
            get {
                return Descripcion;
            }
            set {
                value.ToString();
            }
        }
        public string MostrarPrecio {
            get {
                return Precio.ToString("##,##0.00");
            }
            set {
                value.ToString();
            }
        }
        public string MostrarGarantia {
            get {
                if (Garantia)
                    return "Si";            
                return "No";
            }
            set {
                value.ToString();
            }

        }
    }
}
