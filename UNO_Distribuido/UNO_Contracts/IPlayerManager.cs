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
        bool EmailAlreadyExist(string email);
        [OperationContract]
        void AddNewPlayer(Player newPlayer);
        [OperationContract]
        void DeletePlayer(Player player);
        [OperationContract]
        void ModifyPlayer(Player player, Player newPlayer);
        [OperationContract]
        void GetAllPlayers();
        [OperationContract]
        void RegisterPlayer(Player newPlayer);
    }

    public interface IPlayerManagerCallback
    {
        [OperationContract]
        void VerifyPlayerAddition(bool response);
        [OperationContract]
        void VerifyPlayerDeletion(bool response);
        [OperationContract]
        void VerifyPlayerModification(bool response);
        [OperationContract]
        void GetPlayersResponse(List<Player> players);
        [OperationContract]
        void VerifyPlayerRegistration(bool response);
        [OperationContract]
    }
}
