
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ClientesItemsViewModel:ClientesView
    {
        #region Atributos
        private ClientesViewModel vmclientes;
        #endregion
        #region Comandos
        public ICommand SeleccionCommando {
            get {
                return new RelayCommand(SeleccionCliente);
            }
        }
        #endregion
        #region Metodos
        private void SeleccionCliente()
        {
            //Moderador_De_Vistas.ObtenerInstancia().Vehiculos = new VehiculosViewModel();
            //App.Current.MainPage = new NavigationPage(new vehiculosPage());
        }
        #endregion
        #region Constructores
        public ClientesItemsViewModel(ClientesViewModel clientes)
        {
            this.vmclientes = clientes;
        }
        #endregion
    }
}
