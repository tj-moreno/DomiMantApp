
namespace DomiMantApp.VistasModelos
{
    public class Moderador_De_Vistas
    {
        #region Conbstruictor
        public Moderador_De_Vistas()
        {
            Instancia = this;
            this.Login = new LoginViewModel();
        }
        #endregion
        #region Propiedades
        public DireccionesViewModel Direcciones {
            get; set;
        }
        public DireccionViewModel Direccion {
            get;
            set;
        }
        public ServiciosViewModel Servicios {
            get;
            set;
        }
        public ServicioViewModel Servicio {
            get;
            set;
        }
        public TransaccionesViewModel Transacciones {
            get;
            set;
        }
        public TransaccionViewModel Transaccion {
            get;
            set;
        }
        public TransDetailsViewModel TransDetails {
            get;
            set;
        }
        public TransDetailViewModel TransDetail {
            get;
            set;
        }
        public VehiculosViewModel Vehiculos {
            get;
            set;
        }
        public VehiculoViewModel Vehiculo {
            get;
            set;
        }
        public RegistroViewModel Registro {
            get;
            set;
        }
        public LoginViewModel Login {
            get;
            set;
        }
        #endregion
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
