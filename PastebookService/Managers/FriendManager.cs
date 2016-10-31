using System;

namespace PastebookService
{
    public class FriendManager
    {
        FriendDataAccess friendDataAccess = new FriendDataAccess();
        AccountDataAccess accountDataAccess = new AccountDataAccess();

        public FriendResponse RequestFriendship(FriendRequest request)
        {
            FriendResponse resp = new FriendResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.friend.USER_ID)
                    && accountDataAccess.UserIDExists(request.friend.FRIEND_ID))
                {
                    Friend friend = friendDataAccess.GetFriendshipStatus(request.friend.USER_ID, request.friend.FRIEND_ID, true);
                    if (!friendDataAccess.checkRelationship(request.friend.USER_ID, request.friend.FRIEND_ID, "N",
                                                                                    "Y", true))
                    {
                        resp.IsBlocked = false;
                        request.friend.REQUEST = 'Y';
                        request.friend.IsBLOCKED = 'N';
                        request.friend.CREATED_DATE = DateTime.Now;
                        if (friend.FRIEND_ID > 0)
                        {
                            request.friend.ID = friend.ID;
                            resp.Status = friendDataAccess.UpdateFriendship(request.friend) > 0 ? true : false;
                        }
                        else
                        {
                            resp.Status = friendDataAccess.AddFriendshipStatus(request.friend) > 0 ? true : false;
                        }
                    }
                    else
                    {
                        resp.IsBlocked = true;
                    }
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public FriendResponse AcceptFriendship(FriendRequest request)
        {
            FriendResponse resp = new FriendResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.friend.USER_ID)
                && accountDataAccess.UserIDExists(request.friend.FRIEND_ID))
                {
                    if (!friendDataAccess.checkRelationship(request.friend.USER_ID, request.friend.FRIEND_ID, "Y"))
                    {
                        resp.IsBlocked = false;
                        if (friendDataAccess.checkRelationship(request.friend.FRIEND_ID, request.friend.USER_ID, "Y",
                                                                                    "N", true))
                        {
                            resp.RequestExists = true;
                            request.friend.REQUEST = 'N';
                            request.friend.IsBLOCKED = 'N';
                            request.friend.CREATED_DATE = DateTime.Now;

                            request.friend.ID = friendDataAccess.GetFriendshipStatus(request.friend.USER_ID,
                                                                                    request.friend.FRIEND_ID, false).ID;
                            
                            if(resp.Status = friendDataAccess.UpdateFriendship(request.friend) > 0)
                            {
                                friendDataAccess.AddFriendshipStatus(new Friend() {
                                    IsBLOCKED = 'N',
                                    REQUEST = 'N',
                                    USER_ID = request.friend.FRIEND_ID,
                                    FRIEND_ID = request.friend.USER_ID,
                                    CREATED_DATE = DateTime.Now
                                });
                            }
                        }
                    }
                    else
                    {
                        resp.IsBlocked = true;
                    }
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public FriendResponse DeclineFriendship(FriendRequest request)
        {
            FriendResponse resp = new FriendResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.friend.USER_ID)
                && accountDataAccess.UserIDExists(request.friend.FRIEND_ID))
                {
                    if (!friendDataAccess.checkRelationship(request.friend.USER_ID, request.friend.FRIEND_ID, "Y"))
                    {
                        resp.IsBlocked = false;
                        if (friendDataAccess.checkRelationship(request.friend.FRIEND_ID, request.friend.USER_ID, "Y",
                                                                                    "N", true))
                        {
                            resp.RequestExists = true;
                            Friend friend = friendDataAccess.GetFriendshipStatus(request.friend.FRIEND_ID, request.friend.USER_ID, true);
                            resp.Status = friendDataAccess.RemoveFriendshipStatus(friend) > 0 ? true : false;
                        }
                    }
                    else
                    {
                        resp.IsBlocked = true;
                    }
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public FriendResponse BlockAccount(FriendRequest request)
        {
            FriendResponse resp = new FriendResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.friend.USER_ID)
                    && accountDataAccess.UserIDExists(request.friend.FRIEND_ID))
                {
                    if (!friendDataAccess.checkRelationship(request.friend.USER_ID, request.friend.FRIEND_ID, "Y"))
                    {
                        resp.IsBlocked = false;
                        request.friend.REQUEST = 'N';
                        request.friend.IsBLOCKED = 'Y';
                        request.friend.ID = friendDataAccess.GetFriendshipStatus(request.friend.USER_ID,
                                                                                    request.friend.FRIEND_ID, true).ID;

                        var dummy = request.friend.USER_ID;
                        request.friend.USER_ID = request.friend.FRIEND_ID;
                        request.friend.FRIEND_ID = dummy;

                        request.friend.CREATED_DATE = DateTime.Now;
                        if (request.friend.ID > 0)
                        {
                            resp.Status = friendDataAccess.UpdateFriendship(request.friend) > 0 ? true : false;
                        }
                        else
                        {
                            resp.Status = friendDataAccess.AddFriendshipStatus(request.friend) > 0 ? true : false;
                        }
                    }
                    else
                    {
                        resp.IsBlocked = true;
                    }
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public ViewFriendsListResponse ViewFriendsList(ViewFriendsListRequest request)
        {
            ViewFriendsListResponse resp = new ViewFriendsListResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.userID))
                {
                    resp.friends = friendDataAccess.GetFriendsList(request.userID);
                    resp.Status = true;
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public GetFriendshipStatusResponse GetFriendshipStatus(FriendRequest request)
        {
            GetFriendshipStatusResponse resp = new GetFriendshipStatusResponse() {
                friendshipStatus = "Not Friends"
            };
            Friend friend = friendDataAccess.GetFriendshipStatus(request.friend.USER_ID, request.friend.FRIEND_ID, true);

            if(friend.REQUEST == 'N')
            {
                resp.friendshipStatus = "Friends";
            }else if(friend.REQUEST == 'Y')
            {
                resp.friendshipStatus = "Pending";
            }else if(friendDataAccess.CheckFriendRequestToConfirm(request.friend.USER_ID, request.friend.FRIEND_ID))
            {
                resp.friendshipStatus = "Confirm";
            }
            return resp;
        }
    }
}