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
            notifList = NotifMapper.toNotif(resp.likesNotif.ToList()).Concat(NotifMapper.toNotif(resp.commentsNotif.ToList())).OrderBy(x=>x.notifID).ToList();
            return notifList;
        }
    }
}