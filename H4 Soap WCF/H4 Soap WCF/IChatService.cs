using H4_Soap_WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace H4_Soap_WCF
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void AddAllChatMessage(int UserId , string message);
        [OperationContract]
        void AddGroupChatMessage(int UserId, int GroupId ,string message);
        [OperationContract]
        void AddPrivateChatMessage(int UserId, int PrivateId, string message);



        [OperationContract]
        List<MessageModel> GetAllChatMessages();

        [OperationContract]
        List<MessageModel> GetGroupChatMessages(int GroupId);

        [OperationContract]
        List<MessageModel> GetPrivateChatMessages(int PrivateId);



        [OperationContract]
        List<PrivateModel> GetPrivateContacts(int UserId);

        [OperationContract]
        List<GroupModel> GetGroupsContacts(int UserId);
    }
}
