
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using static Globals.Funciones;
    using static Globals.Variables;
    using System.Text;
    using System.Windows.Input;

    public class TransaccionesViewModel : ModeradorBase
    {
        #region Constructores
        public TransaccionesViewModel()
        {

        }
        #endregion
        #region Atributos
        private bool cargando;
        private string transaccionid;
        private string fechadoc;
        private string buscar;
        private ObservableCollection<TransaccionesItemsViewModel> transacciones;
        private List<Transaccion> transaccionlst;
        #endregion
        #region Propiedades
        public bool Cargando {
            get {
                return this.cargando;
            }
            set {
                PasarValor(ref this.cargando, value);
            }
        }
        public string TransaccionID {
            get {
                return this.transaccionid;
            }

            set {
                PasarValor(ref this.transaccionid, value);
            }
        }
        public string FechaDoc {
            get {
                return this.fechadoc;
            }
            set {
                PasarValor(ref this.fechadoc, value);
            }
        }
        public string Buscar {
            get {
                return this.buscar;
            }
            set {
                PasarValor(ref this.buscar, value);
                this.BuscarTransaccion();
            }
        }
        public ObservableCollection<TransaccionesItemsViewModel> Transacciones {
            get {
                return this.transacciones;
            }
            set {
                PasarValor(ref this.transacciones, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(BuscarTransaccion);
            }
        }        
        public ICommand ActualizarCommand {
            get {
                return new RelayCommand(Actualizar);
            }
        }        
        public ICommand AgregarCommand {
            get {
                return new RelayCommand(Agregar);
            }
        }        
        #endregion
        #region Metodos
        private void BuscarTransaccion()
        {
            if (string.IsNullOrEmpty(this.Buscar)) {
                this.Transacciones = new ObservableCollection<TransaccionesItemsViewModel>(
                    this.ToTransaccionesItemsViewModel());
            }
            else {
                this.Transacciones = new ObservableCollection<TransaccionesItemsViewModel>(
                    this.ToTransaccionesItemsViewModel().Where(
                        t=>t.TransaccionID.ToUpper().Contains(this.Buscar.ToUpper()) ||
                        t.FechaDoc.Contains(this.Buscar)));
            }
        }
        private void Actualizar()
        {
            CargarTransacciones();
        }
        private void Agregar()
        {
            
        }
        private async void CargarTransacciones()
        {
            try
            {
                this.Cargando = true;
                using (var repoTrans = new Repositorio<Transaccion>(GetDbPath()))
                {
                    this.transaccionlst = (List<Transaccion>)repoTrans.Buscar(t => t.ClienteID.Equals("") && t.SuplidorID.Equals(UsuarioActual.Codigo));
                    repoTrans.Dispose();
                }

                this.transaccionlst = this.transaccionlst.OrderBy(t => t.NumeroTransaccion).OrderBy(t => t.Fecha).ToList();
                this.Transacciones = new ObservableCollection<TransaccionesItemsViewModel>(this.ToTransaccionesItemsViewModel());
                this.Cargando = false;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Transacciones",
                    $"Error catgando las Transacciones\nDetalle del Error : {ex.Message}.",
                    "Ok");
            }
        }
        private IEnumerable<TransaccionesItemsViewModel> ToTransaccionesItemsViewModel()
        {
            return this.transacciones.Select(t => new TransaccionesItemsViewModel() {
                Id=t.Id,
                NumeroTransaccion=t.NumeroTransaccion,
                ClienteID=t.ClienteID,
                Fecha=t.Fecha,
                Observaciones=t.Observaciones,
                SuplidorID=t.SuplidorID
            });
        }
        #endregion
    }
}
