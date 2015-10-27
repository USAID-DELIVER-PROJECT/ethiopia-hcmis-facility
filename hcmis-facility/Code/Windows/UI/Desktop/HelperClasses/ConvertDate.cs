using System;

namespace PharmInventory.HelperClasses
{
    class ConvertDate
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DateConverter(string dt)
        {
            DateTime dtCurrent = new DateTime();
            try
            {
                dtCurrent = Convert.ToDateTime(dt);
            }
            catch
            {
                string dtValid = "";
                string yer = "";
                if (Convert.ToInt32(dt.Substring(0, 2)) == 13)
                {
                    dtValid = dt;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("12/30/" + yer);
                }
                else if (Convert.ToInt32(dt.Substring(0, 2)) == 2)
                {
                    dtValid =dt;
                    yer = dtValid.Substring(dtValid.Length - 4, 4);
                    dtCurrent = Convert.ToDateTime("2/28/" + yer);
                }
            }
            return dtCurrent;
        }

        public static DateTime DateConverterToEU(string dt)
        {
            DateTime dtCurrent = new DateTime();
            CalendarLib.DateTimePickerEx ec = new CalendarLib.DateTimePickerEx();
           
            return dtCurrent;
        }
    }
}
