using PizzaExample.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;

namespace PizzaExample.Data
{

    public class PizzaSqlRepository : IPizzaRepository
    {

        private readonly string _connectionString;

        public PizzaSqlRepository(string connectionString)
        {

            _connectionString = connectionString;
        }

        public  List<Pizza> GetAll()
        {
           List<Pizza> pizzas  = new List<Pizza>();

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                var sqlString = "SELECT Id, Name, IsGlutenFree FROM Pizza";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pizza = new Pizza
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            IsGlutenFree = Convert.ToBoolean(reader["IsGlutenFree"])
                        };
                    pizzas.Add(pizza);
                    } 
                }
            }

            return pizzas;
        }

        public void Add(Pizza pizza)
        {
            using (var connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        var sqlString = "INSERT INTO Pizza (Name, IsGlutenFree) VALUES('@Name', @IsGlutenFree)";
        var command = new SqlCommand(sqlString, connection);

        // Utilizamos parámetros para evitar la inyección de SQL
        command.Parameters.AddWithValue("@Name", pizza.Name);
        command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);

    }
        }

        public Pizza Get(int id)
        {
            var pizza = new Pizza();

            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                var sqlString = "SELECT Id, Name, IsGlutenFree FROM Pizza WHERE Id=" + id;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizza = new Pizza
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            IsGlutenFree = Convert.ToBoolean(reader["IsGlutenFree"])
                        };
                    }
                }
            }

            return pizza;
        }

        public void Update(Pizza pizza)
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

        var sqlString = "DELETE FROM Pizza WHERE Id=" + id;
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