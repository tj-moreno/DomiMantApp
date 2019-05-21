

namespace DomiMantApp.Globals
{
    using static System.Environment;    
    public class Funciones
    {
        public static string GetDbPath() {
            string folder = GetFolderPath(SpecialFolder.Personal);
            string rutaDb = System.IO.Path.Combine(folder, "DomiMantApps.db");

            return rutaDb;
        }
    }
}
