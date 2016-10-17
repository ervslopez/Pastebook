using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class CommentOnPostRequest
    {
        [DataMember]
        public Comment comment { get; set; }
    }
}