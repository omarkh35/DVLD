using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer;

namespace BusinessLayer
{
    public class clsCountries
    {

        public string CountryName { get; }
        public int CountryID { get; }

        private clsCountries()
        {
            this.CountryName = "";
            this.CountryID = -1;
        }

        private clsCountries(int CountryID,string CountryName)
        {
            this.CountryName = CountryName;
            this.CountryID = CountryID;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }

        public static clsCountries Find(int CountryID)
        {
            string CountryName = "";
            if (clsCountriesData.GetCountryInfoByCountryID(CountryID, ref CountryName))
                return new clsCountries(CountryID,CountryName);
            else
                return null;
        }


        public static clsCountries Find(string CountryName)
        {

            int ID = -1;

            if (clsCountriesData.GetCountryInfoByName(CountryName, ref ID))

                return new clsCountries(ID, CountryName);
            else
                return null;

        }
    }
}
