using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }
    }
}