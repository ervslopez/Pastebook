﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetAllNotificationsRequest
    {
        [DataMember]
        public int userID { get; set; }
    }
}