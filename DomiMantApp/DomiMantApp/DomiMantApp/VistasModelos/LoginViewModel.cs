

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;    
    using static Globals.Funciones;
    using static Globals.Variables;
    using System.Windows.Input;
    using System.Linq;
    using DomiMantApp.Vistas;
    using Xamarin.Forms;

    public class LoginViewModel : ModeradorBase
    {
        #region Constructor
        public LoginViewModel()
        {
            CargarCuenta();
        }
        #endregion
        #region Atributos
        private string usuario;
        private string clave;
        private bool indicardor;
        private bool recordar;
        #endregion
        #region Propiedades
        public string Usuario {
            get {
                return this.usuario;
            }
            set {
                PasarValor(ref this.usuario, value);
            }
        }
        public string Clave {
            get {
                return this.clave;
            }
            set {
                PasarValor(ref this.clave, value);
            }
        
}
        public bool Indicador {
            get {
                return this.indicardor;
            }
            set {
                PasarValor(ref this.indicardor, value);

            }
        }
        public bool Recordar {
            get {
                return this.recordar;
            }
            set {
                PasarValor(ref this.recordar, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand btnEntrarCommand {
            get {
                return new RelayCommand(Entrar);
            }
        }
        public ICommand btnRegistrarCommand {
            get {
                return new RelayCommand(Registrar);
            }
        }      
        #endregion
        #region Methodos
        private async void Entrar()
        {
            try
            {
                Indicador = true;
                if (ValidarCuenta())
                {
                    using (var repoUsuario= new Repositorio<Usuarios>(GetDbPath()))
                    {
                        UsuarioActual.EnSeccion = true;
                        repoUsuario.Actualizar(UsuarioActual);
                    }
                    switch (UsuarioActual.Tipo) 
                    {
                        case TipoUsuario.Cliente:
                            Accion = Acciones.Modificar;                            
                            Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();
                            App.Current.MainPage=new ClienteMasterPage();
                            break;
                        case TipoUsuario.Suplidor:
                            Accion = Acciones.Modificar;
                            Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();
                            App.Current.MainPage= new MasterPage();
                            break;
                    }
                }
                Indicador = false;
            }
            catch (Exception ex)
            {
                Indicador = false;
                await Application.Current.MainPage.DisplayAlert(
                    "DomiMant Apps",
                    $"Error : {ex.Message}",
                    "Ok");
            }
        }
        private void Registrar()
        {
            Accion = Acciones.Agregar;
            Moderador_De_Vistas.ObtenerInstancia().Registro = new RegistroViewModel();                        
            Application.Current.MainPage.Navigation.PushAsync(new RegistroPage());
        }
        private bool ValidarCuenta()
        {
            return true;
            //if (string.IsNullOrEmpty(Usuario))
            //{
            //    App.Current.MainPage.DisplayAlert(
            //        "DomiMat Apps",
            //        "El Usuario es requerido para poder acceder a la aplicacion.\nEn caso de no estar registrado,\n Pro favor Cree una cuenta e intente de nuevo.",
            //        "Ok");
            //    return false;
            //}
            //else
            //{
            //    using (var repoUsuario= new Repositorio<Usuarios>(GetDbPath()))
            //    {
            //        var user = ((List<Usuarios>)repoUsuario.Buscar(u => u.Equals(Usuario))).FirstOrDefault();
            //        if (user == null)
            //        {
            //            App.Current.MainPage.DisplayAlert(
            //                "DomiMant Apps",
            //                $"El usuario {Usuario} es invalido\nPor favor asegurese de que los datos son correctos.",
            //                "Ok");
            //            return false;
            //        }
            //        else
            //        {
            //            if (string.IsNullOrEmpty(Clave))
            //            {
            //                App.Current.MainPage.DisplayAlert(
            //                    "DomiMant Apps",
            //                    "Debe digitar la clave de acceso.",
            //                    "Ok");
            //                return false;
            //            }
            //            else
            //            {
            //                if (!user.Contrasena.Equals(Clave))
            //                {
            //                    App.Current.MainPage.DisplayAlert(
            //                        "DomiMant Apps",
            //                        "Los datos digitados son erroneos, por favor valide la informacion suministrada e intente otra vez",
            //                        "Ok");
            //                    return false;
            //                }
            //                else
            //                {
            //                    UsuarioActual = user;
            //                    return true;
            //                }
            //            }
            //        }                    
            //    }
            //}
        }
        private async void CargarCuenta()
        {
            try
            {
                using (var repoUser= new Repositorio<Usuarios>(GetDbPath()))
                {
                    var user = ((List<Usuarios>)repoUser.Buscar(u => u.Recordar.Equals(true))).FirstOrDefault();

                    if (user!=null)
                    {
                        Usuario = user.Codigo;
                        Clave = user.Contrasena;
                        Recordar = user.Recordar;

                        UsuarioActual = user;
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "DomiMant Apps",
                    $"{ex.Message}",
                    "Ok");
            }
        }
        #endregion
    }
}
