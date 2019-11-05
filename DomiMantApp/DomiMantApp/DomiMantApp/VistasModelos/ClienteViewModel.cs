

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using static Globals.Funciones;
    using static Globals.Variables;

    public class ClienteViewModel : ModeradorBase
    {
        #region Constructor
        public ClienteViewModel()
        {

        }
        #endregion
        #region Atributos
        private string codigo;
        private string nombres;
        private string apellidos;
        private string emails;
        private string cedula;
        private Clientes clientes;
        #endregion
        #region Propiedades
        public string Nombres {
            get {
                return this.nombres;
            }
            set {
                PasarValor(ref this.nombres, value);
            }
        }
        public string Apellidos {
            get {
                return this.apellidos;
            }
            set {
                PasarValor(ref this.apellidos, value);
            }
        }
        public string Emails {
            get {
                return this.emails;
            }
            set {
                PasarValor(ref this.emails, value);
            }
        }
        public string Cedual {
            get {
                return this.cedula;
            }
            set {
                PasarValor(ref this.cedula, value);
            }
        }
        #endregion
        #region Comandos
        public ICommand btnGuardar {
            get {
                return new RelayCommand(Guardar);
            }
        }
        public ICommand btnCancelar {
            get {
                return new RelayCommand(Cancelar);
            }
        }
        public ICommand btnEliminar {
            get {
                return new RelayCommand(Eliminar);
            }
        }
        #endregion
        #region Metodos
        private void Guardar()
        {
            if (UsuarioActual != null && UsuarioActual.Tipo.Equals(2))
            {
                if (string.IsNullOrEmpty(this.Nombres))
                {

                }
            }
        }
        private void Cancelar()
        {

        }
        private void Eliminar()
        {

        }
        #endregion

    }
}
