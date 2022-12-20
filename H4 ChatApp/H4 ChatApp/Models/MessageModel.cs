using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_ChatApp.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public bool IsOwnerMessage { get; set; }
        public bool IsSystemMessage { get; set; }
    }
}
