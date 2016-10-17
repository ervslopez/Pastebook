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
        public Post post { get; set; }

        [DataMember]
        public List<GetPostLikes_Result> likeList;

        [DataMember]
        public List<GetPostComments_Result> commentsList;
        
        public CompletePost()
        {
            likeList = new List<GetPostLikes_Result>();
            commentsList = new List<GetPostComments_Result>();
        }
    }
}