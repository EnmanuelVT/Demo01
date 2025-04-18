using Sales.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ClientUI
{
    public class PlaceOrderHandler(ILogger<PlaceOrderHandler> logger) :
        IHandleMessages<PlaceOrder>
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

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            logger.LogInformation("Received PlaceOrder, OrderId = {orderId}", message.OrderId);

            // This is normally where some business logic would occur

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId
            };
            return context.Publish(orderPlaced);
        }
    }
}
