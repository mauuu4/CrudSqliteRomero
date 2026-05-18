using Dapper;
using Microsoft.Data.Sqlite;

namespace CrudSqliteRomero
{
    public class Motos
    {
        private string connectionString;
        private SqliteConnection connection;

        public Motos()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "motos.db");
            connectionString = $"Data Source={dbPath};";
            connection = new SqliteConnection(connectionString);
            connection.Open();

            connection.Execute(@"
                CREATE TABLE IF NOT EXISTS Motos (
                    Id INTEGER PRIMARY KEY,
                    Marca TEXT NOT NULL,
                    Modelo TEXT NOT NULL,
                    Anio INTEGER NOT NULL )"
                );
        }

        public Moto Create(int id, string marca, string modelo, int anio)
        {
            if (Exists(id))
                throw new Exception($"Ya existe una moto con Id {id}. Usa otro Id o actualiza la existente.");

            var nuevaMoto = new Moto
            {
                Id = id,
                Marca = marca,
                Modelo = modelo,
                Anio = anio
            };

            var recordsAfected = connection.Execute(
                "INSERT INTO Motos (Id, Marca, Modelo, Anio) " +
                "VALUES (@Id, @Marca, @Modelo, @Anio)",
                nuevaMoto);

            if (recordsAfected == 0)
                throw new Exception("No se pudo insertar la moto en la base de datos.");
            else
                return nuevaMoto;
        }

        private bool Exists(int id)
        {
            var count = connection.ExecuteScalar<int>(
                "SELECT COUNT(1) FROM Motos WHERE Id = @Id",
                new { Id = id });

            return count > 0;
        }

        public Moto? ReadById(int id)
        {
            var data = connection.Query<Moto>(
                "SELECT * FROM Motos WHERE Id = @IdMoto",
                new { IdMoto = id })
                .ToList();

            if (data.Count == 0)
                return null;
            else
                return data[0];
        }

        public List<Moto> ReadAll()
        {
            var data = connection.Query<Moto>("SELECT * FROM Motos").ToList();
            return data;
        }

        public void Update(int id, string marca, string modelo, int anio)
        {
            var recordsAffected = connection.Execute(
                "UPDATE Motos SET Marca = @Marca, Modelo = @Modelo, Anio = @Anio " +
                "WHERE Id = @Id",
                new { Id = id, Marca = marca, Modelo = modelo, Anio = anio });

            if (recordsAffected == 0)
                throw new Exception("No se pudo actualizar la moto en la base de datos.");
        }

        public void Delete(int id)
        {
            var recordsAffected = connection.Execute(
                "DELETE FROM Motos WHERE Id = @IdMoto",
                new { IdMoto = id });

            if (recordsAffected == 0)
                throw new Exception($"No se pudo eliminar la moto con Id {id} de la base de datos.");
        }
    }
}
