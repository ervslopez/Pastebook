using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class FriendResponse : StatusResponse
    {
        [DataMember]
        public bool IsBlocked { get; set; }

        [DataMember]
        public bool RequestExists { get; set; }
    }
}