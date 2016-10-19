﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class CommentOnPostResponse : StatusResponse
    {
        [DataMember]
        public DateTime commentDateTime { get; set; }
    }
}