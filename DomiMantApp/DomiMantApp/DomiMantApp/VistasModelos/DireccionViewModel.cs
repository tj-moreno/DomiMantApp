

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;
    using static DomiMantApp.Globals.Funciones;

    public class DireccionViewModel : ModeradorBase
    {
        #region Constructor
        public DireccionViewModel(Direccion_Contactos dir=null)
        {
            MostrarDireccion();
            direccion = dir;
        }        
        #endregion
        #region Atributos
        private string usuarioid;
        private string longitud;
        private string latitud;
        private string descripcion;
        private string nombrecontacto;
        private string telefono;
        private bool verbotoneliminar;
        private Direccion_Contactos direccion;
        #endregion
        #region Propiedades
        public string UsuarioID {
            get {
                return this.usuarioid;
            }
            set {
                PasarValor(ref this.usuarioid, value);
            }
        }
        public string Longitud {
            get {
                return this.longitud;
            }
            set {
                PasarValor(ref this.longitud, value);
            }
        }
        public string Latitud {
            get {
                return this.latitud;
            }
            set {
                PasarValor(ref this.latitud, value);
            }
        }
        public string Descripcion {
            get {
                return this.descripcion;
            }
            set {
                PasarValor(ref this.descripcion, value);
            }
        }
        public string NombreContacto {
            get {
                return this.nombrecontacto;
            }
            set {
                PasarValor(ref this.nombrecontacto, value);
            }
        }
        public string Telefono {
            get {
                return this.telefono;
            }
            set {
                PasarValor(ref this.telefono, value);
            }
        }
        public bool VerBotonEliminar {
            get {
                return this.verbotoneliminar;
            }
            set {
                PasarValor(ref this.verbotoneliminar, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand GuardarDireccion {
            get {
                return new RelayCommand(Guardar);
            }
        }
        public ICommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }
        public ICommand EliminarCommand
        {
            get
            {
                return new RelayCommand(Eliminar);
            }
        }        
        #endregion
        #region Metodos
        private async void Guardar()
        {
            try
            {
                using (var repo = new Repositorio<Direccion_Contactos>(GetDbPath()))
                {
                    switch (Acciones)
                    {
                        case Accion.Agregar:
                            repo.Agregar(new Direccion_Contactos {
                                UsuarioID = this.UsuarioID,
                                Descripcion=this.Descripcion,
                                Latitud=this.Latitud,
                                Longitud=this.Longitud,
                                NombreContacto=this.NombreContacto,
                                Telefono=this.Telefono
                            });
                            break;
                        case Accion.Modificar:
                            direccion.UsuarioID = this.UsuarioID;
                            direccion.Descripcion = this.Descripcion;
                            direccion.Latitud = this.Latitud;
                            direccion.Longitud = this.Longitud;
                            direccion.NombreContacto = this.NombreContacto;
                            direccion.Telefono = this.Telefono;

                            repo.Actualizar(direccion);
                            break;                        
                    }
                    repo.Dispose();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Dirección",
                    $"Error al intentar {Acciones.ToString()} la direccion {Descripcion}\nDescripción del Error: {ex.Message}",
                    "Ok");
            }
        }
        private void Cancelar()
        {
            throw new NotImplementedException();
        }
        private void MostrarDireccion()
        {
            this.UsuarioID = direccion.UsuarioID;
            this.Longitud = direccion.Longitud;
            this.Latitud = direccion.Latitud;
            this.Descripcion = direccion.Descripcion;
            this.NombreContacto = direccion.NombreContacto;
            this.Telefono = direccion.Telefono;
        }
        private async void Eliminar()
        {
            try
            {
                var Autorizado = await App.Current.MainPage.DisplayAlert(
                    "Dirección",
                    $"Esta seguro que desea eliminar la direccion {Descripcion}?",
                    "Si",
                    "No");

                if (!Autorizado)
                    return;

                using (var repo= new Repositorio<Direccion_Contactos>(GetDbPath()))
                {
                    repo.Eliminar(direccion);
                    repo.Dispose();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Dirección",
                    $"Error al intentar eliminar la direccion {Descripcion}\nDescripción del Error: {ex.Message}",
                    "Ok");
            }
        }
        #endregion
    }
}
