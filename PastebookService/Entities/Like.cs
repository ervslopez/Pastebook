using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Like
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int POST_ID { get; set; }
        [DataMember]
        public int LIKED_BY { get; set; }
    }
}