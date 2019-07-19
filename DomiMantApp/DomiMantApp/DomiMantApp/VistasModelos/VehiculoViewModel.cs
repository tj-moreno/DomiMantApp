

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using static Globals.Funciones;
    using static Globals.Variables;
    using System.Windows.Input;

    public class VehiculoViewModel : ModeradorBase
    {
        #region Constructor
        public VehiculoViewModel(Vehiculos _vehiculos=null)
        {
            this.vehiculos = _vehiculos;
        }
        #endregion

        #region Atributos
        private string usuarioid;
        private string vehiculoid;
        private string marca;
        private string modelo;
        private int anio;
        private string placa;
        private int plazomantenimientos;
        private bool verusuarioid;

        private Vehiculos vehiculos;
        #endregion

        #region Propiedades
        public string UsuarioID {
            get {
                return this.usuarioid;
            }
            set {
                PasarValor(ref this.usuarioid, value);
            }
        }
        public string VehiculoID {
            get {
                return this.vehiculoid;
            }
            set {
                PasarValor(ref this.vehiculoid, value);
            }
        }
        public string Marcha {
            get {

                return this.marca;
            }
            set {
                PasarValor(ref this.marca, value);
            }
        }
        public string Modelo {
            get {
                return this.modelo;

            }
            set {
                PasarValor(ref this.modelo, value);
            }
        }
        public int Anio {
            get {
                return this.anio;
            }
            set {
                PasarValor(ref this.anio, value);
            }
        }
        public string Placa {
            get {
                return this.placa;
            }
            set {
                PasarValor(ref this.placa, value);
            }
        }
        public int PlazoMantenimientos {
            get {
                return this.plazomantenimientos;
            }
            set {
                PasarValor(ref this.plazomantenimientos, value);
            }
        }
        #endregion

        #region Comandos
        public ICommand GuardarVehuculo {
            get {
                return new RelayCommand(Guardar);
            }
        }

        public ICommand VehiculoCancelar {
            get {
                return new RelayCommand(Cancelar);
            }
        }
        
        public ICommand VehiculoEliminar {
            get {
                return new RelayCommand(Eliminar);
            }
        }        
        #endregion

        #region Metodos
        private void Guardar()
        {
            try
            {
                //Falta hacer las validaciones de los campos a almacenar (Reglas)

                using (var repo = new Repositorio<Vehiculos>(GetDbPath()))
                {                    
                    switch (Acciones)
                    {
                        case Accion.Agregar:                            
                            repo.Agregar(new Vehiculos {
                                VehiculoID=this.VehiculoID,
                                Marca=this.Marcha,
                                Modelo=this.Modelo,
                                Placa=this.Placa,
                                UsuarioID=this.UsuarioID,
                                Anio=this.Anio,
                                PlazoMantenimientos=this.PlazoMantenimientos
                            });
                            break;
                        case Accion.Modificar:
                            vehiculos.VehiculoID = this.VehiculoID;
                            vehiculos.UsuarioID = this.UsuarioID;
                            vehiculos.Marca = this.Marcha;
                            vehiculos.Modelo = this.Modelo;
                            vehiculos.Anio = this.Anio;
                            vehiculos.Placa = this.Placa;
                            vehiculos.PlazoMantenimientos = this.PlazoMantenimientos;

                            repo.Actualizar(vehiculos);
                            break;
                    }                
                    repo.Dispose();
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert(
                    "Vehiculos",
                    $"Descripcion de Error:\n{ex.Message}",
                    "Ok");
            }
        }        

        private void Cancelar()
        {
            throw new NotImplementedException();
        }

        private async void Eliminar()
        {
            var autorizado = await App.Current.MainPage.DisplayAlert(
                "Vehiculos",
                $"Seguro que desea eliminar el vehiculo {VehiculoID}",
                "Si",
                "No");

            if (!autorizado)
                return;

            using (var repo = new Repositorio<Vehiculos>(GetDbPath()))
            {
                repo.Eliminar(vehiculos);
                repo.Dispose();
            }
        }
        #endregion

    }
}
