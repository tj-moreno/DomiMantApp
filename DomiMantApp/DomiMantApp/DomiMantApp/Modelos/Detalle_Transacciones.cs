


namespace DomiMantApp.Modelos
{
    using System;
    public class Detalle_Transacciones
    {
        public int ID { get; set; }
        public string VehiculoID { get; set; }
        public string ServicioID { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public DateTime FinGarantia { get; set; }
    }
}
