using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class SearchUsersResponse : StatusResponse
    {
        [DataMember]
        public List<User> userList;

        public SearchUsersResponse()
        {
            userList = new List<User>();
        }
    }
}