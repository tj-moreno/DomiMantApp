
namespace DomiMantApp.VistasModelos
{
    using System.Collections.ObjectModel;
    using static DomiMantApp.Globals.Variables;

    public class Moderador_De_Vistas
    {
        #region Conbstruictor
        public Moderador_De_Vistas()
        {            
            Instancia = this;            
            this.Login = new LoginViewModel();

            if(UsuarioActual!=null)
                CargarMenu();
        }
        #endregion
        #region Propiedades
        public ObservableCollection<MenuItemsViewModel> Menu {
            get;
            set;
        }
        public DireccionesViewModel Direcciones {
            get;
            set;
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
        #region Metodo
        public void CargarMenu()
        {
            Menu = new ObservableCollection<MenuItemsViewModel>();
            Menu.Add(new MenuItemsViewModel {
                Icon = "ic_settings_Menu",
                Pagina = "RegistroPage",
                Titulo = "Ajustes de Cuenta"
            });
            switch (UsuarioActual.Tipo)
            {
                case (int)TipoUsuario.Cliente:
                    Menu.Add(new MenuItemsViewModel
                    {
                        Icon = "ic_Vehiculo_Menu",
                        Pagina = "VehiculoPage",
                        Titulo = "Agregar Vehiculo"
                    });
                    Menu.Add(new MenuItemsViewModel
                    {
                        Icon = "ic_Contacto_Menu",
                        Pagina = "DireccionPage",
                        Titulo = "Agregar Contacto"
                    });
                    break;
                case (int)TipoUsuario.Suplidor:
                    Menu.Add(new MenuItemsViewModel {
                       Titulo="Agregar Cliente",
                       Pagina="ClientePage",
                       Icon= "ic_Cliente_Menu"
                    });
                    Menu.Add(new MenuItemsViewModel {
                        Titulo="Agregar Servicio",
                        Pagina="ServicioPage",
                        Icon= "ic_Servicio_Menu"
                    });
                    break;
            }
            Menu.Add(new MenuItemsViewModel {
                Titulo="Salir",
                Pagina="LoginPage",
                Icon= "ic_Menu_group_Salir"
            });
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
