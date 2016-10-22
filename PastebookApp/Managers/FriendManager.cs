using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Managers
{
    public class FriendManager
    {
        Service1Client service = new Service1Client();

        public List<GetFriendsList_Result> GetFriendList(int userID)
        {
            List<GetFriendsList_Result> friendList = new List<GetFriendsList_Result>();
            var resp = service.ViewFriendsList(new ViewFriendsListRequest() {
                userID = userID
            });

            if(resp.Status && resp.errorList.ToList().Count == 0)
            {
                friendList = resp.friends.ToList();
            }
            return friendList;
        }
    }
}