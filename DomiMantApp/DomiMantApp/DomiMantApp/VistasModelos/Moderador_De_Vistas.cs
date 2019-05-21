
namespace DomiMantApp.VistasModelos
{
    public class Moderador_De_Vistas
    {
        #region Singleton
        private static Moderador_De_Vistas Instancia;

        public static Moderador_De_Vistas ObtenerInstancia() {
            if (Instancia==null)
            {
                return new Moderador_De_Vistas();
            }

            return Instancia;
        }
        #endregion
    }
}
