using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SqlTransaction transaction = null;
                string connectionString = ConfigurationManager.ConnectionStrings["CN"]?.ConnectionString;
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                Console.WriteLine(sql.State);
                SqlCommand cmd = sql.CreateCommand();
                Console.Write("Tipo Documento: ");
                string tipodocumento = Console.ReadLine();
                Console.Write("Documento: ");
                string documento = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Apellidos: ");
                string apellidos = Console.ReadLine();
                Console.Write("Fecha Nacimiento: ");
                string fechanacimiento = Console.ReadLine();
                Console.Write("Sexo: ");
                string sexo = Console.ReadLine();
                Console.Write("Nota: ");
                string nota = Console.ReadLine();
                /* cmd.CommandText = "insert into tblClientes(TipoDocumento, documento, nombres, apellidos, fechanacimiento, sexo, nota)" +
                " values (" + tipodocumento + ", '" + documento + "', '" + nombre + "', '" + apellidos + "', '" + fechanacimiento + "', " + sexo + ", '" + nota + "')"; */
                /*cmd.CommandText = "insert into tblClientes(TipoDocumento, documento, nombres, apellidos, fechanacimiento, sexo, nota)" +
                " values (@tipodocumento,@documento,@nombre,@apellidos,@fechanacimiento,@sexo,@nota)";*/
                cmd.CommandText = "ppUpsertCliente";
                cmd.Parameters.AddWithValue("@tipodocumento", tipodocumento);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                cmd.Parameters.AddWithValue("@nota", nota);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    transaction = sql.BeginTransaction();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "ppInsertVisita";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@tipodocumento", tipodocumento);
                    cmd.Parameters.AddWithValue("@documento", documento);
                    cmd.Parameters.AddWithValue("@nota", nota);
                    cmd.Parameters.AddWithValue("@localidad", ConfigurationManager.AppSettings["LOCALIDAD"]);
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    Console.WriteLine(err.Message);
                }
            }
        }
    }
}
