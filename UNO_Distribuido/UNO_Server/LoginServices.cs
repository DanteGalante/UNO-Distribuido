using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_Contracts;
using UNO_DB;

namespace UNO_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LoginServices : ILoginServices
    {
        public void IsLogged(int idPlayer)
        {
            bool result = false;
            
            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    foreach (var j in db.Players)
                    {
                        if(j.idPlayer == idPlayer)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                //WIP
            }
            callback.IsLoggedResult(result);
        }

        public void Login(string username, string password)
        {
            bool result = false;
            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    foreach(var player in db.Players)
                    {
                        if(player.username == username && player.password == password)
                        {
                            result = true;

                            player.isLogged = true;
                        }
                    }
                }
                callback.LoginVerification(result);
            }
            catch
            {
                //WIP
            }
        }
        ILoginServicesCallback callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ILoginServicesCallback>();
            }
        }
    }
}
