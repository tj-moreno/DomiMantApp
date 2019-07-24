
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

    public class TransDetailItemsViewModel: DetalleTransaccion
    {
        #region Constructor
        public TransDetailItemsViewModel()
        {

        }
        #endregion
        #region Comandos
        public ICommand SeleccionCommand
        {
            get
            {
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
