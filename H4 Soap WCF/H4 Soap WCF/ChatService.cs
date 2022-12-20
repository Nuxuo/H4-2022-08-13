using H4_Soap_WCF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace H4_Soap_WCF
{
    public class ChatService : IChatService
    {
        private string _connectionString = "Data Source=localhost;Initial Catalog=H4_Chat;Integrated Security=true";
        private SqlConnection _con;

        public ChatService()
        {
            _con = new SqlConnection(_connectionString);
        }

        public void AddAllChatMessage(int Id, string message)
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("insert into GlobalChatMessage(Sender,Message,DatetimeOfMessage) values(@Sender,@Message,@DatetimeOfMessage)", _con);
            cmd.Parameters.AddWithValue("@Sender", Id);
            cmd.Parameters.AddWithValue("@Message", message);
            cmd.Parameters.AddWithValue("@DatetimeOfMessage", DateTime.UtcNow);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public void AddGroupChatMessage(int UserId, int GroupId, string message)
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("insert into GroupChatMessage(GroupContact,Sender,Message,DatetimeOfMessage) values(@GroupContact,@Sender,@Message,@DatetimeOfMessage)", _con);
            cmd.Parameters.AddWithValue("@GroupContact", GroupId);
            cmd.Parameters.AddWithValue("@Sender", UserId);
            cmd.Parameters.AddWithValue("@Message", message);
            cmd.Parameters.AddWithValue("@DatetimeOfMessage", DateTime.UtcNow);
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public void AddPrivateChatMessage(int UserId, int PrivateId, string message)
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("insert into PrivateChatMessage(PrivateContact,Sender,Message,DatetimeOfMessage) values(@PrivateContact,@Sender,@Message,@DatetimeOfMessage)", _con);
            cmd.Parameters.AddWithValue("@PrivateContact", PrivateId);
            cmd.Parameters.AddWithValue("@Sender", UserId);
            cmd.Parameters.AddWithValue("@Message", message);
            cmd.Parameters.AddWithValue("@DatetimeOfMessage", DateTime.UtcNow);
            cmd.ExecuteNonQuery();
            _con.Close();
        }

        public List<MessageModel> GetAllChatMessages()
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Users.Username , GlobalChatMessage.Message FROM GlobalChatMessage JOIN Users ON GlobalChatMessage.Sender = Users.Id ORDER BY GlobalChatMessage.DatetimeOfMessage", _con);

            List<MessageModel> _list = new List<MessageModel>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new MessageModel { Username = rdr["Username"].ToString(), Message = rdr["Message"].ToString() } );
                }
            }

            _con.Close();
            return _list;
        }
        public List<MessageModel> GetGroupChatMessages(int GroupId)
        {         
            _con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Sender, Users.Username , Message FROM GroupChatMessage JOIN Users ON GroupChatMessage.Sender = Users.Id where GroupChatMessage.GroupContact = "+GroupId+" order by GroupChatMessage.DatetimeOfMessage", _con);

            List<MessageModel> _list = new List<MessageModel>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new MessageModel { Id = Int32.Parse(rdr["Sender"].ToString()), Username = rdr["Username"].ToString(), Message = rdr["Message"].ToString() });
                }
            }

            _con.Close();
            return _list;
        }
        public List<MessageModel> GetPrivateChatMessages(int PrivateId)
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Sender , Users.Username , Message FROM PrivateChatMessage JOIN Users ON PrivateChatMessage.Sender = Users.Id where PrivateChatMessage.PrivateContact = "+PrivateId+" order by PrivateChatMessage.DatetimeOfMessage", _con);

            List<MessageModel> _list = new List<MessageModel>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new MessageModel { Id = Int32.Parse(rdr["Sender"].ToString()) , Username = rdr["Username"].ToString(), Message = rdr["Message"].ToString() });
                }
            }

            _con.Close();
            return _list;
        }


        public List<GroupModel> GetGroupsContacts(int UserId)
        {
            _con.Open();
            SqlCommand cmd = new SqlCommand("SELECT GroupContacts.Id, GroupContacts.GroupName  FROM UserJoinedGroups join GroupContacts on GroupContacts.Id = UserJoinedGroups.[Group] where UserJoinedGroups.[User] = " + UserId, _con);

            List<GroupModel> _list = new List<GroupModel>();

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new GroupModel { Id = Int32.Parse(rdr["Id"].ToString()), GroupName = rdr["GroupName"].ToString() });
                }
            }

            _con.Close();
            return _list;
        }
        public List<PrivateModel> GetPrivateContacts(int UserId)
        {
            _con.Open();
            SqlCommand OutgoingContacts_cmd = new SqlCommand("SELECT PrivateContacts.Id, Users.Username FROM PrivateContacts INNER JOIN Users ON Users.Id = PrivateContacts.UserTwo WHERE PrivateContacts.UserOne = " + UserId, _con);

            List<PrivateModel> _list = new List<PrivateModel>();

            using (SqlDataReader rdr = OutgoingContacts_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new PrivateModel { Id = Int32.Parse(rdr["Id"].ToString()), Username = rdr["Username"].ToString() });
                }
            }

            SqlCommand IncomingContacts_cmd = new SqlCommand("SELECT PrivateContacts.Id, Users.Username FROM PrivateContacts INNER JOIN Users ON Users.Id = PrivateContacts.UserOne WHERE PrivateContacts.UserTwo = " + UserId, _con);
            using (SqlDataReader rdr = IncomingContacts_cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    _list.Add(new PrivateModel { Id = Int32.Parse(rdr["Id"].ToString()), Username = rdr["Username"].ToString() });
                }
            }

            _con.Close();
            return _list;
        }

    }
}
