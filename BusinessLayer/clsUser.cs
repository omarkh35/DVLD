using DataAccsessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPeople PeopleInfo;

        public clsUser()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.IsActive = false;
            this.Password = "";
            this.UserName = "";
            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.PersonID = PersonID;
            this.UserID = UserID;
            this.IsActive = IsActive;
            this.Password = Password;
            this.UserName = UserName;

            this.PeopleInfo = clsPeople.Find(PersonID);
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);

        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.ListPeople();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            bool ISFound = clsUserData.GetUserByID(UserID,ref PersonID, ref UserName, ref Password, ref IsActive);

            if( ISFound)
                return new clsUser(UserID,PersonID,UserName,Password,IsActive);
            else
                return null;
        }

        public static clsUser Find(string UserName)
        {
            int PersonID = -1;
            int UserID = -1;
            string Password = "";
            bool IsActive = false;

            bool ISFound = clsUserData.GetUserByID(ref UserID, ref PersonID, UserName, ref Password, ref IsActive);

            if (ISFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
    }
}
