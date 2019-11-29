using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Models
{
    public class OrdenesPagoServicioClient
    {
        private string BASE_URL = "http://localhost:57789/ServicioOrdenesCompra.svc";
        public List<OrdenesPago> findAll()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<OrdenesPago>>(json);

            }
            catch
            {
                return null;
            }
        }
    }
}