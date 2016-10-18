using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class FriendRequest
    {
        [DataMember]
        public Friend friend { get; set; }
    }
}