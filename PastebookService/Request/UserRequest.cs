using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class UserRequest
    {
        [DataMember]
        public string USER_NAME { get; set; }
        [DataMember]
        public string PASSWORD { get; set; }
        [DataMember]
        public string FIRST_NAME { get; set; }
        [DataMember]
        public string LAST_NAME { get; set; }
        [DataMember]
        public DateTime BIRTHDAY { get; set; }
        [DataMember]
        public int COUNTRY_ID { get; set; }
        [DataMember]
        public string MOBILE_NO { get; set; }
        [DataMember]
        public char GENDER { get; set; }
        [DataMember]
        public byte[] PROFILE_PIC { get; set; }
        [DataMember]
        public DateTime DATE_CREATED { get; set; }
        [DataMember]
        public string ABOUT_ME { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
    }
}