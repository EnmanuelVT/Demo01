using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo21WebAPI.Models;

namespace Demo21WebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        public ClienteController() { }
        public Cliente Get(int ID)
        {
            return new Cliente() { Id = 1, Nombres = "maria", Apellidos = "Del carmen" };
        }
    }
}
