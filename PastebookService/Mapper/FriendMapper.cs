using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class FriendMapper
    {
        public static PB_FRIEND toPB_FRIEND(Friend friend)
        {
            return new PB_FRIEND()
            {
                ID = friend.ID,
                USER_ID = friend.USER_ID,
                FRIEND_ID = friend.FRIEND_ID,
                REQUEST = friend.REQUEST.ToString(),
                CREATED_DATE = friend.CREATED_DATE,
                IsBLOCKED = friend.IsBLOCKED.ToString()
            };
        }

        public static Friend toFriend(PB_FRIEND friend)
        {
            return new Friend()
            {
                ID = friend.ID,
                USER_ID = friend.USER_ID,
                FRIEND_ID = friend.FRIEND_ID,
                REQUEST = friend.REQUEST[0],
                CREATED_DATE = friend.CREATED_DATE,
                IsBLOCKED = friend.IsBLOCKED[0]
            };
        }
    }
}