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
        int PlayerAlreadyExist(string username, string email);
        [OperationContract]
        bool AddNewPlayer(Player newPlayer);
        [OperationContract]
        bool DeletePlayer(Player player);
        [OperationContract]
        bool ModifyPlayer(Player player, Player newPlayer);
        [OperationContract]
        void GetAllPlayers();
        [OperationContract(IsOneWay = true)]
        void RegisterPlayer(Player newPlayer);
        [OperationContract]
        bool CheckPlayerVerification(Player player);
        [OperationContract]
        bool VerifyPlayer(string username);
    }

    public interface IPlayerManagerCallback
    {
        [OperationContract]
        void GetPlayersResponse(List<Player> players);
        [OperationContract]
        void VerifyPlayerRegistration(int response, string username);
    }
}
