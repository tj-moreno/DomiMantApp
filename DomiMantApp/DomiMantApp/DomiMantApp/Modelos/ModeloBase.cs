
namespace DomiMantApp.Modelos
{
    using SQLite;

    public abstract class ModeloBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
