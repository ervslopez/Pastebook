using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class NotificationViewModel
    {
        public int postID { get; set; }
        public string name { get; set; }
        public char notifType { get; set; }
        public int notifID { get; set; }
        public string username { get; set; }
    }
}