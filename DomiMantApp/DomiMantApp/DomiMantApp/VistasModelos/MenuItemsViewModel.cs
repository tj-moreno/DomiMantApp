

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using DomiMantApp.Vistas;
    using GalaSoft.MvvmLight.Command;    
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;
    using static DomiMantApp.Globals.Funciones;
    using Xamarin.Forms;

    public class MenuItemsViewModel
    {
        #region Propiedades
        public string Icon { get; set; }
        public string Titulo { get; set; }
        public string Pagina { get; set; }
        #endregion
        #region Comando
        public ICommand NavegacionCommand {
            get
            {
                return new RelayCommand(Navegar);
            }
        }
        #endregion
        #region Metodo
        private void Navegar()
        {
            switch (this.Pagina)
            {
                case "ClienteMasterPage":
                    Application.Current.MainPage = new ClienteMasterPage();
                    break;
                case "MasterPage":
                    Application.Current.MainPage = new MasterPage();
                    break;
                case "RegistroPage":
                    Accion = Acciones.Modificar;
                    Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();
                    Hidemenu();
                    App.Navigator.CurrentPage.Navigation.PushAsync(new RegistroPage());
                    break;
                case "VehiculoPage":
                    Accion = Acciones.Agregar;
                    Moderador_De_Vistas.ObtenerInstancia().Vehiculo = new VehiculoViewModel();
                    Hidemenu();
                    App.Navigator.CurrentPage.Navigation.PushAsync(new VehiculoPage());
                    break;
                case "DireccionPage":
                    Accion = Acciones.Agregar;
                    Moderador_De_Vistas.ObtenerInstancia().Direccion = new DireccionViewModel();
                    Hidemenu();
                    App.Navigator.CurrentPage.Navigation.PushAsync(new DireccionPage());
                    break;
                case "ClientePage":
                    Accion = Acciones.Agregar;
                    Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();
                    Hidemenu();
                    App.Navigator.CurrentPage.Navigation.PushAsync(new RegistroPage());
                    break;
                case "ServicioPage":
                    Accion = Acciones.Agregar;
                    Moderador_De_Vistas.ObtenerInstancia().Servicio = new ServicioViewModel();
                    Hidemenu();
                    App.Navigator.CurrentPage.Navigation.PushAsync(new ServicioPage());
                    break;
                case "LoginPage":
                    UsuarioActual.EnSeccion = false;
                    using (var repoUsuario = new Repositorio<Usuarios>(GetDbPath()))
                    {
                        repoUsuario.Actualizar(UsuarioActual);
                        repoUsuario.Dispose();
                    }
                    Moderador_De_Vistas.ObtenerInstancia().Login = new LoginViewModel();
                    Application.Current.MainPage = new LoginPage();
                    break;
            }
        }
        private void Hidemenu()
        {
            if (App.MDPageS!=null)
            {
                App.MDPageS.IsPresented = false;
            }
            else
            {
                App.MDPageC.IsPresented = false;
            }
        }
        #endregion
    }
}
