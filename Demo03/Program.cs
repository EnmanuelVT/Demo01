using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo03.DataSet1TableAdapters;

namespace Demo03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tblClientesTableAdapter adapter = new tblClientesTableAdapter();
            SqlTransaction transaction = null;
            adapter.Connection.Open();
            try
            {
                transaction = adapter.Connection.BeginTransaction();
                Console.WriteLine("Tipo Doc");
                string tipodocumento = Console.ReadLine();
                Console.WriteLine("Doc");
                string documento = Console.ReadLine();
                string nombres, apellidos, sexo, fechanacimiento, nota;
                DataSet1.tblClientesDataTable dt = adapter.GetDataDoc(int.Parse(tipodocumento), documento);
                if (dt.Count == 0) {
                    Console.Write("Nombre: ");
                    nombres = Console.ReadLine();
                    Console.Write("Apellidos: ");
                    apellidos   = Console.ReadLine();
                    Console.Write("Fecha Nacimiento: ");
                    fechanacimiento = Console.ReadLine();
                    Console.Write("Sexo: ");
                    sexo = Console.ReadLine();
                    Console.Write("Nota: ");
                    nota = Console.ReadLine();
                }
                else
                {
                    nombres = dt[0]["Nombres"].ToString();
                    Console.WriteLine($"Nombres: {nombres}");
                    apellidos = dt[0]["Apellidos"].ToString();
                    Console.WriteLine($"Apellidos: {apellidos}");
                    sexo = dt[0]["Sexo"].ToString();
                    Console.WriteLine($"Sexo: {sexo}");
                    fechanacimiento = dt[0]["fechanacimiento"].ToString();
                    Console.WriteLine($"Fecha nacimiento: {fechanacimiento}");
                    Console.Write("Nota: ");
                    nota = Console.ReadLine();
                }

                adapter.Transaction = transaction; 
                adapter.ppUpsertCliente(int.Parse(tipodocumento), documento, nombres, apellidos, DateTime.Parse(fechanacimiento), int.Parse(sexo), nota);
                adapter.ppInsertVisita(int.Parse(tipodocumento), documento, nota, "CUMA");
            }
            catch (Exception err)
            {
                transaction.Rollback();
                Console.WriteLine(err.Message);
            }

            //tblVisitasTableAdapter visitasTableAdapter = new tblVisitasTableAdapter();
            //foreach (var item in visitasTableAdapter.GetDataByDoc(1, "1"))
            //{
            //    Console.WriteLine(item.Tipodocumento + "\t" + item.Documento + "\t" + item.FechaVisita);
            //}
            //Console.WriteLine(visitasTableAdapter.ppCantidadVisitasPorDoc(1,"d"));
            ///* Get data by localidad for each */
            //visitasTableAdapter.GetDataByDoc(1, "1");
            //visitasTableAdapter.ppInsertVisita(1, "1", "jfaksdljk", "CUMA");
            //tblClientesTableAdapter adapter = new tblClientesTableAdapter();
            //adapter.Insert(1, "fasjdkl", "PABLO", "d", DateTime.Now.AddDays(-15000), 2, DateTime.Now, 2, "2", 0);
            //adapter.ppUpsertCliente(1, "2350", "Francisco", "Abreu", DateTime.Now.AddDays(-10000), 1, "Vino Solo");
            //foreach (var item in adapter.GetData().Where(o => o.Sexo == 1).ToList())
            //{
            //    Console.WriteLine($"{item.Nombres} \t {item.Apellidos}");
            //}
        }
    }
}
