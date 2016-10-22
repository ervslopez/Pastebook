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

        public void GetNotification(int userID)
        {
            GetAllNotificationsResponse resp = service.GetAllNotifications(new GetAllNotificationsRequest() {
                userID = userID
            });

            if(resp.Status && resp.errorList.ToList().Count == 0)
            {
                var likesNotif = resp.likesNotif.ToList();
                var commentsNotif = resp.commentsNotif.ToList();
            }
        }
    }
}