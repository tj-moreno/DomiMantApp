
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using DomiMantApp.Repositorios;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using static Globals.Variables;
    using static Globals.Funciones;

    public class ClientesViewModel : ModeradorBase
    {
        #region Atibutos
        private ObservableCollection<ClientesItemsViewModel> _clientes;
        private string fullname;
        private string codigo;
        private string cedula;
        private bool isrefresh;
        private string search;
        private List<Cliente> clienteslst;
        #endregion
        #region Propiedades
        public ObservableCollection<ClientesItemsViewModel> Clientes {
            get {
                return this._clientes;
            }
            set {
                PasarValor(ref this._clientes, value);
            }
        }
        //public int ID {
        //    get {
        //        return this.id;
        //    }
        //    set {
        //        PasarValor(ref this.id, value);
        //    }
        //}
        public string FullName {
            get {
                return this.fullname;
            }
            set {
                PasarValor(ref this.fullname, value);
            }
        }
        public string CodigoID {
            get {
                return this.codigo;
            }
            set {
                PasarValor(ref this.codigo, value);
            }
        }                    
        public string Cedula {
            get {
                return this.cedula;
            }
            set {
                PasarValor(ref this.cedula, value);
            }
        }
        public bool IsReferesh {
            get {
                return this.isrefresh;
            }
            set {
                PasarValor(ref this.isrefresh, value);
            }
        }
        public string Search {
            get {
                return this.search;
            }
            set {
                PasarValor(ref this.search, value);
                this.Buscar();
            }
        }
        #endregion
        #region Comandos
        public ICommand SearchCommand {
            get {
                return new RelayCommand(Buscar);
            }
        }       
        public ICommand RefreshCommand {
            get {
                return new RelayCommand(Refrescar);
            }
        }        
        #endregion
        #region Metodos
        private async void Buscar()
        {
            try
            {
                this.IsReferesh = true;
                if (string.IsNullOrEmpty(this.Search))
                {
                    this.Clientes = new ObservableCollection<ClientesItemsViewModel>(this.A_ClientesViewModel());
                }
                else {
                    this.Clientes = new ObservableCollection<ClientesItemsViewModel>(
                        this.A_ClientesViewModel().Where(c => c.FullName.ToUpper().Contains(this.Search.ToUpper()) ||                                                      
                            c.ClienteID.ToUpper().Contains(this.Search.ToUpper()))
                        );
                }
                this.IsReferesh = false;
            }
            catch (Exception ex)
            {
                this.IsReferesh = false;
                await App.Current.MainPage.DisplayAlert(
                    "Domimant App",
                    ex.Message,
                    "Ok");
            }
        }
        private void Refrescar()
        {
            this.CargarClientes();
        }
        public async void CargarClientes()
        {
            try
            {
                this.IsReferesh = true;
                using (var repo= new Repositorio<Cliente>(GetDbPath()))
                {
                    var _clientes = (List<Cliente>)repo.Buscar(t => t.MecanicoID.Equals(UsuarioActual.Codigo)).ToList();

                    this.clienteslst = _clientes.OrderBy(cl => cl.Id).OrderBy(cn => cn.Nombres).ToList();
                    this.Clientes = new ObservableCollection<ClientesItemsViewModel>(this.A_ClientesViewModel());
                }
                this.IsReferesh = false;
            }
            catch (Exception ex)
            {
                this.IsReferesh = false;
                await App.Current.MainPage.DisplayAlert(
                    "Domimant App",
                    ex.Message,
                    "Ok");
            }
        }
        private IEnumerable<ClientesItemsViewModel> A_ClientesViewModel()
        {
            return this.clienteslst.Select(cl => new ClientesItemsViewModel(this)
            {
                Id = cl.Id,
                Codigo = cl.Codigo,
                Nombres = cl.Nombres,
                Apellidos = cl.Apellidos,
                Cedula = cl.Cedula,
                Emails = cl.Emails,
                MecanicoID = cl.MecanicoID
            });
        }
        #endregion
        #region Constructores
        public ClientesViewModel()
        {            
            this.CargarClientes();
        }
        #endregion
    }
}
