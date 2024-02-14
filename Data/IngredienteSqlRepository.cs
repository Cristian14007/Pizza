using PizzaExample.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

namespace PizzaExample.Data
{

    public class IngredienteSqlRepository : IIngredientesRepository
    {

        private readonly string _connectionString;

        public IngredienteSqlRepository(string connectionString)
        {

            _connectionString = connectionString;
        }

        public  List<Ingrediente> GetAll()
        {
           List<Ingrediente> ingredientes  = new List<Ingrediente>();

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                var sqlString = "SELECT Id, Name, Origen FROM Ingredientes";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingrediente = new Ingrediente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Origen = reader["Origen"].ToString()
                        };
                    ingredientes.Add(ingrediente);
                    } 
                }
            }

            return ingredientes;
        }

        public void Add(Ingrediente ingrediente)
        {
            using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        var sqlString = "INSERT INTO Ingredientes (Id, Name, Origen) VALUES('@Id', '@Name', '@Origen')";
        var command = new SqlCommand(sqlString, connection);

        // Utilizamos parámetros para evitar la inyección de SQL
        command.Parameters.AddWithValue("@Id", ingrediente.Id);
        command.Parameters.AddWithValue("@Name", ingrediente.Name);
        command.Parameters.AddWithValue("@Origen", ingrediente.Origen);

    }
        }

        public Ingrediente Get(int id)
        {
            var ingrediente = new Ingrediente();

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                var sqlString = "SELECT Id, Name, Origen FROM Ingredientes WHERE Id=" + id;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ingrediente = new Ingrediente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Origen = reader["Origen"].ToString()
                        };
                    }
                }
            }

            return ingrediente;
        }

        public void Update(Ingrediente ingrediente)
{
    /* using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        var sqlString = "UPDATE Pizza SET Name=@Name, IsGlutenFree=@IsGlutenFree WHERE Id=@Id";
        var command = new SqlCommand(sqlString, connection);

        // Utilizamos parámetros para evitar la inyección de SQL
        command.Parameters.AddWithValue("@Name", pizza.Name);
        command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);
        command.Parameters.AddWithValue("@Id", pizza.Id);

        // Ejecutamos la consulta de actualización
        int rowsAffected = command.ExecuteNonQuery();

        // Puedes verificar rowsAffected para ver cuántas filas fueron afectadas
        if (rowsAffected > 0)
        {
            Console.WriteLine("La pizza fue actualizada exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pudo encontrar la pizza con el ID especificado.");
        }
    } */
}

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        var sqlString = "DELETE FROM Ingredientes WHERE Id=" + id;
        var command = new SqlCommand(sqlString, connection);

        command.ExecuteNonQuery();
    }
        }

        public void SaveChanges()
        {
            //DO NOTHING (BY NOW)
        }

    }

}