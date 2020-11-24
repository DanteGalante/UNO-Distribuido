using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UNO_Contracts
{
    [ServiceContract(CallbackContract = typeof(ILoginServicesCallback))]
    public interface ILoginServices
    {

        [OperationContract(IsOneWay = true)]
        void Login(string username, string password); //Hay que cifrar las contraseñas
        [OperationContract]
        void IsLogged(string username, string password);
    }
    
    public interface ILoginServicesCallback
    {
        [OperationContract]
        void LoginVerification(bool result);
        [OperationContract]
        void IsLoggedResult(bool result);
    }
}