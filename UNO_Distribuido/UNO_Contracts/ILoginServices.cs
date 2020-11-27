using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_DB;

namespace UNO_Contracts
{
    [ServiceContract(CallbackContract = typeof(ILoginServicesCallback))]
    public interface ILoginServices
    {
        [OperationContract(IsOneWay = true)]
        void Login(string username, string password); //Hay que cifrar las contraseñas
        [OperationContract]
        bool IsLogged(Player player);
    }
    
    public interface ILoginServicesCallback
    {
        [OperationContract]
        void LoginVerification(bool result);
    }
}