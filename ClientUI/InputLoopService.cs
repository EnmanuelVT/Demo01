using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Messages;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace ClientUI
{
    public class InputLoopService(IMessageSession messageSession) : BackgroundService

{
    private void InsertOrder(PlaceOrder order)
    {
        string connectionStrings = System.Configuration.ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        var sql = new SqlConnection(connectionStrings);
        sql.Open();
        SqlCommand cmd = sql.CreateCommand();
        cmd.CommandText = $"INSERT INTO Orders(OrderId, Descripcion, Precio, fecha, Estado) VALUES " +
                $"({order.OrderId}, {order.Descripcion}, {order.Precio}, {order.FechaNacimiento}, {order.Estado})";
            cmd.ExecuteNonQuery();
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

                    var command = new PlaceOrder
                    {
                        OrderId = Guid.NewGuid().ToString(),
                        Descripcion = desc,
                        Precio = precio,
                        FechaNacimiento = fechanacimiento
                    };

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
