using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioBancos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioBancos
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "findall", ResponseFormat = WebMessageFormat.Json)]
        List<Bancos> findAll();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "create", ResponseFormat = WebMessageFormat.Json)]
        bool create(Bancos oBancos);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "edit", ResponseFormat = WebMessageFormat.Json)]
        bool edit(Bancos oBancos);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "delete", ResponseFormat = WebMessageFormat.Json)]
        bool delete(int CodigoBanco);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "find/{CodigoBanco}", ResponseFormat = WebMessageFormat.Json)]
        Bancos find(string CodigoBanco);
    }
}
