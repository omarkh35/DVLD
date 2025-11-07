using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsessLayer;

namespace BusinessLayer
{
    public class clsPeople
    {
        public enum enMode { AddNew=0,Update=1};
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }

        
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        public clsCountries CountriesInfo;

        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }  
            set { _ImagePath = value; }
        }

        public clsPeople()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Phone = "";
            this.ImagePath = "";
            this.Address = "";
            this.Email = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;

            Mode = enMode.AddNew;
        }

        public clsPeople(int PersonID, string NationalNo, string FirstName,
          string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, short Gendor,
          string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.ImagePath = ImagePath;
            this.Address = Address;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.Gendor = Gendor;
            this.NationalNo = NationalNo;
            //Implement Find In clsCountries
            this.CountriesInfo = clsCountries.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        public static clsPeople Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool isFound = clsPeopleData.GetPersonInfoByPesonID(PersonID, ref FirstName,
         ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref  DateOfBirth, ref Gendor,
         ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (isFound) 
            {

            return new clsPeople(PersonID, NationalNo, FirstName,
          SecondName, ThirdName, LastName, DateOfBirth, Gendor,
          Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool isFound = clsPeopleData.GetPersonInfoByNationalNo(PersonID, ref FirstName,
         ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref Gendor,
         ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (isFound)
            {

                return new clsPeople(PersonID, NationalNo, FirstName,
              SecondName, ThirdName, LastName, DateOfBirth, Gendor,
              Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.ListPeople();
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPeopleData.AddNewPerson(this.FirstName,this.SecondName, this.ThirdName, this.LastName, this.NationalNo
                , this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPeopleData.UpdatePerson(this.PersonID,this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.NationalNo
                , this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeopleData.IsPersonExist(NationalNo);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdatePerson();
                    


                default:
                    return false;
            }
        }

    }
}
