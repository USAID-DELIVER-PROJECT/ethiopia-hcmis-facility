using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using PharmInventory.RRFLookUpService;
using PharmInventory.RRFTransactionService;

namespace PharmInventory.HelperClasses
{
   public class RRFHelper
    {
        private const string userName = "HCMISFE1";
        private const string password = "HcmisFe1";
       public static int GetRrfCategoryId(string programName)
       {
           var ginfo = new GeneralInfo();
           ginfo.LoadAll();
           var client1 = new ServiceRRFLookupClient();
           var periods = client1.GetCurrentReportingPeriod(ginfo.FacilityID, userName, password);
           var period = periods[0].Id;
           var forms = client1.GetForms(ginfo.FacilityID, userName, password);
           var formid = forms[0].Id;
           var formcategories = client1.GetFacilityRRForm(ginfo.FacilityID, formid, period, 1, userName, password).First().FormCategories.ToList();
          
               switch (programName)
               {
                   case "Malaria Prevention & Control":
                       return 14;
                   case "TB / Leprosy Prevention & Control":
                       return 13;
                   case "HIV/AIDS ans STIs and OIs":
                       return 15;
                   case "Curative care and emergency care":
                      return 15;
                   case "Family Planning":
                       return 13;
                   case "Disease Prevention and Control":
                       return 14;
                   case "Adolescent Reproductive Health":
                       return 13;
               }
           return 11;
       }

       
      
    }
    
}
