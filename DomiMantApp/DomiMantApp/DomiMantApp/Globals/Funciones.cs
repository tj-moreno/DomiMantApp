

namespace DomiMantApp.Globals
{
    using System.Collections.Generic;
    using static DomiMantApp.Globals.Variables;
    using static System.Environment;    
    public class Funciones
    {
        public static string GetDbPath() {
            string folder = GetFolderPath(SpecialFolder.Personal);
            string rutaDb = System.IO.Path.Combine(folder, "DomiMantApps.db");

            return rutaDb;
        }

        public static List<TiposUsuario> GetTiposUsuarios()
        {
            var TipUs = new List<TiposUsuario>();

            TipUs.Add(new TiposUsuario { TipoID = TipoUsuario.Cliente, Descripcion = "Cliente" });
            TipUs.Add(new TiposUsuario { TipoID = TipoUsuario.Suplidor, Descripcion = "Suplidor" });

            return TipUs;
        }

        public static List<OpcioneCuentas> GetOpciones(TipoUsuario tipo)
        {
            var Opus = new List<OpcioneCuentas>();

            switch (tipo)
            {
                case TipoUsuario.Cliente:
                    Opus.Add(new OpcioneCuentas {
                        OpcionId = OpcionesdeCuenta.Direcciones,
                        Descripcion = "Direcciones y Contactos"
                    });
                    Opus.Add(new OpcioneCuentas {
                        OpcionId=OpcionesdeCuenta.Suplidores,
                        Descripcion="Suplidores de Servicios"
                    });
                    Opus.Add(new OpcioneCuentas {
                        OpcionId=OpcionesdeCuenta.Vehiculos,
                        Descripcion="Vehiculos"
                    });
                    break;
                case TipoUsuario.Suplidor:
                    Opus.Add(new OpcioneCuentas {
                        OpcionId=OpcionesdeCuenta.Servicios,
                        Descripcion="Productos y Servicios"
                    });
                    Opus.Add(new OpcioneCuentas {
                        OpcionId=OpcionesdeCuenta.Clientes,
                        Descripcion="Clientes"
                    });
                    Opus.Add(new OpcioneCuentas {
                        OpcionId=OpcionesdeCuenta.Transacciones,
                        Descripcion="Transacciones"
                    });
                    break;                
            }

            return Opus;
        }
    }
}
