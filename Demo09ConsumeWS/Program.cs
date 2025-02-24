using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Demo09ConsumeWS
{
    class Program
    {
        static void Main(string[] args)
        {
            // while (true)
            // {
                SR.MyWSSoapClient client = new SR.MyWSSoapClient();
                Console.WriteLine(client.HelloWorld());
                Console.WriteLine(client.Suma(8000, 2000));
                Console.WriteLine();
                SR.Cliente cliente = new SR.Cliente();
                cliente.Id = 1;
                cliente.Nombres = "María";
                cliente.Apellidos = "Ortega";
                SR.Respuesta res = client.RegistraCliente(cliente);
                Console.WriteLine(res.Mensaje);
            // }
        }
    }
}
