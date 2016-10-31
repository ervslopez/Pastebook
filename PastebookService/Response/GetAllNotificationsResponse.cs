using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetAllNotificationsResponse : StatusResponse
    {
        [DataMember]
        public List<GetLikesNotif_Result> likesNotif;

        [DataMember]
        public List<GetCommentsNotif_Result> commentsNotif;

        [DataMember]
        public List<GetFriendRequestNotif_Result> friendRequestsNotif;

        public GetAllNotificationsResponse()
        {
            likesNotif = new List<GetLikesNotif_Result>();
            commentsNotif = new List<GetCommentsNotif_Result>();
            friendRequestsNotif = new List<GetFriendRequestNotif_Result>();
        }
    }
}