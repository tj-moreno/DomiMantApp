
namespace DomiMantApp.VistasModelos
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;

    public class OpcionesCuentasItemsViewModel:Opciones
    {
        #region Constructor
        public OpcionesCuentasItemsViewModel()
        {

        }
        #endregion
        #region Comandos
        public ICommand SelectOpcionCommenad {
            get {
                return new RelayCommand(SelectOpcion);
            }
        }
        #endregion
        #region Metodos
        private void SelectOpcion()
        {
            
        }
        #endregion
    }
}
