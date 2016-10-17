using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetPostListResponse : StatusResponse
    {
        [DataMember]
        public List<Post> postList;             //signatures of all posts
        [DataMember]
        public List<CompletePost> completePostList;   //posts that will be displayed

        public GetPostListResponse()
        {
            postList = new List<Post>();
            completePostList = new List<CompletePost>();
        }
    }
}