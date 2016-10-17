using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Notification
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int RECEIVER_ID { get; set; }
        [DataMember]
        public char NOTIF_TYPE { get; set; }
        [DataMember]
        public int SENDER_ID { get; set; }
        [DataMember]
        public DateTime CREATED_DATE { get; set; }
        [DataMember]
        public int COMMENT_ID { get; set; }
        [DataMember]
        public int POST_ID { get; set; }
        [DataMember]
        public char SEEN { get; set; }
    }
}