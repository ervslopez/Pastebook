using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Friend
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int USER_ID { get; set; }
        [DataMember]
        public int FRIEND_ID { get; set; }
        [DataMember]
        public char REQUEST { get; set; }
        [DataMember]
        public char IsBLOCKED { get; set; }
        [DataMember]
        public DateTime CREATED_DATE { get; set; }
    }
}