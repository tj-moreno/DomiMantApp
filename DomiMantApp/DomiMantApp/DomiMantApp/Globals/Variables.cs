

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

        public class TiposUsuario {
            public TipoUsuario TipoID { get; set; }
            public string Descripcion { get; set; }
        }

        public static Accion Acciones;

        public static Usuarios UsuarioActual;
    }
}
