using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class NotificationManager
    {
        NotificationDataAccess notificationDataAccess = new NotificationDataAccess();
        Notification notification;

        public bool LikeNotification(int postID, int likedBy, int postedBy)
        {
            notification = new Notification()
            {
                CREATED_DATE = DateTime.Now,
                NOTIF_TYPE = 'L',
                SEEN = 'N',
                SENDER_ID = likedBy,
                POST_ID = postID,
                RECEIVER_ID = postedBy
            };
            return notificationDataAccess.SendNotification(notification) > 0;
        }

        public bool CommentNotification(int postID, int posterID, int receiverID, int commentID)
        {
            notification = new Notification()
            {
                CREATED_DATE = DateTime.Now,
                NOTIF_TYPE = 'C',
                SEEN = 'N',
                SENDER_ID = posterID,
                POST_ID = postID,
                RECEIVER_ID = receiverID,
                COMMENT_ID = commentID
            };
            return notificationDataAccess.SendNotification(notification) > 0;
        }

        public bool FriendNotification(int userID, int friendID)
        {
            notification = new Notification()
            {
                CREATED_DATE = DateTime.Now,
                NOTIF_TYPE = 'F',
                SEEN = 'N',
                SENDER_ID = userID,
                RECEIVER_ID = friendID
            };
            return notificationDataAccess.SendNotification(notification) > 0;
        }
        
        public GetAllNotificationsResponse GetRecentNotifications(int userID)
        {
            GetAllNotificationsResponse response = new GetAllNotificationsResponse();
            response.likesNotif = notificationDataAccess.GetAllRecentLikesNotification(userID);
            response.commentsNotif = notificationDataAccess.GetAllRecentCommentsNotification(userID);
            return response;
        }

        public bool AllNotificationsSeen(int userID)
        {
            throw new NotImplementedException();
        }
    }
}