using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetAccountProfileRequest
    {
        [DataMember]
        public int accountID { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string username { get; set; }
    }
}