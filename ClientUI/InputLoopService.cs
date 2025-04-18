using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Messages;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace ClientUI
{
    public class InputLoopService(IMessageSession messageSession) : BackgroundService

    {
        private void InsertOrder(PlaceOrder order)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

                using (var sql = new SqlConnection(connectionString))
                {
                    sql.Open();

                    using (var cmd = sql.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Orders (OrderId, Descripcion, Precio, fecha, Estado) " +
                                          "VALUES (@OrderId, @Descripcion, @Precio, @FechaNacimiento, @Estado)";

                        cmd.Parameters.AddWithValue("@OrderId", order.OrderId);
                        cmd.Parameters.AddWithValue("@Descripcion", order.Descripcion);
                        cmd.Parameters.AddWithValue("@Precio", order.Precio);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", order.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Estado", order.Estado);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting order: {ex.Message}");
                throw;
            }
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.WriteLine("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        // Instantiate the command
                        Console.Write("Inserte Descripcion: ");
                        string desc = Console.ReadLine();
                        Console.Write("Inserte Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Inserte Fecha Nacimiento: ");
                        DateTime fechanacimiento = DateTime.Parse(Console.ReadLine());
                        Console.Write("Inserte Estado (int): ");
                        int estado = int.Parse(Console.ReadLine());

                        var command = new PlaceOrder
                        {
                            OrderId = Guid.NewGuid().ToString(),
                            Descripcion = desc,
                            Precio = precio,
                            FechaNacimiento = fechanacimiento,
                            Estado = estado
                        };

                        InsertOrder(command);

                        // Send the command
                        Console.WriteLine($"PlaceOrder sent, OrderId = {command.OrderId}");
                        await messageSession.Send(command, stoppingToken);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        Console.WriteLine("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}
