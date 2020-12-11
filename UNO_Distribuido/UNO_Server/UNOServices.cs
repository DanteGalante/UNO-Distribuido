using GameExceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_Contracts;
using UNO_DB;

namespace UNO_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UNOServices : ILoginServices
    {
        private ResourceManager resourceManager = new ResourceManager("ExceptionMessages.es-MX", Assembly.GetExecutingAssembly());
        public bool IsLogged(Player player)
        {
            bool result = false;

            try
            {   
                result = player.isLogged.Value;
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return result;
        }

        public void Login(string username, string password)
        {
            bool result = false;
            Player player = null;

            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    try
                    {
                        player = db.Players.Where(a => a.username == username && a.password == password).FirstOrDefault();
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                    
                    if(player != null)
                    {
                        if(!IsLogged(player))
                        {
                            result = true;

                            player.isLogged = true;

                            db.SaveChanges();
                        }
                        else
                        {
                            result = false;
                            throw new PlayerAlreadyLoggedException(resourceManager.GetString("PlayerAlreadyLogged"));                            
                        }
                    }else if(player == null)
                    {
                        result = false;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            Callback.LoginVerification(result);
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
