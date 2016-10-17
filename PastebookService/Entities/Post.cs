using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime CREATED_DATE { get; set; }
        [DataMember]
        public string CONTENT { get; set; }
        [DataMember]
        public int PROFILE_OWNER_ID { get; set; }
        [DataMember]
        public int POSTER_ID { get; set; }
    }
}