
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

    public class TransaccionViewModel : ModeradorBase
    {
        #region Constructor
        public TransaccionViewModel()
        {

        }
        #endregion
        #region Atributos
        private string numerotransaccion;
        private string clienteid;
        private string suplidorid;
        private DateTime fecha;
        private string observaciones;
        private Trans trans;
        private observablecollection<>
        #endregion
        #region Propiedades
        public string NumeroTransaccion {
            get {
                return this.numerotransaccion;
            }
            set {
                PasarValor(ref this.numerotransaccion, value);
            }

        }
        public string ClientesID {
            get {
                return this.clienteid;
            }
            set {
                PasarValor(ref this.clienteid, value);
            }

        }
        public string SuplidorId {
            get {
                return this.suplidorid;
            }
            set {
                PasarValor(ref this.suplidorid, value);
            }
        }
        public DateTime Fecha {
            get {
                return this.fecha;
            }
            set {
                PasarValor(ref this.fecha, value);
            }
        }
        public string Observaciones {
            get {
                return this.observaciones;
            }
            set {
                PasarValor(ref this.observaciones, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand btnGuardarCommand {
            get {
                return new RelayCommand(Guardar);
            }
        }
        public ICommand btnCancelarCommand {
            get {
                return new RelayCommand(Cancelar);
            }
        }
        public ICommand btnEliminarCommand {
            get {
                return new RelayCommand(Eliminar);
            }
        }        
        #endregion
        #region Metodos
        private void Guardar()
        {
            throw new NotImplementedException();
        }
        private void Cancelar()
        {
            throw new NotImplementedException();
        }
        private void Eliminar()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
