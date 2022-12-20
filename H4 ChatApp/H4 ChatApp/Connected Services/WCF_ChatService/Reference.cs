﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_ChatService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MessageModel", Namespace="http://schemas.datacontract.org/2004/07/H4_Soap_WCF.Models")]
    public partial class MessageModel : object
    {
        
        private int IdField;
        
        private string MessageField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PrivateModel", Namespace="http://schemas.datacontract.org/2004/07/H4_Soap_WCF.Models")]
    public partial class PrivateModel : object
    {
        
        private int IdField;
        
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username
        {
            get
            {
                return this.UsernameField;
            }
            set
            {
                this.UsernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GroupModel", Namespace="http://schemas.datacontract.org/2004/07/H4_Soap_WCF.Models")]
    public partial class GroupModel : object
    {
        
        private string GroupNameField;
        
        private int IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GroupName
        {
            get
            {
                return this.GroupNameField;
            }
            set
            {
                this.GroupNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_ChatService.IChatService")]
    public interface IChatService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/AddAllChatMessage", ReplyAction="http://tempuri.org/IChatService/AddAllChatMessageResponse")]
        System.Threading.Tasks.Task AddAllChatMessageAsync(int UserId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/AddGroupChatMessage", ReplyAction="http://tempuri.org/IChatService/AddGroupChatMessageResponse")]
        System.Threading.Tasks.Task AddGroupChatMessageAsync(int UserId, int GroupId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/AddPrivateChatMessage", ReplyAction="http://tempuri.org/IChatService/AddPrivateChatMessageResponse")]
        System.Threading.Tasks.Task AddPrivateChatMessageAsync(int UserId, int PrivateId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetAllChatMessages", ReplyAction="http://tempuri.org/IChatService/GetAllChatMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetAllChatMessagesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetGroupChatMessages", ReplyAction="http://tempuri.org/IChatService/GetGroupChatMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetGroupChatMessagesAsync(int GroupId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetPrivateChatMessages", ReplyAction="http://tempuri.org/IChatService/GetPrivateChatMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetPrivateChatMessagesAsync(int PrivateId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetPrivateContacts", ReplyAction="http://tempuri.org/IChatService/GetPrivateContactsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.PrivateModel>> GetPrivateContactsAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetGroupsContacts", ReplyAction="http://tempuri.org/IChatService/GetGroupsContactsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.GroupModel>> GetGroupsContactsAsync(int UserId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IChatServiceChannel : WCF_ChatService.IChatService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ChatServiceClient : System.ServiceModel.ClientBase<WCF_ChatService.IChatService>, WCF_ChatService.IChatService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ChatServiceClient() : 
                base(ChatServiceClient.GetDefaultBinding(), ChatServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IChatService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), ChatServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task AddAllChatMessageAsync(int UserId, string message)
        {
            return base.Channel.AddAllChatMessageAsync(UserId, message);
        }
        
        public System.Threading.Tasks.Task AddGroupChatMessageAsync(int UserId, int GroupId, string message)
        {
            return base.Channel.AddGroupChatMessageAsync(UserId, GroupId, message);
        }
        
        public System.Threading.Tasks.Task AddPrivateChatMessageAsync(int UserId, int PrivateId, string message)
        {
            return base.Channel.AddPrivateChatMessageAsync(UserId, PrivateId, message);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetAllChatMessagesAsync()
        {
            return base.Channel.GetAllChatMessagesAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetGroupChatMessagesAsync(int GroupId)
        {
            return base.Channel.GetGroupChatMessagesAsync(GroupId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.MessageModel>> GetPrivateChatMessagesAsync(int PrivateId)
        {
            return base.Channel.GetPrivateChatMessagesAsync(PrivateId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.PrivateModel>> GetPrivateContactsAsync(int UserId)
        {
            return base.Channel.GetPrivateContactsAsync(UserId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WCF_ChatService.GroupModel>> GetGroupsContactsAsync(int UserId)
        {
            return base.Channel.GetGroupsContactsAsync(UserId);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IChatService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IChatService))
            {
                return new System.ServiceModel.EndpointAddress("http://192.168.1.101:8733/Design_Time_Addresses/H4_Soap_WCF/ChatService/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ChatServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IChatService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ChatServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IChatService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IChatService,
        }
    }
}