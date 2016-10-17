using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetPostLikesRequest
    {
        [DataMember]
        public int POST_ID { get; set; }
    }
}