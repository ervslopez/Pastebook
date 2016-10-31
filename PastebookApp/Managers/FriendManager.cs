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

        public string CheckFriendshipStatus(int user, int friend)
        {
            var response = service.GetFriendshipStatus(new FriendRequest() {
                friend = new Friend() {
                    USER_ID = user,
                    FRIEND_ID = friend
                }
            });
            return response.friendshipStatus;
        }

        public bool SendFriendRequest(int user, int friend)
        {
            var resp = service.RequestFriendship(new FriendRequest() {
                friend = new Friend() {
                    USER_ID = user,
                    FRIEND_ID = friend
                }
            });

            return resp.Status;
        }

        public bool RespondToFriendRequest(int user, int friend, bool accept)
        {
            bool status = false;
            if (accept)
            {
                status = service.AcceptFriendship(new FriendRequest()
                {
                    friend = new Friend()
                    {
                        USER_ID = user,
                        FRIEND_ID = friend
                    }
                }).Status;
            }
            else
            {
                status = service.DeclineFriendship(new FriendRequest()
                {
                    friend = new Friend()
                    {
                        USER_ID = user,
                        FRIEND_ID = friend
                    }
                }).Status;
            }

            return status;
        }
    }
}