/* aspnet_regiis -pef "connectionStrings" */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SqlTransaction transaction = null;
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
                sql.Open();
                Console.WriteLine(sql.State);
                SqlCommand cmd = sql.CreateCommand();
                Console.Write("Tipo Documento: ");
                string tipodocumento = Console.ReadLine();
                Console.Write("Documento: ");
                string documento = Console.ReadLine();
                // TODO: Consulta
                cmd.CommandText = "ppGetClienteById";
                cmd.Parameters.AddWithValue("@tipodocumento", tipodocumento);
                cmd.Parameters.AddWithValue("@doc", tipodocumento);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                string nombre, apellidos, fechanacimiento, sexo, nota;
                if (dr.Read())
                {
                    nombre = $"{dr["Nombres"]}";
                    Console.Write($"Nombres: {nombre}");
                    apellidos = $"{dr["Apellidos"]}";
                    Console.Write($"apellidos: {apellidos}");
                    fechanacimiento = $"{ dr["Fechanacimiento"] }";
                    Console.Write($"Fecha Nacimiento: {fechanacimiento} ");
                    sexo = $"{ dr["sexo"] }";
                    Console.Write($"Sexo: {sexo}");
                    nota = $"{dr["nota"]}";
                    Console.Write($"Nota: {nota} ");

                }
                else
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    Console.Write("Apellidos: ");
                    apellidos = Console.ReadLine();
                    Console.Write("Fecha Nacimiento: ");
                    fechanacimiento = Console.ReadLine();
                    Console.Write("Sexo: ");
                    sexo = Console.ReadLine();
                    Console.Write("Nota: ");
                    nota = Console.ReadLine();

                }
                cmd.Parameters.Clear();
                dr.Close();
                dr = null;

                /* cmd.CommandText = "insert into tblClientes(TipoDocumento, documento, nombres, apellidos, fechanacimiento, sexo, nota)" +
                " values (" + tipodocumento + ", '" + documento + "', '" + nombre + "', '" + apellidos + "', '" + fechanacimiento + "', " + sexo + ", '" + nota + "')"; */
                /*cmd.CommandText = "insert into tblClientes(TipoDocumento, documento, nombres, apellidos, fechanacimiento, sexo, nota)" +
                " values (@tipodocumento,@documento,@nombre,@apellidos,@fechanacimiento,@sexo,@nota)";*/
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Apellidos: ");
                apellidos = Console.ReadLine();
                Console.Write("Fecha Nacimiento: ");
                fechanacimiento = Console.ReadLine();
                Console.Write("Sexo: ");
                sexo = Console.ReadLine();
                Console.Write("Nota: ");
                nota = Console.ReadLine();
                cmd.CommandText = "ppUpsertCliente";
                cmd.Parameters.AddWithValue("@tipodocumento", tipodocumento);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                cmd.Parameters.AddWithValue("@nota", nota);

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
