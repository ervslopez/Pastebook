using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class LoginResponse : StatusResponse
    {
        [DataMember]
        public bool UserNameExists { get; set; }
        [DataMember]
        public bool PasswordMatched { get; set; }
        [DataMember]
        public User user { get; set; }
    }
}