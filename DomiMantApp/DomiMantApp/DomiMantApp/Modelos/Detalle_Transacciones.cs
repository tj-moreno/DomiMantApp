


namespace DomiMantApp.Modelos
{
    using System;
    public class Detalle_Transaccion:ModeloBase
    {
        public int TransID { get; set; }
        public string VehiculoID { get; set; }
        public string ServicioID { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public DateTime FinGarantia { get; set; }
    }

    public class DetalleTransaccion:Detalle_Transaccion
    {
        public string Vehiculo { get; set; }
        public string Descrip {
            get {
                return Descripcion;

            }
            set {
                value.ToString();
            }
        }
        public string GarantiaHasta {
            get {
                return FinGarantia.ToString("dd/MM/yyyy");
            }
            set {
                value.ToString();
            }
        }
    }
}
