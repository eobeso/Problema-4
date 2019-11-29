using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace ProyectoWeb.Models
{
    public class SucursalesServicioClient
    {
        private string BASE_URL = "http://localhost:57789/ServicioSucursales.svc";
        public List<Sucursales> findAll()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Sucursales>>(json);

            }
            catch
            {
                return null;
            }
        }

        public List<ListaBanco> findAllBanco()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/findallBanco");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<ListaBanco>>(json);

            }
            catch
            {
                return null;
            }
        }

        public bool create(Sucursales oSucursales)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Sucursales));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, oSucursales);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "/create", "POST", data);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool delete(int CodigoSucursal)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Sucursales));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, CodigoSucursal);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "/delete", "DELETE", data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}