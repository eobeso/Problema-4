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
    public class BancoServicioClient
    {
        private string BASE_URL = "http://localhost:57789/ServicioBancos.svc";
        public List<Bancos> findAll()
        {
            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(BASE_URL + "/findall");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Bancos>>(json);

            }
            catch
            {
                return null;
            }
        }

        public bool create(Bancos oBancos)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Bancos));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, oBancos);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "/create", "POST", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool edit(Bancos oBancos)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Bancos));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, oBancos);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(BASE_URL + "/edit", "PUT", data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int CodigoBanco)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Bancos));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, CodigoBanco);
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
        public Bancos find(int CodigoBanco)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "/find/{0}", CodigoBanco);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Bancos>(json);
            }
            catch
            { return null; }
        }

    }
}