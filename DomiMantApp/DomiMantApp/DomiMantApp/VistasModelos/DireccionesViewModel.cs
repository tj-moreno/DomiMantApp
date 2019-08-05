

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using static Globals.Funciones;

    public class DireccionesViewModel : ModeradorBase
    {
        #region Constructor
        public DireccionesViewModel()
        {

        }
        #endregion
        #region Atributos
        private string direccion;
        private string contacto;
        private string telefono;
        private string buscar;
        private ObservableCollection<DireccionesItemViewModel> _direcciones;
        private List<Direccion_Contactos> lstdireccion;
        private bool actualizando;
        #endregion
        #region Propiedades
        public string Direccion {
            get {
                return this.direccion;
            }
            set {
                PasarValor(ref this.direccion, value);
            }
        }
        public string Contacto {
            get {
                return this.contacto;
            }
            set {
                PasarValor(ref this.contacto, value);
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
        public bool Actualizando {
            get {
                return this.actualizando;
            }
            set {
                PasarValor(ref this.actualizando, value);
            }
        }
        public string Buscar {
            get {
                return this.buscar;
            }
            set {
                PasarValor(ref this.buscar, value);
            }
        }
        public ObservableCollection<DireccionesItemViewModel> Direcciones {
            get {
                return this._direcciones;
            }
            set {
                PasarValor(ref this._direcciones, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(Buscardirecciones);
            }
        }
        public ICommand ActualizarCommand {
            get {
                return new RelayCommand(Actualizar);
            }
        }
        public ICommand AgregarCommand {
            get {
                return new RelayCommand(NuevaDireccion);
            }
        }        
        #endregion
        #region Metodos
        private void Buscardirecciones()
        {
            try
            {
                this.Actualizando = true;
                if (string.IsNullOrEmpty(this.Buscar))
                {
                    this.Direcciones = new ObservableCollection<DireccionesItemViewModel>(
                        this.ToDireccionesViewModel());
                }
                else
                {
                    this.Direcciones = new ObservableCollection<DireccionesItemViewModel>(
                        this.ToDireccionesViewModel().Where(d=>
                        d.Descripcion.Contains(this.Buscar) ||
                        d.Contacto.Contains(this.Buscar) ||
                        d.Telefono.Contains(this.Buscar))
                        );
                }
                this.Actualizando = false;
            }
            catch (Exception)
            {
                this.Actualizando = false;
                throw;
            }
        }
        private void Actualizar()
        {
            this.CargarDirecciones();
        }
        private void NuevaDireccion()
        {
            throw new NotImplementedException();
        }
        private void CargarDirecciones() {
            try
            {
                this.Actualizando = true;
                using (var repodireccion= new Repositorio<Direccion_Contactos>(GetDbPath()))
                {
                    this.lstdireccion = repodireccion.Buscar(d => d.UsuarioID.Equals(""), d => d.NombreContacto).ToList();
                    repodireccion.Dispose();
                }

                this.Direcciones = new ObservableCollection<DireccionesItemViewModel>(
                    this.ToDireccionesViewModel());

                this.Actualizando = false;
            }
            catch (Exception)
            {
                this.Actualizando = false;
                throw;
            }
        }
        private IEnumerable<DireccionesItemViewModel> ToDireccionesViewModel()
        {
            return this.lstdireccion.Select(d=> new DireccionesItemViewModel() {
                ID=d.ID,
                UsuarioID=d.UsuarioID,
                Longitud=d.Longitud,
                Latitud=d.Latitud,
                Descripcion=d.Descripcion,
                NombreContacto=d.NombreContacto, 
                Telefono=d.Telefono
            });
        }
        #endregion
    }
}
