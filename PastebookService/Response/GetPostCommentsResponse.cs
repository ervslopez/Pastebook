using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetPostCommentsResponse:StatusResponse
    {
        [DataMember]
        public List<GetPostComments_Result> commentsList;

        public GetPostCommentsResponse()
        {
            commentsList = new List<GetPostComments_Result>();
        }
    }
}