using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public bool UserExists { get; set; }
        [DataMember]
        public bool PasswordMatched { get; set; }
        [DataMember]
        public int UserID { get; set; }
    }
}