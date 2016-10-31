using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class NotificationDataAccess : BaseDataAccess
    {
        public int SendNotification(Notification notification)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_NOTIFICATION.Add(NotificationMapper.toPB_NOTIFICATION(notification));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<GetLikesNotif_Result> GetAllRecentLikesNotification(int userID)
        {
            List<GetLikesNotif_Result> likesNotif = new List<GetLikesNotif_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    likesNotif = context.GetLikesNotif((int)userID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return likesNotif = likesNotif.OrderByDescending(x => x.NOTIF_ID).ToList();
        }

        public List<GetCommentsNotif_Result> GetAllRecentCommentsNotification(int userID)
        {
            List<GetCommentsNotif_Result> commentsNotif = new List<GetCommentsNotif_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    commentsNotif = context.GetCommentsNotif((int)userID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return commentsNotif = commentsNotif.OrderByDescending(x => x.NOTIF_ID).ToList();
        }

        public List<GetFriendRequestNotif_Result> GetAllRecentFriendRequestsNotification(int userID)
        {
            List<GetFriendRequestNotif_Result> friendsNotif = new List<GetFriendRequestNotif_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    friendsNotif = context.GetFriendRequestNotif((int)userID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return friendsNotif = friendsNotif.OrderByDescending(x => x.NOTIF_ID).ToList();
        }

        public int GetNotificationCount(int userID)
        {
            int retVal = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    retVal = context.PB_NOTIFICATION.Where(x=>x.SEEN == "N" && x.RECEIVER_ID == userID).ToList().Count;
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return retVal;
        }

        public void AllNotifSeen(int userID)
        {
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.SetNotificationsToSeen(userID);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
        }
    }
}