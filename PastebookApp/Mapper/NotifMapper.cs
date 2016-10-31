using PastebookApp.Models;
using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Mapper
{
    public static class NotifMapper
    {
        public static List<NotificationViewModel> toNotif(List<GetLikesNotif_Result> result)
        {
            List<NotificationViewModel> notifList = new List<NotificationViewModel>();

            foreach (var item in result)
            {
                notifList.Add(new NotificationViewModel() {
                    name = item.FIRST_NAME + item.LAST_NAME,
                    notifID = item.NOTIF_ID,
                    postID = item.POST_ID,
                    notifType = item.NOTIF_TYPE[0]
                });
            }
            return notifList;
        }

        public static List<NotificationViewModel> toNotif(List<GetCommentsNotif_Result> result)
        {
            List<NotificationViewModel> notifList = new List<NotificationViewModel>();

            foreach (var item in result)
            {
                notifList.Add(new NotificationViewModel()
                {
                    name = item.FIRST_NAME + item.LAST_NAME,
                    notifID = item.NOTIF_ID,
                    postID = item.POST_ID,
                    notifType = item.NOTIF_TYPE[0]
                });
            }
            return notifList;
        }

        public static List<NotificationViewModel> toNotif(List<GetFriendRequestNotif_Result> result)
        {
            List<NotificationViewModel> notifList = new List<NotificationViewModel>();

            foreach (var item in result)
            {
                notifList.Add(new NotificationViewModel()
                {
                    name = item.FIRST_NAME + item.LAST_NAME,
                    notifID = item.NOTIF_ID,
                    username = item.USER_NAME,
                    notifType = item.NOTIF_TYPE[0]
                });
            }
            return notifList;
        }
    }
}