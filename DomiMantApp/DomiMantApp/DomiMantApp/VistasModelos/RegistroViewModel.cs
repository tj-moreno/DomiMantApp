


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

    public class RegistroViewModel:ModeradorBase
    {
        #region Constructor
        public RegistroViewModel()
        {
            if (Acciones.Equals(Accion.Modificar))
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
        private TipoUsuario tipo;
        private bool enseccion;
        private bool recordar;
        private DateTime fechanacimiento;
        Usuarios Usuario;
        private bool verfecha;
        private bool vercedula;
        private bool verbtnborrarcuenta;
        private bool verclientes;
        private bool verdirecciones;
        private bool verservicios;
        private bool vervehiculos;
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
        public TipoUsuario Tipo {
            get {
                return this.tipo;
            }
            set {
                PasarValor(ref tipo, value);

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
                switch (Acciones)
                {
                    case Accion.Agregar:
                        Usuario = new Usuarios
                        {
                            Codigo = this.Codigo,
                            Nombres = this.Nombres,
                            Apellidos = this.Apellidos,
                            Contrasena = this.Contrasena,
                            Emails = this.Emails,
                            EnSeccion = this.EnSeccion,
                            Recordar = this.Recordar,
                            Tipo = this.Tipo
                        };

                        repo.Agregar(Usuario);
                        break;
                    case Accion.Modificar:
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
                            Tipo = this.Tipo
                        };

                        repo.Actualizar(Usuario);
                        break;                        
                }
            }                        
        }

        private void MostrarRegistro()
        {
            this.ID = UsuarioActual.ID;
            this.Codigo = UsuarioActual.Codigo;
            this.Nombres = UsuarioActual.Nombres;
            this.Apellidos = UsuarioActual.Apellidos;
            this.Contrasena = UsuarioActual.Contrasena;
            this.Emails = UsuarioActual.Emails;
            this.EnSeccion = UsuarioActual.EnSeccion;
            this.Recordar = UsuarioActual.Recordar;
            this.Tipo = UsuarioActual.Tipo;
            this.FechaNacimiento = UsuarioActual.FechaNacimiento;
        }

        private void MostrarControlesOpcionales(bool value)
        {
            VerFecha = value;
            VerCedula = value;
            VerBtnBorrarCuenta = value;            
        }

        private void EliminarCuenta()
        {
            
        }

        private void Cancelar()
        {
            
        }
        #endregion
    }
}
