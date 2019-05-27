
namespace DomiMantApp.Repositorios
{
    using System.Collections.Generic;
    public interface IRepositorio<T>
    {
        void Agregar(T entidad);
        void Eliminar(T entidad);
        void Actualizar(T entidad);
        T ObtenerPorID(int id);
        IEnumerable<T> BuscarPro(ParametrosDeBusqueda<T> parametros);
    }
}
