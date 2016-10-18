using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class EditPasswordOrEmailRequest: UserRequest
    {
        [DataMember]
        public string OldPassword { get; set; }

        [DataMember]
        public string OldEmail { get; set; }
    }
}