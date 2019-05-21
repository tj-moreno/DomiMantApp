
namespace DomiMantApp.Modelos
{
    using System;

    public class Transacciones
    {
        public int ID { get; set; }
        public string NumeroTransaccion { get; set; }
        public string ClienteID { get; set; }
        public DateTime Feche { get; set; }
        public string observaciones { get; set; }
    }
}
