﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace H4_Soap_WCF.Models
{
    [DataContract]
    public class GroupModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string GroupName { get; set; }
    }
}
