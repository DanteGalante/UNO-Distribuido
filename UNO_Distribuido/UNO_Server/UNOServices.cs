using BCrypt.Net;
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
using UNO_Server.Utilities;

namespace UNO_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UNOServices : ILoginServices, IPlayerManager
    {
        //Player manager methods


        public void AddNewPlayer(Player newPlayer)
        {
            Player playerAdded = null;
            bool response = false;
            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    playerAdded = db.Players.Add(newPlayer);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            if (playerAdded != null)
            {
                response = true;
            } else if (playerAdded == null)
            {
                response = false;
            }

            PlayerCallback.VerifyPlayerAddition(response);
        }

        public void DeletePlayer(Player player)
        {
            Player playerDeleted = null;
            bool response = false;
            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    playerDeleted = db.Players.Remove(player);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            if (playerDeleted != null)
            {
                response = true;
            }
            else if (playerDeleted == null)
            {
                response = false;
            }

            PlayerCallback.VerifyPlayerDeletion(response);
        }

        public void GetAllPlayers()
        {
            List<Player> players = null;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    players = db.Players.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            PlayerCallback.GetPlayersResponse(players);
        }

        public void ModifyPlayer(Player player, Player newPlayer)
        {
            bool result = false;
            Player playerSearched = null;

            playerSearched = SearchPlayer(player.username);

            playerSearched.username = newPlayer.username;
            playerSearched.password = newPlayer.password;
            playerSearched.name = newPlayer.name;
            playerSearched.lastnames = newPlayer.lastnames;
            playerSearched.avatarImage = newPlayer.avatarImage;

            using (UNODBEntities db = new UNODBEntities())
            {
                db.SaveChanges();
            }

            PlayerCallback.VerifyPlayerModification(result);
        }

        public Player SearchPlayer(string username)
        {
            Player playerSearched = null;

            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    playerSearched = db.Players.Where(a => a.username == username).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return playerSearched;
        }

        public void RegisterPlayer(Player newPlayer)
        {
            bool result = false;
            string token = "";

            if(!EmailAlreadyExist(newPlayer.email))
            {
                token = new DataManager().GenerateVerificationToken();

                newPlayer.verificationToken = token;

                new EmailVerification().SendEmail(newPlayer.email, token);
            }

            using(UNODBEntities db = new UNODBEntities())
            {
                db.Players.Add(newPlayer);
                db.SaveChanges();
            }

            PlayerCallback.VerifyPlayerRegistration(result);
        }

        public bool EmailAlreadyExist(string email)
        {
            bool result = false;
            Player player = null;

            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    player = db.Players.Where(a => a.email == email).FirstOrDefault();
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            if(player != null)
            {
                result = true;
            }

            return result;
        }
        [Obsolete]
        public bool SetPassword(Player player, string password)
        {
            DataManager dataManager = new DataManager();
            string hashedPassword = dataManager.EncryptPassword(password);

            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    player.password = hashedPassword;

                    db.SaveChanges();
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }

            return true;
        }

        //Login services methods------------------------------------------------------------------------------------------------------------------------


        private ResourceManager resourceManager = new ResourceManager("ExceptionMessages.es-MX", Assembly.GetExecutingAssembly());
        public bool IsLogged(Player player)
        {
            bool result = false;

            try
            {
                result = player.isLogged;
            }
            catch(Exception e)
            {
                throw e;
            }

            return result;
        }
        /*
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

            LoginCallback.LoginVerification(result);
        }
        */

        public void Login(string username, string password)
        {
            bool result = false;
            Player player = null;
            DataManager dataManager = new DataManager();

            try
            {
                using(UNODBEntities db = new UNODBEntities())
                {
                    try
                    {
                        player = db.Players.Where(a => a.username == username).FirstOrDefault();
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }

                    if (player != null && dataManager.VerifyPassword(password, player.password))
                    {
                        if(!IsLogged(player))
                        {
                            if(player.isVerified == true)
                            {
                                result = true;

                                player.isLogged = true;

                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            result = false;
                            throw new PlayerAlreadyLoggedException(resourceManager.GetString("PlayerAlreadyLogged"));
                        }
                    }
                    else if (player == null)
                    {
                        result = false;
                    }
                }
            }
            catch(Exception e)
            {
                throw e;
            }

            LoginCallback.LoginVerification(result);
        }

        ILoginServicesCallback LoginCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ILoginServicesCallback>();
            }
        }

        IPlayerManagerCallback PlayerCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IPlayerManagerCallback>();
            }
        }
        
    }



}
