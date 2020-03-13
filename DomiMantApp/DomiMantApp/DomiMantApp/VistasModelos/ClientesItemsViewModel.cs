
namespace DomiMantApp.VistasModelos
{
    using DomiMantApp.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ClientesItemsViewModel:ClientesView
    {
        #region Atributos
        private ClientesViewmodel vmclientes;
        #endregion
        #region Comandos

        #endregion
        #region Constructores
        public ClientesItemsViewModel(ClientesViewmodel clientes)
        {
            this.vmclientes = clientes;
        }
        #endregion
    }
}
