using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_Contracts;
using UNO_DB;

namespace UNO_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class LoginServices : ILoginServices
    {
        private readonly ConcurrentDictionary<string, ILoginServicesCallback> collection = new ConcurrentDictionary<string, ILoginServicesCallback>();
        public void IsLogged(int idPlayer)
        {
            bool result = false;
            
            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    foreach (var player in db.Players)
                    {
                        if(player.idPlayer == idPlayer)
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
            Callback.IsLoggedResult(result);
        }

        public void Login(string username, string password)
        {
            bool result = false;
            try
            {
                
                using (UNODBEntities db = new UNODBEntities())
                {
                    foreach (var player in db.Players)
                    {
                        Console.WriteLine("Dentro de login " + player.name);
                        if (player.username == username && player.password == password)
                        {
                            Console.WriteLine(player.idPlayer + " " + player.name);

                            result = true;

                            player.isLogged = true;
                        }
                    }
                }
                Callback.LoginVerification(result);
            }
            catch(Exception e)
            {
                Console.WriteLine("Excepcion \n" + e.Message + "\n" + e.Source + "\n" + e.TargetSite + "\n\n" + e);
            }
        }

        ILoginServicesCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ILoginServicesCallback>();
            }
        }
        
    }
}
