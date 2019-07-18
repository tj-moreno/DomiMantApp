

using SQLite;

namespace DomiMantApp.Modelos
{
    public abstract class ModeloBase
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int ID { get; set; }
    }
}
