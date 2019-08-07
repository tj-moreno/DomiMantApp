

using DomiMantApp.Modelos;

namespace DomiMantApp.Globals
{    
    public static class Variables
    {
        public enum TipoUsuario {
            Cliente=1,
            Suplidor=2
        }

        public enum Accion {
            Agregar=1,
            Modificar=2
        }

        public enum OpcionesdeCuenta {
            Direcciones=1,
            Vehiculos=2,
            Transacciones=3,
            Clientes=4,
            Suplidores=5,
            Servicios=6
        }

        public class TiposUsuario {
            public TipoUsuario TipoID { get; set; }
            public string Descripcion { get; set; }
        }

        public static Accion Acciones; //= new Accion();
        public static Usuarios UsuarioActual; //= new Usuarios();

        public class OpcioneCuentas {
            public OpcionesdeCuenta OpcionId { get; set; }
            public string Descripcion { get; set; }
        }

        public class Opciones : OpcioneCuentas
        {
            public string Nombre {
                get {
                    return this.Descripcion;
                }
                set {
                    value.ToString();
                }
            }
        }
    }
}
