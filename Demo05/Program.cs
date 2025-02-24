using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Demo05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDataEntities entities = new MyDataEntities();

            tblCliente tblCliente = new tblCliente()
            {
                Nombres = "Maria",
                Apellidos = "C",
                TipoDocumento = 1,
                Documento = "1",
                FechaNacimiento = DateTime.Parse("1-1-1"),
                FechaIngreso = DateTime.Now,
                Nota = "na",
                Sexo = 1,
            };
            entities.tblClientes.Add(tblCliente);
            entities.SaveChanges();

            foreach (var entity in entities.tblClientes.Where(j => j.Apellidos== "C"))
            {
                Console.WriteLine(entity.Nombres + "\t" + entity.Apellidos);
            }
            string tipodocumento, documento, nombres, apellidos, fechanacimiento, sexo, nota;
            Console.Write("Tipo doc: ");
            tipodocumento = Console.ReadLine();
            Console.Write("Doc: ");
            documento = Console.ReadLine();
            Console.Write("Nombre: ");
            nombres = Console.ReadLine();
            Console.Write("Apellidos: ");
            apellidos = Console.ReadLine();
            Console.Write("Fecha Nacimiento: ");
            fechanacimiento = Console.ReadLine();
            Console.Write("Sexo: ");
            sexo = Console.ReadLine();
            Console.Write("Nota: ");
            nota = Console.ReadLine();
            entities.ppInsertCliente(int.Parse(tipodocumento), documento, nombres, apellidos, DateTime.Parse(fechanacimiento), int.Parse(sexo), nota);
        }
    }
}
