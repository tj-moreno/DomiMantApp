
namespace DomiMantApp.Modelos
{
    using System;

    public class Transacciones:ModeloBase
    {        
        public string NumeroTransaccion { get; set; }
        public string ClienteID { get; set; }
        public DateTime Feche { get; set; }
        public string Observaciones { get; set; }
    }
}
