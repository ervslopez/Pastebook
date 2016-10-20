using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class UtilityDataAccess : BaseDataAccess
    {
        public List<Ref_Country> GetCountries()
        {
            List<Ref_Country> countryList = new List<Ref_Country>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    var countriesFromBD = context.PB_REF_COUNTRY.ToList();

                    foreach (var item in countriesFromBD)
                    {
                        countryList.Add(CountryMapper.toCountry(item));
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return countryList;
        }
    }
}