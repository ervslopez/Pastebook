﻿using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class CountryMapper
    {
        public static PB_REF_COUNTRY toPB_REF_COUNTRY(Ref_Country country)
        {
            return new PB_REF_COUNTRY()
            {
                ID = country.ID,
                COUNTRY = country.Country
            };
        }

        public static Ref_Country toCountry(PB_REF_COUNTRY country)
        {
            return new Ref_Country()
            {
                ID = country.ID,
                Country = country.COUNTRY
            };
        }

        public static Dictionary<int, string> toCountryDictionary(List<Ref_Country> countryFromDB)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (var item in countryFromDB)
            {
                dictionary.Add(item.ID, item.Country);
            }
            return dictionary;
        }
    }
}