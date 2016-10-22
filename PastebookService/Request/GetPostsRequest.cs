using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetPostsRequest
    {
        [DataMember]
        public int accountID { get; set; }
    }
}