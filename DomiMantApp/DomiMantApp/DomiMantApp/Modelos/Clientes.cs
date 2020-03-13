
namespace DomiMantApp.Modelos
{
    public class Clientes:ModeloBase
    {
        public string MecanicoID { get; set; }        
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Emails { get; set; }
        public string Cedula { get; set; }
    }

    public class ClientesView : Clientes { 
    public int ID {
            get {
                if (ID>0)
                {
                    return ID;
                }

                return ID;
            }            
        }
    public string FullName {
            get {
                if (string.IsNullOrEmpty(Nombres))
                {
                    return Nombres + ' ' + Apellidos;
                }

                return Nombres;
            }
            set {
                value.ToString();
            }
        }
    }
}
