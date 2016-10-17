using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class NotificationMapper
    {
        public static PB_NOTIFICATION toPB_NOTIFICATION(Notification notification)
        {
            return new PB_NOTIFICATION()
            {
                ID = notification.ID,
                POST_ID = notification.POST_ID,
                COMMENT_ID = notification.COMMENT_ID,
                NOTIF_TYPE = notification.NOTIF_TYPE.ToString(),
                RECEIVER_ID = notification.RECEIVER_ID,
                SENDER_ID = notification.SENDER_ID,
                SEEN = notification.SEEN.ToString(),
                CREATED_DATE = notification.CREATED_DATE
            };
        }

        public static Notification toNotification(PB_NOTIFICATION notification)
        {
            return new Notification()
            {
                ID = notification.ID,
                POST_ID = (int)notification.POST_ID,
                COMMENT_ID = (int)notification.COMMENT_ID,
                NOTIF_TYPE = notification.NOTIF_TYPE[0],
                RECEIVER_ID = notification.RECEIVER_ID,
                SENDER_ID = notification.SENDER_ID,
                SEEN = notification.SEEN[0],
                CREATED_DATE = notification.CREATED_DATE
            };
        }
    }
}