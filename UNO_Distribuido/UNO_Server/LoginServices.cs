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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LoginServices : ILoginServices
    {
        //private readonly ConcurrentDictionary<string, ILoginServicesCallback> collection = new ConcurrentDictionary<string, ILoginServicesCallback>();
        public void IsLogged(string username, string password)
        {
            bool result = false;
            Player player = null;
            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    player = db.Players.Where(a => a.username == username && a.password == password && a.isLogged == true).First();

                    if (player != null)
                    {
                        result = true;
                    }
                    else if (player == null)
                    {
                        result = false;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            /*try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    foreach (var player in db.Players)
                    {
                        if (player.username == username)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                //WIP
            }*/
            Callback.IsLoggedResult(result);
        }

        public void Login(string username, string password)
        {
            bool result = false;
            Player player = null;
            
            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    try
                    {
                        player = db.Players.Where(a => a.username == username && a.password == password).First();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Error: no se encontraron jugadores con estos " + e);
                    }
                    

                    if (player != null)
                    {
                        result = true;

                        player.isLogged = true;

                        db.SaveChanges();

                        Console.WriteLine($"Jugador {player.username} acaba de conectarse" );
                    }else if (player == null)
                    {
                        result = false;
                    }
                    /*foreach (var player in db.Players)
                    {
                        Console.WriteLine(player.name);
                        if (player.username == username && player.password == password)
                        {
                            Console.WriteLine(player.idPlayer + " " + player.name);

                            result = true;

                            player.isLogged = true;

                            db.SaveChanges();
                        }
                    }*/
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Excepcion \n" + e.Message + "\n" + e.Source + "\n" + e.TargetSite + "\n\n" + e);
                //throw e;
            }
            Console.WriteLine(result);
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
