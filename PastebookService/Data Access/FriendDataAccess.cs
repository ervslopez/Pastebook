using PastebookModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class FriendDataAccess : BaseDataAccess
    {
        public int AddFriendshipStatus(Friend friend)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_FRIEND.Add(FriendMapper.toPB_FRIEND(friend));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public Friend GetFriendshipStatus(int userID, int friendID)
        {
            Friend result = new Friend();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = FriendMapper.toFriend(context.PB_FRIEND
                                                    .Where(x => (x.USER_ID == userID && x.FRIEND_ID == friendID)
                                                        || (x.USER_ID == friendID && x.FRIEND_ID == userID))
                                                    .SingleOrDefault());
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public int UpdateFriendship(Friend friend)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.Entry(FriendMapper.toPB_FRIEND(friend)).State = EntityState.Modified;
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public bool checkRelationship(int userID, int friendID, string request, string isBlocked, bool strictSequence)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    if (strictSequence)
                    {
                        result = context.PB_FRIEND.Any(x => (x.USER_ID == userID
                                                            && x.FRIEND_ID == friendID)
                                                            && x.REQUEST == request
                                                            && x.IsBLOCKED == isBlocked);
                    }
                    else
                    {
                        result = context.PB_FRIEND.Any(x => ((x.USER_ID == userID && x.FRIEND_ID == friendID)
                                                          || (x.USER_ID == friendID && x.FRIEND_ID == userID))
                                                          && x.REQUEST == request
                                                          && x.IsBLOCKED == isBlocked);
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public bool checkRelationship(int userID, int friendID, string isBlocked)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_FRIEND.Any(x => ((x.USER_ID == userID && x.FRIEND_ID == friendID)
                                                      || (x.USER_ID == friendID && x.FRIEND_ID == userID))
                                                      && x.IsBLOCKED == isBlocked);
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<GetFriendsList_Result> GetFriendsList(int ID)
        {
            List<GetFriendsList_Result> friendList = new List<GetFriendsList_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    friendList = context.GetFriendsList((int)ID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return friendList;
        }
    }
}