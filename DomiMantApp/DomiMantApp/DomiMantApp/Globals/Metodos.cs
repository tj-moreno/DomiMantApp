
namespace DomiMantApp.Globals
{    
    using System.Collections.Generic;    
    using static DomiMantApp.Globals.Variables;

    public static class Metodos
    {
        public static List<TiposUsuario> GetTiposUsuarios()
        {
            var TipUs = new List<TiposUsuario>();

            TipUs.Add(new TiposUsuario { TipoID = TipoUsuario.Cliente, Descripcion = "Cliente" });
            TipUs.Add(new TiposUsuario { TipoID = TipoUsuario.Suplidor, Descripcion = "Suplidor" });

            return TipUs;
        }
    }
}
