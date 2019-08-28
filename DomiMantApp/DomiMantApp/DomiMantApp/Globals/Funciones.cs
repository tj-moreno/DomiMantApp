

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

            TipUs.Add(new TiposUsuario { ID=1,TipoID = TipoUsuario.Cliente, Descripcion = "Cliente" });
            TipUs.Add(new TiposUsuario { ID=2,TipoID = TipoUsuario.Suplidor, Descripcion = "Suplidor" });

            return TipUs;
        }
    }
}
