

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;    
    using GalaSoft.MvvmLight.Command;
    using System;       
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;  
    using System.Linq;
    using Xamarin.Forms;

    public class TransDetailViewModel : ModeradorBase
    {
        #region Constructor
        public TransDetailViewModel(ref Trans transaccion, Detalle_Transaccion _detalle = null)
        {
            transaccion = this.Trans;
            detalle = _detalle;
            if (Accion.Equals(Acciones.Modificar))
                MostrarDetalle();
        }
        #endregion
        #region Atributos
        private int transid;
        private string vehiculoid;
        private string servicioid;
        private string descripcion;
        private double cantidad;
        private double precio;
        private DateTime fingarantia;
        private string total;
        private Detalle_Transaccion detalle;
        #endregion
        #region Propiedades
        public int TransID {
            get {
                return this.transid;
            }
            set {
                PasarValor(ref this.transid, value);

            }
        }
        public string VehiculoID {
            get {
                return this.vehiculoid;
            }
            set {
                PasarValor(ref this.vehiculoid, value);
            }

        }
        public string ServicioID {
            get {
                return this.servicioid;
            }
            set {
                PasarValor(ref this.servicioid, value);

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
        public double Cantidad {
            get {
                return this.cantidad;
            }
            set {
                PasarValor(ref this.cantidad, value);

            }
        }
        public double Precio {
            get {
                return this.precio;
            }
            set {
                PasarValor(ref this.precio, value);
            }
        }
        public DateTime FinGarantia {
            get {
                return this.fingarantia;
            }
            set {
                PasarValor(ref this.fingarantia, value);
            }
        }
        public string Total {
            get {
                total = (cantidad * precio).ToString("##,##0.00");
                return this.total;
            }
            set {
                PasarValor(ref this.total, value);
            }
        }
        public Trans Trans;
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
        private async void Guardar()
        {
            try
            {
                switch (Accion)
                {
                    case Acciones.Agregar:
                        Trans.DetalleTransaccion.Add(new Detalle_Transaccion
                        {
                            TransID = this.Trans.ID,
                            VehiculoID = this.VehiculoID,
                            ServicioID = this.ServicioID,
                            Descripcion = this.Descripcion,
                            Cantidad = this.Cantidad,
                            Precio = this.Precio,
                            FinGarantia = this.FinGarantia
                        });
                        break;
                    case Acciones.Modificar:
                        Trans.DetalleTransaccion.FirstOrDefault(t =>
                            t.ServicioID.Equals(this.ServicioID)).VehiculoID = this.VehiculoID;
                        Trans.DetalleTransaccion.FirstOrDefault(t =>
                            t.ServicioID.Equals(this.ServicioID)).Descripcion = this.Descripcion;
                        Trans.DetalleTransaccion.FirstOrDefault(t =>
                            t.ServicioID.Equals(this.ServicioID)).Cantidad = this.Cantidad;
                        Trans.DetalleTransaccion.FirstOrDefault(t =>
                            t.ServicioID.Equals(this.ServicioID)).Precio = this.Precio;
                        break;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Detalle de Transacción",
                    $"Error al {Accion.ToString()}\nDescripcion del Error: {ex.Message}",
                    "Ok");
            }
        }
        private void Cancelar()
        {
            throw new NotImplementedException();
        }
        private async void Eliminar()
        {
            try
            {
                var autorizado = await Application.Current.MainPage.DisplayAlert(
                    "Detalle De Transacción",
                    $"Esta seguro que desea eliminar el detalle {Descripcion} de esta Transaccion?",
                    "Si",
                    "No");

                if (!autorizado)
                    return;

                Trans.DetalleTransaccion.Remove(detalle);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Detalle de Transacción",
                    $"Error eliminando el detalle {Descripcion}\nDetalle del Error: {ex.Message}",
                    "Ok");
            }            
        }
        private void MostrarDetalle()
        {
            this.TransID = detalle.TransID;
            this.VehiculoID = detalle.VehiculoID;
            this.ServicioID = detalle.ServicioID;
            this.descripcion = detalle.Descripcion;
            this.Cantidad = detalle.Cantidad;
            this.Precio = detalle.Precio;
            this.FinGarantia = detalle.FinGarantia;
        }
        #endregion
    }
}
