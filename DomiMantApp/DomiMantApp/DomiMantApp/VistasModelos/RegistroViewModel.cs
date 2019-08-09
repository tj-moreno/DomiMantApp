


namespace DomiMantApp.VistasModelos
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using static DomiMantApp.Globals.Variables;
    using Modelos;
    using static Globals.Funciones;
    using Repositorios;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using Xamarin.Forms;

    public class RegistroViewModel:ModeradorBase
    {
        #region Constructor
        public RegistroViewModel()
        {
            TipoItems = GetTiposUsuarios();
            
            if (Accion.Equals(Acciones.Modificar))
            {
                MostrarRegistro();
                MostrarControlesOpcionales(true);
            }
            else
            {
                MostrarControlesOpcionales(false);
            }
        }
        #endregion
        #region Atributos
        private int id;
        private string codigo;
        private string nombres;
        private string apellidos;
        private string emails;
        private string contrasena;
        private TiposUsuario tipo;
        private List<TiposUsuario> tipositems;
        private bool enseccion;
        private bool recordar;
        private DateTime fechanacimiento;
        private string confirmarcontrasena;
        private List<OpcioneCuentas> opcioneslst;
        private ObservableCollection<OpcionesCuentasItemsViewModel> opcionescuentas;
        Usuarios Usuario;
        private bool verfecha;
        private bool vercedula;
        private bool verbtnborrarcuenta;
        private bool verclientes;
        private bool verdirecciones;
        private bool verservicios;
        private bool vervehiculos;
        private bool veropciones;
        #endregion
        #region Propiedades
        public int ID {
            get {
                return this.id;
            }
            set {
                PasarValor(ref this.id, value);
            }
        }
        public string Codigo {
            get {
                return this.codigo;
            }
            set {
                PasarValor(ref this.codigo, value);
            }
        }
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
        public string Contrasena {
            get {
                return this.contrasena;
            }
            set {
                PasarValor(ref this.contrasena, value);
            }
        }
        public TiposUsuario Tipo {
            get {
                return this.tipo;
            }
            set {
                PasarValor(ref this.tipo, value);
            }
        }
        public List<TiposUsuario> TipoItems {
            get {
                return this.tipositems;
            }
            set {
                PasarValor(ref this.tipositems, value);
            }
        }
        public string ConfirmarContrasena {
            get {
                return this.confirmarcontrasena;
            }
            set {
                PasarValor(ref this.confirmarcontrasena, value);
                ConfirmPassword();
            }
        }
        public DateTime FechaNacimiento {
            get {
                return this.fechanacimiento;
            }
            set {
                PasarValor(ref this.fechanacimiento, value);
            }
        }
        public List<OpcioneCuentas> OpcionesCuenta {
            get {
                return this.opcioneslst;
            }
            set {
                PasarValor(ref this.opcioneslst, value);
            }
        }
        public ObservableCollection<OpcionesCuentasItemsViewModel> OpcionesCuentas {
            get {
                return this.opcionescuentas;
            }
            set {
                PasarValor(ref this.opcionescuentas, value);
            }
        }
        public bool EnSeccion {
            get {
                return this.enseccion;
            }
            set {
                PasarValor(ref this.enseccion, value);
            }
        }
        public bool Recordar {
            get {
                return this.recordar;
            }
            set {
                PasarValor(ref this.recordar, value);
            }
        }
        public bool VerFecha {
            get {
                return this.verfecha;
            }
            set {
                PasarValor(ref this.verfecha, value);
            }
        }
        public bool VerCedula {
            get {
                return this.vercedula;
            }
            set {
                PasarValor(ref this.vercedula, value);
            }
        }
        public bool VerBtnBorrarCuenta {
            get {
                return this.verbtnborrarcuenta;
            }
            set {
                PasarValor(ref this.verbtnborrarcuenta, value);
            }
        }
        public bool VerDirecciones {
            get {
                return this.verdirecciones;
            }
            set {
                PasarValor(ref this.verdirecciones, value);
            }
        }
        public bool VerVehiculos {
            get {
                return this.vervehiculos;
            }
            set {
                PasarValor(ref this.vervehiculos, value);
            }
        }
        public bool VerClientes {
            get {
                return this.verclientes;
            }
            set {
                PasarValor(ref this.verclientes, value);
            }
        }
        public bool VerServicios {
            get {
                return this.verservicios;
            }
            set {
                PasarValor(ref this.verservicios, value);
            }
        }
        #endregion    
        #region Comandos
        public ICommand btnGuardar {
            get {
                return new RelayCommand(GuardarRegistro);
            }
        }
        public ICommand btnEliminar {
            get {
                return new RelayCommand(EliminarCuenta);
            }
        }
        public ICommand btnCancelar {
            get {
                return new RelayCommand(Cancelar);
            }
        }
        #endregion
        #region Metodos
        private void GuardarRegistro()
        {
            using (var repo = new Repositorio<Usuarios>(GetDbPath()))
            {
                switch (Accion)
                {
                    case Acciones.Agregar:
                        Usuario = new Usuarios
                        {
                            Codigo = this.Codigo,
                            Nombres = this.Nombres,
                            Apellidos = this.Apellidos,
                            Contrasena = this.Contrasena,
                            Emails = this.Emails,
                            EnSeccion = this.EnSeccion,
                            Recordar = this.Recordar,
                            Tipo = this.Tipo.TipoID
                        };

                        repo.Agregar(Usuario);
                        Moderador_De_Vistas.ObtenerInstancia().Login = new LoginViewModel();
                        Application.Current.MainPage.Navigation.PopAsync();
                        break;
                    case Acciones.Modificar:
                        Usuario = new Usuarios
                        {
                            ID = this.ID,
                            Codigo = this.Codigo,
                            Nombres = this.Nombres,
                            Apellidos = this.Apellidos,
                            Contrasena = this.Contrasena,
                            Emails = this.Emails,
                            EnSeccion = this.EnSeccion,
                            Recordar = this.Recordar,
                            Tipo = this.Tipo.TipoID
                        };

                        repo.Actualizar(Usuario);
                        break;
                }
            }                        
        }
        private void MostrarRegistro()
        {
            if (UsuarioActual!=null)
            {
                this.ID = UsuarioActual.ID;
                this.Codigo = UsuarioActual.Codigo;
                this.Nombres = UsuarioActual.Nombres;
                this.Apellidos = UsuarioActual.Apellidos;
                this.Contrasena = UsuarioActual.Contrasena;
                this.Emails = UsuarioActual.Emails;
                this.EnSeccion = UsuarioActual.EnSeccion;
                this.Recordar = UsuarioActual.Recordar;
                this.Tipo = TipoItems.FirstOrDefault(t => t.TipoID.Equals(UsuarioActual.Tipo));
                this.FechaNacimiento = UsuarioActual.FechaNacimiento; 
            }
        }
        private void MostrarControlesOpcionales(bool value)
        {
            VerFecha = value;
            VerCedula = value;
            VerBtnBorrarCuenta = value;
            veropciones = value;
        }
        private async void EliminarCuenta()
        {
            try
            {
                var Autorizado = await Application.Current.MainPage.DisplayAlert(
                    "Cuenta",
                    $"Seguro que desea eliminar la cuenta {Codigo}?",
                    "Si",
                    "No");

                if (!Autorizado)
                    return;

                using (var repo = new Repositorio<Usuarios>(GetDbPath()))
                {
                    repo.Eliminar(Usuario);
                    repo.Dispose();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Cuenta",
                    $"Error al intentar eliminar la cuenta {Codigo}\nDescripción del Error: {ex.Message}",
                    "Ok");
            }
        }
        private async void Cancelar()
        {
            switch (Accion)
            {
                case Acciones.Agregar:
                    Moderador_De_Vistas.ObtenerInstancia().Login = new LoginViewModel();
                    await Application.Current.MainPage.Navigation.PopAsync();
                    break;
                case Acciones.Modificar:
                    break;
            }
        }
        private async void ConfirmPassword()
        {
            var pass = Contrasena.Substring(0, ConfirmarContrasena.Length);

            if (pass != ConfirmarContrasena)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "DomiMant Apps",
                    "La contraseña no coincide con la anterior",
                    "Ok");

                ConfirmarContrasena = "";
            }
        }
        #endregion
    }
}
