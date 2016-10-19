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
            return likesNotif;
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
            return commentsNotif;
        }
    }
}