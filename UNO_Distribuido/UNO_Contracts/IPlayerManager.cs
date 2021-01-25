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
    public interface IPlayerManager
    {
        [OperationContract]
        Player SearchPlayer(string username);
        [OperationContract]
        int PlayerAlreadyExist(string username, string email);
        [OperationContract]
        bool AddNewPlayer(Player newPlayer);
        [OperationContract]
        bool DeletePlayer(Player player);
        [OperationContract]
        bool ModifyPlayer(Player player, Player newPlayer);
        [OperationContract]
        List<Player> GetAllPlayers();
        [OperationContract]
        int RegisterPlayer(Player newPlayer);
        [OperationContract]
        bool CheckPlayerVerification(Player player);
        [OperationContract]
        bool VerifyPlayer(string username, string token);
    }
}
