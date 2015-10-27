using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Settings
    {
        public static bool _IsHub = true;
        public static bool IsHub
        {
            get { return _IsHub; }
            set { _IsHub = value; }
        }

        public static string LongMeasurmentUnit
        {
            get { return "Meter"; }
        }

        public static string ShortMeasurmentUnit
        {
            get { return "M"; }
        }
    }
}
