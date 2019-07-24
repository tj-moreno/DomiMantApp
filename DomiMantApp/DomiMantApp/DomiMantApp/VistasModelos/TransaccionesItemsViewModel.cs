

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class TransaccionesItemsViewModel : DetalleTransaccion
    {
        #region Constructor
        public TransaccionesItemsViewModel()
        {

        }
        #endregion
        #region Comandos
        public ICommand SeleccionCommand {
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
