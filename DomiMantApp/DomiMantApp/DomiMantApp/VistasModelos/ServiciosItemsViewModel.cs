

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class ServiciosItemsViewModel: ServiciosView
    {
        
        #region Comandos
        public ICommand ComandoSeleccionServisio {
            get {
                return new RelayCommand(VerServicio);
            }
        }
        #endregion

        #region Metodos
        private void VerServicio()
        {
            //Moderador_De_Vistas.ObtenerInstancia().Servicio
        }
        #endregion

        #region Constructor
        public ServiciosItemsViewModel()
        {
        }
        #endregion
    }
}
