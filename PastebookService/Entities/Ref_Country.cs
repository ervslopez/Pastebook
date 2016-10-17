using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class Ref_Country
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Country { get; set; }
    }
}