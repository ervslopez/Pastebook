using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class ViewFriendsListResponse : StatusResponse
    {
        [DataMember]
        public List<GetFriendsList_Result> friends;

        public ViewFriendsListResponse()
        {
            friends = new List<GetFriendsList_Result>();
        }
    }
}