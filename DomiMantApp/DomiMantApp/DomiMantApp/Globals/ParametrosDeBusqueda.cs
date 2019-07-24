

namespace DomiMantApp.Repositorios
{
    using System;
    using System.Linq.Expressions;

    public class ParametrosDeBusqueda<T>
    {
        public Expression<Func<T, bool>> Where {get; set;}        
        public Func<T, object> OrdenarPor { get; set; }
        public Func<T, object> OrdenDesendientePor { get; set; }

        public void Criterio(Expression<Func<T, bool>> filter=null, Func<T, object> ordenarpor=null, Func<T, object> ordendesendientepor=null) {
            Where = filter;
            OrdenarPor = ordenarpor;
            OrdenDesendientePor = ordendesendientepor;
        }
    }

   
}