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
        public List<GetNewsfeed_Result> postList;       

        public GetPostListResponse()
        {
            postList = new List<GetNewsfeed_Result>();
        }
    }
}