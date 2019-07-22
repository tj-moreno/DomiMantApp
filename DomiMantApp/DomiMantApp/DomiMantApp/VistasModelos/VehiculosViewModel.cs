﻿

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows.Input;

    public class VehiculosViewModel : ModeradorBase
    {
        #region Constructor
        public VehiculosViewModel()
        {

        }
        #endregion

        #region Atributos
        private string nombrevehiculo;
        private string mantenimiento;
        private ObservableCollection<VehiculosItemsViewModel> vehiculos;
        private bool actualizando;
        private List<Vehiculos> listadovehiculos;
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
        public ObservableCollection<VehiculosItemsViewModel> Vehiculos {
            get {
                return this.vehiculos;
            }
            set {
                PasarValor(ref this.vehiculos, value);
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
        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private void Actualizar()
        {
            throw new NotImplementedException();
        }

        private void Nuevo()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
