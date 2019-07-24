
namespace DomiMantApp.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepositorio<T>:IDisposable
    {
        void Agregar(T entidad);
        void Eliminar(T entidad);
        void Actualizar(T entidad);
        T ObtenerPorID(int id);
        IEnumerable<T> Buscar(Expression<Func<T, bool>> Donde = null, Func<T, object> OrdernarPor = null, Func<T, object> OrdenDesendientePor = null);
    }
}
