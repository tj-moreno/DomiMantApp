

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

    public class DireccionesItemViewModel : Direcciones
    {
        #region Constructor
        public DireccionesItemViewModel()
        {

        }
        #endregion

        #region Atributos
        
        #endregion

        #region Propiedades

        #endregion

        #region Comandos
        public ICommand DireccionClick {
            get {
                return new RelayCommand(VerDireccion);
            }
        }
        #endregion

        #region Metodos
        private void VerDireccion()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
