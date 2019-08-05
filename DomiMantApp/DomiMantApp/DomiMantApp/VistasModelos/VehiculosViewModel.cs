

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

    public class VehiculosViewModel : ModeradorBase
    {
        #region Constructor
        public VehiculosViewModel()
        {
            listadovehiculos = new List<Vehiculos>();
        }
        #endregion
        #region Atributos
        private string nombrevehiculo;
        private string mantenimiento;
        private bool actualizando;
        private string buscar;
        private List<Vehiculos> listadovehiculos=null;
        private ObservableCollection<VehiculosItemsViewModel> vehiculos;
        #endregion
        #region Propiedades
        public string NombreVehiculo {
            get {
                return this.nombrevehiculo;
            }
            set {
                PasarValor(ref this.nombrevehiculo, value);
            }
        }
        public string Mantenimiento {
            get {
                return this.mantenimiento;
            }
            set {
                PasarValor(ref this.mantenimiento, value);
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
        public ObservableCollection<VehiculosItemsViewModel> Vehiculos {
            get {
                return this.vehiculos;
            }
            set {
                PasarValor(ref this.vehiculos, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand BuscarCommand {
            get {
                return new RelayCommand(BuscarVehiculo);
            }
        }
        public ICommand ActualizarCommand {
            get {
                return new RelayCommand(Actualizar);
            }
        }
        public ICommand AgregarNuevoCommand {
            get {
                return new RelayCommand(Nuevo);
            }
        }        
        #endregion
        #region Metodos
        private void BuscarVehiculo()
        {
            try
            {
                this.Actualizando = true;
                if (string.IsNullOrEmpty(this.Buscar))
                {
                    this.Vehiculos = new ObservableCollection<VehiculosItemsViewModel>(
                        this.ToVehiculosViewModel());
                }
                else
                {
                    this.Vehiculos = new ObservableCollection<VehiculosItemsViewModel>(
                        this.ToVehiculosViewModel().Where(
                            v=>v.Marca.Contains(buscar) ||
                            v.Modelo.Contains(Buscar) ||
                            v.Placa.Contains(Buscar) ||
                            v.UsuarioID.Contains(buscar) ||
                            v.NombreVehiculo.Contains(Buscar)));
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
            this.CargarVehiculos();
        }
        private void Nuevo()
        {
            throw new NotImplementedException();
        }
        private void CargarVehiculos()
        {
            try
            {
                Actualizando = true;
                using (var repoVehiculo= new Repositorio<Vehiculos>(GetDbPath()))
                {                    
                    this.listadovehiculos = repoVehiculo.Buscar(v => v.UsuarioID.Equals("J"), v=>v.Marca).ToList();
                }
                this.Vehiculos = new ObservableCollection<VehiculosItemsViewModel>(
                    this.ToVehiculosViewModel());
                Actualizando = false;
            }
            catch (Exception)
            {
                Actualizando = false;
                throw;
            }
        }
        private IEnumerable<VehiculosItemsViewModel> ToVehiculosViewModel()
        {
            return this.listadovehiculos.Select(v=> new VehiculosItemsViewModel() {
                ID=v.ID,
                UsuarioID=v.UsuarioID,
                VehiculoID=v.VehiculoID,
                Marca=v.Marca,
                Modelo=v.Modelo,
                Anio=v.Anio,
                Placa=v.Placa,
                PlazoMantenimientos=v.PlazoMantenimientos
            });
        }
        #endregion
    }
}
