

namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using static Globals.Funciones;
    using static Globals.Variables;
    using System.Windows.Input;

    public class ServicioViewModel : ModeradorBase
    {
        #region Constructor
        public ServicioViewModel(Servicios _servicio=null)
        {
            this.servicios = _servicio;
        }
        #endregion

        #region Atributos
        private string codigo;
        private string descripcion;
        private double precio;
        private bool garantia;
        private double tiempogarantia;
        private Servicios servicios;
        #endregion

        #region Propiedades
        public string Codigo {
            get {
                return this.codigo;
            }
            set {
                PasarValor(ref this.codigo, value);

            }
        }
        public string Descripcion {
            get {
                return this.descripcion;
            }
            set {
                PasarValor(ref this.descripcion, value);
            }
        }
        public double Precio {
            get {
                return this.precio;
            }
            set {
                PasarValor(ref this.precio, value);
            }
        }
        public bool Garantia {
            get {
                return this.garantia;
            }
            set {
                PasarValor(ref this.garantia, value);

            }
        }
        public double Tiempogarantia {
            get {
                return this.tiempogarantia;
            }
            set {
                PasarValor(ref this.tiempogarantia, value);
            }
        }
        #endregion

        #region Comandos
        public ICommand GuardarServicio {
            get {
                return new RelayCommand(Guardar);
            }
        }

        public ICommand CancelarCommand {
            get {
                return new RelayCommand(Cancelar);
            }
        }        

        public ICommand BorrarServicio {
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
                using (var repositorio = new Repositorio<Servicios>(GetDbPath()))
                {
                    switch (Acciones)
                    {
                        case Accion.Agregar:
                            repositorio.Agregar(new Servicios {
                                Codigo = this.Codigo,
                                Descripcion=this.Descripcion,
                                Garantia=this.Garantia,
                                Precio=this.Precio,
                                SuplidorID=UsuarioActual.Codigo,
                                Tiempogarantia=this.Tiempogarantia
                            });
                            break;
                        case Accion.Modificar:
                            servicios = new Servicios {
                                ID=servicios.ID,
                                Codigo=this.Codigo,
                                Descripcion=this.Descripcion,
                                Garantia=this.Garantia,
                                Precio=this.Precio,
                                SuplidorID=servicios.SuplidorID,
                                Tiempogarantia=this.Tiempogarantia
                            };

                            repositorio.Actualizar(servicios);
                            break;                        
                    }
                    repositorio.Dispose();
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert(
                    $"Error al {Acciones.ToString()}",
                    $"Descripcion:\n{ex.Message}",
                    "Ok");
            }
        }

        private void Cancelar()
        {
            throw new NotImplementedException();
        }

        private async void Eliminar()
        {
            try
            {
                var respuesta = await App.Current.MainPage.DisplayAlert(
                        "Servicios",
                        $"Esta seguro que desea eliminar el servicio {Descripcion} de su cartera de productos?",
                        "Si",
                        "No");

                if (!respuesta)
                    return;

                using (var repo= new Repositorio<Servicios>(GetDbPath()))
                {
                    repo.Eliminar(servicios);
                    repo.Dispose();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Servicios",
                    $"Error al intentar eliminar el servicio {Descripcion}.\nDescipcion del Error:\n{ex.Message}",
                    "Ok");                
            }
        }
        #endregion
    }
}
