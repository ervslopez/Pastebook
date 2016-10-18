using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class CreateUserResponse:StatusResponse
    {
        [DataMember]
        public bool emailExists { get; set; }
    }
}