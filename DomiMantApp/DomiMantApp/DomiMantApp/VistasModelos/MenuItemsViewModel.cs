

namespace DomiMantApp.VistasModelos
{
    using GalaSoft.MvvmLight.Command;    
    using System.Windows.Input;

    public class MenuItemsViewModel
    {
        #region Propiedades
        public string Icon { get; set; }
        public string Titulo { get; set; }
        public string Pagina { get; set; }
        #endregion
        #region Comando
        public ICommand NavegacionCommand
        {
            get
            {
                return new RelayCommand(Navegar);
            }
        }
        #endregion
        #region Metodo
        private void Navegar()
        {
            switch (this.Pagina)
            {
                default:
                    break;
            }
        }
        #endregion
    }
}
