
namespace DomiMantApp.VistasModelos
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ModeradorBase: INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string NombrePropiedad = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NombrePropiedad));
        }

        protected void PasarValor<T>(ref T ValorAnterior, T valor, [CallerMemberName] string NombrePropiedad = null) {
            if (EqualityComparer<T>.Default.Equals(ValorAnterior, valor))
            {
                return;
            }

            ValorAnterior = valor;
            OnPropertyChanged(NombrePropiedad);
        }
    }
}
