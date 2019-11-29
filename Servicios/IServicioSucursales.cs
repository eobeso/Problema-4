using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioSucursales" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSucursales
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findall", ResponseFormat = WebMessageFormat.Json)]
        List<Sucursales> findAll();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findallBanco", ResponseFormat = WebMessageFormat.Json)]
        List<ListaBanco> findAllBanco();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        bool create(Sucursales oSucursales);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json)]
        bool delete(int CodigoSucursal);
    }
}
