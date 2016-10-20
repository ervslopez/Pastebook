using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PastebookService
{
    [DataContract]
    public class GetCountriesResponse
    {
        [DataMember]
        public Dictionary<int, string> CountryList;

        public GetCountriesResponse()
        {
            CountryList = new Dictionary<int, string>();
        }
    }
}