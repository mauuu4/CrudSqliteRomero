namespace CrudSqliteRomero
{
    public class Moto
    {
        public int Id { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public int Anio { get; set; }
    }
}
