using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Win32;

namespace PharmInventory.HelperClasses
{
    class RegistrationHelper
    {


        private static string RegKey
        {
            get { return Program.RegKey; }
        }

        public static class Constants
        {
            public const int INDIVIDUAL_USER = 1;
            public const int HEALTH_FACILITY = 2;
            public const int HUB = 3;
        }

        public static ArrayList UserTypesForFE()
        {
            ArrayList array = new ArrayList();
            array.Add("Individual User");
            array.Add("Health Facility");
            return array;
        }

        public static ArrayList UserTypesForHE()
        {
            ArrayList array = new ArrayList();
            array.Add("Individual User");
            //array.Add("Health Facility");
            array.Add("Hub");
            return array;
        }

        public static int GetUserTypeID(string userType)
        {
            if (userType == "Individual User")
                return Constants.INDIVIDUAL_USER;
            else if (userType == "Health Facility")
                return Constants.HEALTH_FACILITY;
            else if (userType == "Hub")
                return Constants.HUB;

            return -1;
        }



        public static void SaveAuthenticationInfoToRegistry(string authCode, int UserTypeID, int? userID, int registrationID)
        {
            string authString = "";
            RegistryKey key;
            key = Registry.CurrentUser.CreateSubKey(RegKey);

            try
            {
                key.SetValue("AuthenticationCode", authCode);
                key.SetValue("UserTypeID", UserTypeID);
                key.SetValue("RegistrationID", registrationID);
                if (userID.HasValue)
                    key.SetValue("UserID", userID.Value);

            }

            catch { }
        }

        public static string GetAuthenticationCode()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey);
            string authString = "";
            if (key != null )
            {
                try
                {
                   authString = key.GetValue("AuthenticationCode").ToString();
                }
                catch
                {
                    authString = "";
                }
            }

            return authString;
        }

        public static int GetUserTypeID()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey);
            int userTypeID = -1;
            if (key != null)
            {
                try
                {
                    userTypeID = int.Parse(key.GetValue("UserTypeID").ToString());
                }
                catch
                {
                    userTypeID = -1;
                }
            }

            return userTypeID;
        }


        public static void UpdateApplicationVersionInfo()
        {
            try
            {
                HCMISRegistrations.RegistrationsSoapClient sc = new HCMISRegistrations.RegistrationsSoapClient();
                sc.UpdateSoftwareVersion(GetAuthenticationCode(), GetUserTypeID(), Program.HCMISVersionString);
            }
            catch
            {
            }
        }

        public static void SendAdditionalData(string additionalDataName, string additionalDataValue)
        {
            HCMISRegistrations.RegistrationsSoapClient sc = new HCMISRegistrations.RegistrationsSoapClient();
            sc.TransmitAdditionalInformation(GetAuthenticationCode(), GetUserTypeID(), additionalDataName, additionalDataValue);
        }
    }
}