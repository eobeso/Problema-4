using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSucursales" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioSucursales.svc o ServicioSucursales.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioSucursales : IServicioSucursales
    {
        public List<Sucursales> findAll()
        {
            List<Sucursales> lista = new List<Sucursales>();
            Sucursales obj = new Sucursales();
            string queryString = "select s.CodigoSucursales,s.Nombre,s.Direccion,s.FechaRegistro,(select b.Nombre from Banco b where b.CodigoBanco = s.CodigoBanco) as Banco from Sucursales s";
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bancos.mdf" + ";Integrated Security = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        obj = new Sucursales();
                        obj.CodigoSucursales = (int)reader["CodigoSucursales"];
                        obj.Nombre = (string)reader["Nombre"];
                        obj.Direccion = (string)reader["Direccion"];
                        obj.FechaRegistro = (DateTime)reader["FechaRegistro"];
                        obj.Banco = (string)reader["Banco"];
                        lista.Add(obj);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return lista;
            }
        }
        public List<ListaBanco> findAllBanco()
        {
            List<ListaBanco> lista = new List<ListaBanco>();
            ListaBanco obj = new ListaBanco();
            string queryString = "select CodigoBanco,Nombre from Banco";
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bancos.mdf" + ";Integrated Security = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        obj = new ListaBanco();
                        obj.CodigoBanco = (int)reader["CodigoBanco"];
                        obj.Nombre = (string)reader["Nombre"];
                        lista.Add(obj);
                    }
                }
                finally
                {
                    reader.Close();
                }
                return lista;
            }
        }
        public bool create(Sucursales oSucursales)
        {
            try
            {
                string queryString = "insert into Sucursales (Nombre,Direccion,FechaRegistro,CodigoBanco) values('" + oSucursales.Nombre + "','" + oSucursales.Direccion + "',GETDATE()," + oSucursales.CodBanco + ")";
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bancos.mdf" + ";Integrated Security = True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool delete(int CodigoSucursal)
        {
            try
            {
                string queryString = "delete Sucursales where CodigoSucursales = " + CodigoSucursal;
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Bancos.mdf" + ";Integrated Security = True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
