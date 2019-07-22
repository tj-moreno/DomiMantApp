

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;    
    using System.Windows.Input;

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
                return new RelayCommand(Buscar);
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
        private void Buscar()
        {
            throw new NotImplementedException();
        }
        private void Actualizar()
        {
            throw new NotImplementedException();
        }
        private void NuevaDireccion()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
