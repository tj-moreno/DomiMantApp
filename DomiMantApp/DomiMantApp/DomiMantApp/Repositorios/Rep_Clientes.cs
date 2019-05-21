
namespace DomiMantApp.Repositorios
{
    using SQLite;
    using Modelos;
    public class Rep_Clientes
    {
        public string DBPaht;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbPaht"></param>
        public Rep_Clientes(string dbPaht)
        {
            this.DBPaht = dbPaht;

            using (var _cn= new SQLiteConnection(this.DBPaht))
            {
                _cn.CreateTable<Clientes>();                
            }
        }

        /// <summary>
        /// Agregar Nuevo Cliente
        /// </summary>
        /// <param name="Cliente"></param>
        public void AgregarCliente(Clientes cliente)
        {
            using (var _cn = new SQLiteConnection(this.DBPaht))
            {
                _cn.Insert(cliente);
            }
        }

        /// <summary>
        /// Modificar Cliente Existente
        /// </summary>
        /// <param name="cliente"></param>
        public void ModificarCliente(Clientes cliente) {
            using (var _cn= new SQLiteConnection(this.DBPaht))
            {
                var _cliente = _cn.Table<Clientes>().FirstOrDefault(c => c.ID.Equals(cliente.ID));

                if (_cliente!=null)
                {
                    _cliente.UsuarioID = cliente.UsuarioID;
                    _cliente.MecanicoID = cliente.MecanicoID;
                    _cliente.VehiculoID = cliente.VehiculoID;

                    _cn.Update(_cliente);
                }
            }
        }

        /// <summary>
        /// Consultar Clientes
        /// </summary>
        /// <returns></returns>
        public Respuesta ObtenerClientes() {
            using (var _cn= new SQLiteConnection(this.DBPaht))
            {
                var _clientes = _cn.Table<Clientes>().ToList();

                if (_clientes!=null)
                {
                    return new Respuesta
                    {
                        EsCorrecto = true,
                        Mensaje = "Ok",
                        Resultado = _clientes
                    };
                }

                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje = "No existen registros de Clientes."
                };
            }
        }

        /// <summary>
        /// Consultar Cliente por Codigo de Usuario
        /// </summary>
        /// <param name="CodigoUsuario"></param>
        /// <returns></returns>
        public Respuesta ObtenerClientePorUsuario(string CodigoUsuario)
        {
            using (var _cn= new SQLiteConnection(this.DBPaht))
            {
                var respuesta = _cn.Table<Clientes>().FirstOrDefault(c => c.UsuarioID.Equals(CodigoUsuario));

                if (respuesta!=null)
                {
                    return new Respuesta
                    {
                        EsCorrecto = true,
                        Mensaje = "Ok",
                        Resultado = respuesta
                    };
                }

                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje = string.Format("No se encontro resultados para el cliente {0}.", CodigoUsuario)
                };
            }
        }

        /// <summary>
        /// Consultar Liente por Codigo de Mecanico
        /// </summary>
        /// <param name="CodigoMecanico"></param>
        /// <returns></returns>
        public Respuesta ObtenerclientesPorMecanico(string CodigoMecanico) {
            using (var _cn= new SQLiteConnection(this.DBPaht))
            {
                var respuesta = _cn.Table<Clientes>().Where(m => m.MecanicoID.Equals(CodigoMecanico)).ToList();

                if (respuesta!=null)
                {
                    return new Respuesta
                    {
                        EsCorrecto = true,
                        Mensaje = "Ok",
                        Resultado = respuesta
                    };
                }

                return new Respuesta
                {
                    EsCorrecto = false,
                    Mensaje = string.Format("La se encontro ningun usuario para la cuenta {0}.", CodigoMecanico)
                };
            }
        }
    }
}
