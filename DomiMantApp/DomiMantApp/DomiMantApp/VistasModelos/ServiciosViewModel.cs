

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;    
    using System.Windows.Input;

    public class ServiciosViewModel : ModeradorBase
    {
        #region Constructor
        public ServiciosViewModel()
        {

        }
        #endregion

        #region Atributo
        private string mostrardescripcion;
        private string mostrarprecio;
        private string mostrargarantia;
        private ObservableCollection<ServiciosItemsViewModel> _servicios;
        private List<Servicios> lstservicios;
        private bool actualizando;
        #endregion

        #region Propiedades
        public string MostrarDescripcion {
            get {
                return this.mostrardescripcion;
            }
            set {
                PasarValor(ref this.mostrardescripcion, value);

            }
        }
        public string MostrarPrecio {
            get {
                return this.mostrarprecio;
            }
            set {
                PasarValor(ref this.mostrarprecio, value);
            }
        }
        public string MostrarGarantia {
            get {
                return this.mostrargarantia;
            }
            set {
                PasarValor(ref this.mostrargarantia, value);
            }
        }
        public ObservableCollection<ServiciosItemsViewModel> Servicios {
            get {
                return this._servicios;
            }
            set {
                PasarValor(ref this._servicios, value);
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
        #endregion

        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(Buscar);
            }
        }

        public ICommand ActualizandoCommand {
            get {
                return new RelayCommand(Actualizar);
            }
        }

        public ICommand AgregarServicio {
            get {
                return new RelayCommand(Agregar);
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

        private void Agregar()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
