using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetAccountProfileResponse : StatusResponse
    {
        [DataMember]
        public User user { get; set; }
    }
}