using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetPostLikesResponse: StatusResponse
    {
        [DataMember]
        public List<GetPostLikes_Result> likeList;

        public GetPostLikesResponse()
        {
            likeList = new List<GetPostLikes_Result>();
        }

    }
}