using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Demo08WS
{
    /// <summary>
    /// Summary description for MyWS
    /// </summary>
    [WebService(Namespace = "http://Elpepe.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWS : System.Web.Services.WebService {

        [WebMethod]
        public string HelloWorld() {
            return "Hello World";
        }

        [WebMethod]
        public int Suma(int x, int y) {
            return x + y;
        }

        [WebMethod]
        public Respuesta RegistraCliente(Cliente cliente)
        {
            return new Respuesta() { Codigo = 0, Mensaje = "Transaccion procesada", Tipo = 0 };
        }
    }
}
