using PastebookApp.Mapper;
using PastebookApp.Models;
using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Managers
{
    public class NotificationManager
    {
        Service1Client service = new Service1Client();

        public List<NotificationViewModel> GetNotification(int userID)
        {
            List<NotificationViewModel> notifList = new List<NotificationViewModel>();
            GetAllNotificationsResponse resp = service.GetAllNotifications(new GetAllNotificationsRequest() {
                userID = userID
            });
            notifList = NotifMapper.toNotif(resp.likesNotif.ToList())
                .Concat(NotifMapper.toNotif(resp.commentsNotif.ToList()))
                .Concat(NotifMapper.toNotif(resp.friendRequestsNotif.ToList())).ToList();
            notifList = notifList.OrderByDescending(x=>x.notifID).ToList();
            return notifList;
        }

        public int GetNotificationCount(int userID)
        {
            int retVal = 0;
            retVal = service.GetNotificationCount(new GetAllNotificationsRequest() { userID = userID}).count;
            return retVal;
        }
    }
}