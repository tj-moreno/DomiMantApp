
namespace DomiMantApp.Modelos
{    
    public class Vehiculos:ModeloBase
    {
        public string UsuarioID { get; set; }
        public string VehiculoID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Placa { get; set; }
        public int  PlazoMantenimientos { get; set; }        
    }

    public class VehiculosView : Vehiculos
    {
        public string NombreVehiculo {
            get {
                return $"{Marca} {Modelo} {Anio}";
            }
            set {
                value.ToString();
            }
        }

        public string Mantenimiento {
            get {
                return $"Restan {PlazoMantenimientos} Dias";
            }
            set {
                value.ToString();
            }
        }

    }
}
