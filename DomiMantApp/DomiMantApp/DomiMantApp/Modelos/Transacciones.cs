
namespace DomiMantApp.Modelos
{
    using System;
    using System.Collections.Generic;

    public class Transaccion:ModeloBase
    {        
        public string NumeroTransaccion { get; set; }
        public string ClienteID { get; set; }
        public string SuplidorID { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
    }

    public class Transacciones : Transaccion
    {
        public string TransaccionID {
            get {
                return this.NumeroTransaccion;
            }
            set {
                value.ToString();
            }
        }
        public string FechaDoc {
            get {
                return this.Fecha.ToString("dd/MM/yyyy");
            }
            set {
                value.ToString();
            }
        }
    }

    public class Trans : Transaccion
    {
        public List<Detalle_Transaccion> DetalleTransaccion { get; set; }
    }
}
