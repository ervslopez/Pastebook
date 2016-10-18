using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class LoginResponse :StatusResponse
    {
        [DataMember]
        public bool emailExists { get; set; }
        [DataMember]
        public bool passwordMatched { get; set; }
        [DataMember]
        public User user { get; set; }
    }
}