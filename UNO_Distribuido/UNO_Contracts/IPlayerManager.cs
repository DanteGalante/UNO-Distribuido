using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UNO_DB;

namespace UNO_Contracts
{
    [ServiceContract(CallbackContract = typeof(IPlayerManagerCallback))]
    public interface IPlayerManager
    {
        [OperationContract]
        Player SearchPlayer(string username);
        [OperationContract]
        void AddPlayer(Player newPlayer);
        [OperationContract]
        void DeletePlayer(Player player);
        [OperationContract]
        void ModifyPlayer(Player player,Player newPlayer);
        [OperationContract]
        void GetPlayers();
        
    }

    public interface IPlayerManagerCallback
    {
        [OperationContract]
        void AddPlayerResponse(bool response);
        [OperationContract]
        void DeletePlayerResponse(bool response);
        [OperationContract]
        void ModifyPlayerResponse(bool response);
        [OperationContract]
        void GetPlayersResponse(List<Player> players);
        [OperationContract]
        void EmailVerification(string email);
    }
}
