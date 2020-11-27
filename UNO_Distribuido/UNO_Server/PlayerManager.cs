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
    class PlayerManager : IPlayerManager
    {
        public void AddPlayer(Player newPlayer)
        {
            bool result = false;

            using(UNODBEntities db = new UNODBEntities())
            {
                db.Players.Add(newPlayer);
            }

            Callback.AddPlayerResponse(result);
        }

        public void DeletePlayer(Player player)
        {
            bool result = false;

            using(UNODBEntities db = new UNODBEntities())
            {
                db.Players.Remove(player);
            }

            Callback.DeletePlayerResponse(result);
        }

        public void GetPlayers()
        {
            List<Player> playersList = null;

            using(UNODBEntities db = new UNODBEntities())
            {
                foreach(var player in db.Players)
                {
                    playersList.Add(player);
                }
            }

            Callback.GetPlayersResponse(playersList);
        }

        public void ModifyPlayer(Player player, Player newPlayer)
        {
            player.idPlayer = newPlayer.idPlayer;
            player.username = newPlayer.username;
            player.name = newPlayer.name;
            player.lastnames = newPlayer.lastnames;
            player.password = newPlayer.password;
            player.isBanned = newPlayer.isBanned;
            player.isLogged = newPlayer.isLogged;
            player.avatarImage = newPlayer.avatarImage;
        }

        public Player SearchPlayer(string username)
        {
            throw new NotImplementedException();
        }
        
        IPlayerManagerCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IPlayerManagerCallback>();
            }
        }
    }
}
