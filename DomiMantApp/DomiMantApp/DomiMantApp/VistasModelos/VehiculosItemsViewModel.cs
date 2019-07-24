using DomiMantApp.Modelos;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DomiMantApp.VistasModelos
{
    public class VehiculosItemsViewModel: VehiculosView
    {
        #region Constructor
        public VehiculosItemsViewModel()
        {

        }
        #endregion
        #region Comandos
        public ICommand SeleccionVehiculo {
            get {
                return new RelayCommand(Seleccion);
            }
        }
        #endregion
        #region Metodos
        private void Seleccion()
        {
            
        }
        #endregion
    }
}
