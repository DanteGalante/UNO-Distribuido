using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_DB;

namespace UNO_Contracts
{
    [ServiceContract]
    public interface ILoginServices
    {
        [OperationContract]
        int Login(string username, string password); //Hay que cifrar las contraseñas
        [OperationContract]
        bool IsLogged(Player player);
    }
}