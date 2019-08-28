

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using static Globals.Funciones;
    using static Globals.Variables;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;
    using DomiMantApp.Repositorios;

    public class TransDetailsViewModel : ModeradorBase
    {
        #region Constructor
        public TransDetailsViewModel()
        {
        }
        #endregion
        #region Atributos
        private string vehiculo;
        private string descrip;
        private string garantiahasta;
        private string buscar;
        private bool actualizar;
        private List<Detalle_Transaccion> detalletrans;
        private ObservableCollection<TransDetailItemsViewModel> detalle;
        #endregion
        #region Propiedades
        public string Vehiculo {
            get {
                return this.vehiculo;
            }
            set {
                PasarValor(ref this.vehiculo, value);
            }
        }
        public string Descrip {
            get {
                return this.descrip;
            }
            set {
                PasarValor(ref this.descrip, value);
            }
        }
        public string GarantiaHasta {
            get {
                return this.garantiahasta;
            }
            set {
                PasarValor(ref this.garantiahasta, value);
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
        public bool Actualizar {
            get {
                return this.actualizar;
            }
            set {
                PasarValor(ref this.actualizar, value);
            }
        }
        public ObservableCollection<TransDetailItemsViewModel> Detalle {
            get {
                return this.detalle;
            }
            set {
                PasarValor(ref this.detalle, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(BuscarDetall);
            }
        }
        public ICommand ActualizarCommand {
            get {
                return new RelayCommand(Refrescar);
            }
        }
        public ICommand AgregarCommand {
            get {
                return new RelayCommand(Agregar);
            }
        }
        #endregion
        #region Metodos
        private void BuscarDetall()
        {
            try
            {                
                using (var repoDetail= new Repositorio<Detalle_Transaccion>(GetDbPath()))
                {
                    if (string.IsNullOrEmpty(this.Buscar))
                    {
                        this.Detalle = new ObservableCollection<TransDetailItemsViewModel>(
                               this.ToTransDetailViewModel());
                    }
                    else
                    {
                        this.Detalle = new ObservableCollection<TransDetailItemsViewModel>(
                            this.ToTransDetailViewModel().Where(
                                d => d.Vehiculo.ToUpper().Contains(this.Buscar.ToUpper()) ||
                                d.Descrip.ToUpper().Contains(this.Buscar.ToUpper())));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void Refrescar()
        {
            this.CargarDetalle();
        }
        private void Agregar()
        {
            throw new NotImplementedException();
        }
        private async void CargarDetalle()
        {
            try
            {
                this.Actualizar = true;
                using (var repoDetalle= new Repositorio<Detalle_Transaccion>(GetDbPath()))
                {
                    detalletrans = repoDetalle.Buscar(t => t.TransID.Equals(5), td=>td.VehiculoID).ToList();
                    repoDetalle.Dispose();
                }

                Detalle = new ObservableCollection<TransDetailItemsViewModel>(this.ToTransDetailViewModel());
                this.Actualizar = false;
            }
            catch (Exception ex)
            {
                this.Actualizar = false;
                await App.Current.MainPage.DisplayAlert(
                    "Detalle Transaccion",
                    $"Se produjo un error cargando el detalle\nDescripcion del error: {ex.Message}",
                    "Ok"); 
            }
        }
        private IEnumerable<TransDetailItemsViewModel> ToTransDetailViewModel()
        {
            return this.detalletrans.Select(td=>new TransDetailItemsViewModel() {
                Id=td.Id,
                TransID=td.TransID,
                VehiculoID=td.VehiculoID,
                ServicioID=td.ServicioID,
                Descripcion=td.Descripcion,
                Cantidad=td.Cantidad, 
                Precio=td.Precio,
                FinGarantia=td.FinGarantia
            });
        }
        #endregion
    }
}
