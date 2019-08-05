
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using static Globals.Funciones;
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;
    using System.Linq;

    public class TransaccionViewModel : ModeradorBase
    {
        #region Constructor
        public TransaccionViewModel()
        {
            CargarTransaccion();
        }
        #endregion
        #region Atributos
        private string numerotransaccion;
        private string clienteid;
        private string suplidorid;
        private DateTime fecha;
        private string observaciones;
        private Trans trans;
        private Detalle_Transaccion detalle;
        private ObservableCollection<TransDetailItemsViewModel> transdetail;
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
                NumeroTransaccion = GenerarNumeroTrans();
            }

        }
        public string SuplidorID {
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
        public ObservableCollection<TransDetailItemsViewModel> TransDetail {
            get {
                return this.transdetail;
            }
            set {
                PasarValor(ref this.transdetail, value);
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
        private async void Guardar()
        {
            try
            {
                using (var repoMaster=new Repositorio<Transaccion>(GetDbPath()))
                {
                    switch (Acciones)
                    {
                        case Accion.Agregar:
                            #region Maestro
                            repoMaster.Agregar(new Transaccion
                            {
                                ClienteID = this.ClientesID,
                                Fecha = this.Fecha,
                                NumeroTransaccion = this.NumeroTransaccion,
                                Observaciones = this.Observaciones,
                                SuplidorID = this.SuplidorID
                            });
                            #endregion
                            #region Detalle
                            foreach (var item in trans.DetalleTransaccion)
                            {
                                using (var repoDetalle = new Repositorio<Detalle_Transaccion>(GetDbPath()))
                                {
                                    repoDetalle.Agregar(new Detalle_Transaccion
                                    {
                                        TransID = item.TransID,
                                        VehiculoID = item.VehiculoID,
                                        ServicioID = item.ServicioID,
                                        Descripcion = item.Descripcion,
                                        Cantidad = item.Cantidad,
                                        Precio = item.Precio,
                                        FinGarantia = item.FinGarantia
                                    });

                                    repoDetalle.Dispose();
                                }
                            } 
                            #endregion
                            break;
                        case Accion.Modificar:
                            #region Maestro
                            trans.SuplidorID = this.SuplidorID;
                            trans.ClienteID = this.ClientesID;
                            trans.Fecha = this.Fecha;
                            trans.Observaciones = this.Observaciones;
                            trans.NumeroTransaccion = this.NumeroTransaccion;

                            repoMaster.Actualizar(new Transaccion {
                                ClienteID = trans.ClienteID,
                                SuplidorID = trans.SuplidorID,
                                Fecha = trans.Fecha,
                                NumeroTransaccion = trans.NumeroTransaccion,
                                Observaciones = trans.Observaciones
                            });
                            #endregion
                            #region Detalle
                            using (var repoDetalle= new Repositorio<Detalle_Transaccion>(GetDbPath()))
                            {
                                foreach (var item in trans.DetalleTransaccion)
                                {
                                    repoDetalle.Actualizar(item);
                                }
                                repoDetalle.Dispose();
                            }
                            #endregion
                            break;
                    }

                    repoMaster.Dispose();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Transacción",
                    $"Error al guardar la Transacción {NumeroTransaccion}\nDetalle de Error: {ex.Message}",
                    "Ok");
            }
        }
        private void Cancelar()
        {
            throw new NotImplementedException();
        }
        private void Eliminar()
        {
            throw new NotImplementedException();
        }
        private async void CargarTransaccion()
        {
            try
            {
                switch (Acciones)
                {
                    case Accion.Agregar:
                        trans.SuplidorID = UsuarioActual.Codigo;
                        trans.ClienteID = this.ClientesID;
                        trans.Fecha = this.Fecha;
                        trans.NumeroTransaccion = this.NumeroTransaccion;
                        trans.Observaciones = this.Observaciones;
                        break;
                    case Accion.Modificar:
                        using (var repoDetalle= new Repositorio<Detalle_Transaccion>(GetDbPath()))
                        {
                            trans.DetalleTransaccion = (List<Detalle_Transaccion>)repoDetalle.Buscar(d => d.TransID.Equals(trans.ID));
                            repoDetalle.Dispose();
                        }
                        break;
                }

                this.SuplidorID = trans.SuplidorID;
                this.ClientesID = trans.ClienteID;
                this.Fecha = trans.Fecha;
                this.NumeroTransaccion = trans.NumeroTransaccion;
                this.Observaciones = trans.Observaciones;
                this.TransDetail = new ObservableCollection<TransDetailItemsViewModel>(this.ToTransDetailItemsViewModel());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Transacción",
                    $"Error al Cargar la Transacción {NumeroTransaccion}\nDetalle de Error: {ex.Message}",
                    "Ok");
            }
        }
        private IEnumerable<TransDetailItemsViewModel> ToTransDetailItemsViewModel() {
            return this.trans.DetalleTransaccion.Select(t => new TransDetailItemsViewModel() {
                ID=t.ID,
                TransID=t.TransID,
                VehiculoID=t.VehiculoID,
                ServicioID=t.ServicioID,
                Descripcion=t.Descripcion,
                Cantidad=t.Cantidad,
                Precio=t.Precio,
                FinGarantia=t.FinGarantia
            });
        }
        private string GenerarNumeroTrans()
        {
            int Numero = 0;
            var prefix = "FS" + ClientesID.Substring(0, 2).ToUpper();

            using (var RepoMaster = new Repositorio<Transaccion>(GetDbPath()))
            {
                Numero = ((List<Transaccion>)RepoMaster.Buscar(t => t.NumeroTransaccion.Contains(prefix) && t.SuplidorID.Equals(trans.SuplidorID))).Count();
                RepoMaster.Dispose();
            }
            return $"{prefix}{(Numero += 1).ToString().PadLeft(10 - prefix.Length, char.Parse("0"))}";
        }
        #endregion
    }
}
