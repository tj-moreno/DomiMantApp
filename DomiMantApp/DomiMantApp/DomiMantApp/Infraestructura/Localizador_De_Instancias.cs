

namespace DomiMantApp.Infraestructura
{
    using VistasModelos;
    public class Localizador_De_Instancias
    {
        
        #region Propiedades
        public Moderador_De_Vistas Moderador {
                get;
                set;
            }
        #endregion

        #region Constructor
            public Localizador_De_Instancias()
            {
                this.Moderador = new Moderador_De_Vistas();
            }
        #endregion
    }
}
