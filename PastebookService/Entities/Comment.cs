using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int POST_ID { get; set; }
        [DataMember]
        public int POSTER_ID { get; set; }
        [DataMember]
        public string CONTENT { get; set; }
        [DataMember]
        public DateTime DATE_CREATED { get; set; }
    }
}