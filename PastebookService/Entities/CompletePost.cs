using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class CompletePost
    {
        [DataMember]
        public GetNewsfeed_Result post { get; set; }
        [DataMember]
        public List<GetPostComments_Result> comments;
        [DataMember]
        public List<GetPostLikes_Result> likes;

        public CompletePost()
        {
            comments = new List<GetPostComments_Result>();
            likes = new List<GetPostLikes_Result>();
        }

    }
}