using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioBancos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioBancos.svc o ServicioBancos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioBancos : IServicioBancos
    {
        public List<Bancos> findAll()
        {
            List<Bancos> lista= new List<Bancos>();
            Bancos obj = new Bancos();
            string queryString = "select * from Banco";
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
                        obj = new Bancos();
                        obj.CodigoBanco = (int)reader["CodigoBanco"];
                        obj.Nombre = (string)reader["Nombre"];
                        obj.Direccion = (string)reader["Direccion"];
                        obj.FechaRegistro = (DateTime)reader["FechaRegistro"];
                        lista.Add(obj);
                        //Console.WriteLine(String.Format("{0}, {1}",
                        //reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                return lista;
            }
        }
        public bool create(Bancos oBancos)
        {
            try
            {
                string queryString = "insert into Banco (Nombre,Direccion,FechaRegistro) values('" + oBancos.Nombre + "','" +oBancos.Direccion + "',GETDATE())";
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
            catch (Exception ex) {
                return false;
            }
        }
        public bool edit(Bancos oBancos)
        {
            try
            {
                string queryString = "update Banco set Nombre ='" + oBancos.Nombre + "',Direccion ='" + oBancos.Direccion + "' where CodigoBanco = " + oBancos.CodigoBanco;
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
        public bool delete(int CodigoBanco)
        {
            try
            {
                string queryString = "delete Banco where CodigoBanco = " + CodigoBanco;
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
        public Bancos find(string CodigoBanco)
        {
            Bancos obj = new Bancos();
            string queryString = "select * from Banco where CodigoBanco = " + CodigoBanco;
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
                        obj = new Bancos();
                        obj.CodigoBanco = (int)reader["CodigoBanco"];
                        obj.Nombre = (string)reader["Nombre"];
                        obj.Direccion = (string)reader["Direccion"];
                        obj.FechaRegistro = (DateTime)reader["FechaRegistro"];
                    }
                }
                finally
                {
                    reader.Close();
                }
                return obj;
            }
        }
    }
}
