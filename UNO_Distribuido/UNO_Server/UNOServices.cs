using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.ServiceModel;
using UNO_Contracts;
using UNO_DB;
using UNO_Server.Utilities;

namespace UNO_Server
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class UNOServices : ILoginServices, IPlayerManager
    {
        //Player manager methods
        public bool AddNewPlayer(Player newPlayer)
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
            }
            else if (playerAdded == null)
            {
                response = false;
            }

            return response;
        }

        public bool DeletePlayer(Player player)
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

            return response;
        }

        public List<Player> GetAllPlayers()
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
            return players;
        }

        public bool ModifyPlayer(Player player, Player newPlayer)
        {
            bool result = false;
            Player playerSearched = null;

            playerSearched = SearchPlayer(player.username);

            using (UNODBEntities db = new UNODBEntities())
            {
                playerSearched.username = newPlayer.username;
                playerSearched.password = newPlayer.password;
                playerSearched.verificationToken = newPlayer.verificationToken;
                playerSearched.name = newPlayer.name;
                playerSearched.lastnames = newPlayer.lastnames;
                playerSearched.avatarImage = newPlayer.avatarImage;

                db.SaveChanges();
                result = true;
            }

            return result;
        }

        public Player SearchPlayer(string username)
        {
            Player playerSearched = null;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    playerSearched = db.Players.SingleOrDefault(a => a.username == username);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return playerSearched;
        }

        public int RegisterPlayer(Player newPlayer)
        {
            int result = 0;
            string token = "";
            const int PLAYER_REGISTERED = 1, PLAYER_ALREADY_REGISTERED = 2, UNVERIFIED_PLAYER = 3, UNAVAILABLE_EMAIL = 4, UNAVAILABLE_USERNAME = 5;
            const int PLAYER_DOESNT_EXIST = 1, REPEATED_EMAIL = 2, REPEATED_USERNAME = 3, PLAYER_REPEATED = 4;
            
            try
            {
                int playerExistence = PlayerAlreadyExist(newPlayer.username, newPlayer.email);
                if (playerExistence == PLAYER_DOESNT_EXIST)
                {
                    token = new DataManager().GenerateVerificationToken();

                    newPlayer.verificationToken = token;
                    newPlayer.password = new DataManager().EncryptPassword(newPlayer.password);

                    new EmailVerification().SendEmail(newPlayer.email, token);

                    if (AddNewPlayer(newPlayer))
                    {
                        result = PLAYER_REGISTERED;
                    }
                }
                else if (playerExistence == PLAYER_REPEATED)
                {
                    if (CheckPlayerVerification(newPlayer))
                    {
                        result = PLAYER_ALREADY_REGISTERED;
                    }
                    else
                    {
                        result = UNVERIFIED_PLAYER;

                        token = new DataManager().GenerateVerificationToken();

                        new EmailVerification().SendEmail(newPlayer.email, token);

                        ChangePlayerToken(newPlayer.username, token);
                    }
                }
                else if (playerExistence == REPEATED_EMAIL)
                {
                    result = UNAVAILABLE_EMAIL;
                }
                else if (playerExistence == REPEATED_USERNAME)
                {
                    result = UNAVAILABLE_USERNAME;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        public int PlayerAlreadyExist(string username, string email)
        {
            const int PLAYER_DOESNT_EXIST = 1, REPEATED_EMAIL = 2, REPEATED_USERNAME = 3, PLAYER_REPEATED = 4;
            int result = PLAYER_DOESNT_EXIST;
            Player player = null;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    player = db.Players.SingleOrDefault(a => a.email == email || a.username == username);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            if (player.email == email && player.username == username)
            {
                result = PLAYER_REPEATED;
            }else if (player.username == username)
            {
                result = REPEATED_USERNAME;
            }else if (player.email == email)
            {
                result = REPEATED_EMAIL;
            }

            return result;
        }
        
        public bool CheckPlayerVerification(Player player)
        {
            bool result = false;

            result = player.isVerified;

            return result;
        }
        /*
        public bool VerifyPlayer(string username, string token)
        {
            bool result = false;
            Player playerToVerify = null;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    playerToVerify = SearchPlayer(username);
                    if (playerToVerify != null)
                    {
                        if(playerToVerify.verificationToken == token)
                        {
                            playerToVerify.isVerified = true;
                            result = true;
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        */
        public bool VerifyPlayer(string username, string token)
        {
            bool result = false;
            Player playerToVerify = null;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    playerToVerify = db.Players.SingleOrDefault(a => a.username == username);
                    if (playerToVerify != null)
                    {
                        if (playerToVerify.verificationToken == token)
                        {
                            playerToVerify.isVerified = true;
                            result = true;
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
        public bool ChangePlayerToken(string username, string newToken)
        {
            bool result = false;
            /*
            using (UNODBEntities db = new UNODBEntities())
            {
                Player player = SearchPlayer(username);

                Console.WriteLine("Old verification token: " + player.verificationToken);

                player.verificationToken = newToken;

                Console.WriteLine("New verification token: " + player.verificationToken);

                db.SaveChanges();

                result = true;
            }
            */

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    Player player = db.Players.SingleOrDefault(a => a.username == username);
                    
                    Console.WriteLine("Old verification token: " + player.verificationToken);

                    player.verificationToken = newToken;

                    Console.WriteLine("New verification token: " + player.verificationToken);

                    db.SaveChanges();

                    result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return result;
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
            catch (Exception e)
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

        public int Login(string username, string password)
        {
            int result = 0;
            Player player = null;
            DataManager dataManager = new DataManager();
            const int SUCCEDED = 1, INCORRECT_DATA = 2, PLAYER_ALREADY_LOGGED = 3, PLAYER_WITHOUT_VERIFICATION = 4;

            try
            {
                using (UNODBEntities db = new UNODBEntities())
                {
                    try
                    {
                        player = db.Players.Where(a => a.username == username).FirstOrDefault();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    if(player != null && dataManager.VerifyPassword(password, player.password))
                    {
                        if(!IsLogged(player))
                        {
                            if(CheckPlayerVerification(player))
                            {
                                result = SUCCEDED;

                                player.isLogged = true;

                                db.SaveChanges();
                            }
                            else
                            {
                                result = PLAYER_WITHOUT_VERIFICATION;
                            }
                        }
                        else
                        {
                            result = PLAYER_ALREADY_LOGGED;
                        }
                    }
                    else
                    {
                        result = INCORRECT_DATA;
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
    }
}
