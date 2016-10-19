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
                    Friend friend = friendDataAccess.GetFriendshipStatus(request.friend.USER_ID, request.friend.FRIEND_ID);
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
                                                                                    request.friend.FRIEND_ID).ID;

                            resp.Status = friendDataAccess.UpdateFriendship(request.friend) > 0 ? true : false;
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
                                                                                    request.friend.FRIEND_ID).ID;

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
    }
}