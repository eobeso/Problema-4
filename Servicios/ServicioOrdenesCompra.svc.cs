using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioOrdenesCompra" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioOrdenesCompra.svc o ServicioOrdenesCompra.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioOrdenesCompra : IServicioOrdenesCompra
    {
        public List<OrdenesPago> findAll()
        {
            List<OrdenesPago> lista = new List<OrdenesPago>();
            OrdenesPago obj = new OrdenesPago();
            string queryString = "select o.CodigoPago,o.Monto,case (o.Moneda) when 1  then 'Soles' when 2 then 'Dolares' end as Moneda_des,case (o.Estado) when 1 then 'Pendiente' when 2 then 'Cancelado' end as Estado_des,o.FechaPago,(select s.Nombre from Sucursales s where s.CodigoSucursales = o.CodigoSucursales) as Sucursales,o.Id_Cliente from OrdenesPago o";            
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
                        obj = new OrdenesPago();
                        obj.CodigoPago = (int)reader["CodigoPago"];
                        obj.Monto = (decimal)reader["Monto"];
                        obj.FechaPago = (DateTime)reader["FechaPago"];
                        obj.Moneda_des = (string)reader["Moneda_des"];
                        obj.Estado_des = (string)reader["Estado_des"];
                        obj.Sucursales = (string)reader["Sucursales"];
                        obj.Id_Cliente = (string)reader["Id_Cliente"];

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
    }
}
