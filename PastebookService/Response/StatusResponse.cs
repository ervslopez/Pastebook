using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class StatusResponse
    {
        [DataMember]
        public bool Status { get; set; }

        //[DataMember]
        //public List<Exception> errorList;

        //public StatusResponse()
        //{
        //    errorList = new List<Exception>();
        //}
    }
}