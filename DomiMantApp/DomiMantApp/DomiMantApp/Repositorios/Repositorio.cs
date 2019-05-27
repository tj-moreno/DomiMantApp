

namespace DomiMantApp.Repositorios
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DomiMantApp.Modelos;
    using SQLite;

    public class Repositorio<T> : IRepositorio<T> where T : ModeloBase, new()
    {
        public string DBpaht;
        public Repositorio(string dbpaht)
        {
            DBpaht = dbpaht;

            using (var _cn = new SQLiteConnection(this.DBpaht))
            {
                _cn.CreateTable<T>();
            }
        }

        public void Actualizar(T entidad)
        {
            using (var _cn = new SQLiteConnection(DBpaht))
            {
                var db = _cn.Table<T>().FirstOrDefault(t => t.ID.Equals(entidad.ID));

                if (db!=null)
                {
                    _cn.Update(entidad);
                }
            }
        }

        public void Agregar(T entidad)
        {
            using (var _cn= new SQLiteConnection(DBpaht))
            {
                _cn.Insert(entidad);
            }
        }

        public IEnumerable<T> BuscarPro(ParametrosDeBusqueda<T> parametros)
        {
            Expression<Func<T, bool>> wheretrue = Xamarin => true;
            var criterio = (parametros.Where == null) ? wheretrue : parametros.Where;
            using (var _cn= new SQLiteConnection(DBpaht))
            {
                return _cn.Table<T>().Where(criterio).ToList();
            }
        }

        public void Eliminar(T entidad)
        {
            using (var _cn= new SQLiteConnection(DBpaht))
            {
                _cn.Delete(entidad.ID);
            }
        }

        public T ObtenerPorID(int id)
        {
            using (var _cn= new SQLiteConnection(DBpaht))
            {
                var view = _cn.Table<T>().FirstOrDefault(t => t.ID.Equals(id));
                if (view!=null)
                {
                    return view;
                }

                return null;
            }
        }
    }
}
