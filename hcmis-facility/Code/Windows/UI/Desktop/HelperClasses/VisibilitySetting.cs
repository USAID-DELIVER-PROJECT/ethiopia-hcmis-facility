using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace PharmInventory.HelperClasses
{
   public class VisibilitySetting
   {
       public const string REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration";
       public const string PSCONFIG_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\PSConfig";
       
       public const string UIDPWD_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\UIDConfig";
       public const string REMOTE_REGISTRY_PATH = @"Software\JSI\HCMIS\Configuration\RSConfig";
      
       public const string HANDLE_UNITS_KEY = @"HandleUnits";
       public const string PS_CONFIG_KEY = @"PSConfig";
      
       public const string UID_PWD_KEY = @"UserNameAndPasswordConfig";
       public const string REMOTE_CONFIG_KEY = @"RemoteServerAddressConfig";
       
       

       public static int HandleUnits
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(REGISTRY_PATH, HANDLE_UNITS_KEY);
                   var handleUnits = Convert.ToInt32(value);
                   return handleUnits;
               }
               catch (Exception)
               {
                   SetRegistryValue(HANDLE_UNITS_KEY, 1);
                   return 1;
               }
           }
       }

       public static string UserNameAndPasswordConfig
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(UIDPWD_REGISTRY_PATH, UID_PWD_KEY);
                   var uidconfig = Convert.ToString(value);
                   return uidconfig;
               }
               catch (Exception)
               {
                   const string keyvalue = "-u \"Administrator\" -p \"lucky@bole2005\"";
                   SetUidConfigRegistryValue(UID_PWD_KEY, keyvalue);
                   return keyvalue;
               }
           }
       }

       public static string RemoteServerAddressConfig
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(REMOTE_REGISTRY_PATH, REMOTE_CONFIG_KEY);
                   var rsconfig = Convert.ToString(value);
                   return rsconfig;
               }
               catch (Exception)
               {
                   const string keyvalue = "\\192.168.2.62";
                   SetRemoteConfigRegistryValue(REMOTE_CONFIG_KEY, keyvalue);
                   return keyvalue;
               }
           }
       }

       private static void SetRemoteConfigRegistryValue(string remotekey, string keyvalue)
       {
           try
           {
               var rk = Registry.CurrentUser.CreateSubKey(REMOTE_REGISTRY_PATH);
               if (rk != null) rk.SetValue(remotekey, keyvalue);
           }
           catch (Exception ex)
           {
               string message = ex.InnerException.Message;
               XtraMessageBox.Show(message);
           }
       }

       private static void SetUidConfigRegistryValue(string uidkey, string keyvalue)
       {
           try
           {
               var rk = Registry.CurrentUser.CreateSubKey(UIDPWD_REGISTRY_PATH);
               if (rk != null) rk.SetValue(uidkey, keyvalue);
           }
           catch (Exception ex)
           {
               string message = ex.InnerException.Message;
               XtraMessageBox.Show(message);
           }
       }


       public static string PSConfig
       {
           get
           {
               try
               {
                   var value = GetRegistryValue(PSCONFIG_REGISTRY_PATH, PS_CONFIG_KEY);
                   var psconfigs = Convert.ToString(value);
                   return psconfigs;
               }
               catch (Exception)
               {
                   const string keyvalue = @"C:\Tools\PsExec.exe";
                   SetPsConfigRegistryValue(PS_CONFIG_KEY, keyvalue);
                   return keyvalue;
               }
           }
       }

       public static string GetRegistry(string path, string key)
       {
           var visibility = (string)Registry.GetValue(path, key, null);
           return visibility;
       }

       public static string GetRegistryValue(string keyName, string valueName)
       {
           var key = Registry.CurrentUser.OpenSubKey(keyName);
           if (key != null) return key.GetValue(valueName).ToString();
           return null;
       }

       public static void SetRegistryValue(string valueName, int value)
       {
           try
           {
               Registry.CurrentUser.DeleteValue(REGISTRY_PATH, false);
               RegistryKey rk = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH);
               if (rk != null) rk.SetValue(valueName, value);
           }
           catch (Exception ex)
           {
               string message = ex.InnerException.Message;
               XtraMessageBox.Show(message);
           }
       }

       public static void SetPsConfigRegistryValue(string valueName, string value)
       {
           try
           {
              var rk = Registry.CurrentUser.CreateSubKey(PSCONFIG_REGISTRY_PATH);
               if (rk != null) rk.SetValue(valueName, value);
           }
           catch (Exception ex)
           {
               string message = ex.InnerException.Message;
               XtraMessageBox.Show(message);
           }
       }

       public bool Write(string KeyName, string valueName, object Value)
       {
           try
           {
               // if the sub key doesn't exsit ... create it.
               RegistryKey sk1 = Registry.CurrentUser.CreateSubKey(KeyName);
               // Save the value
               sk1.SetValue(valueName, Value);
               return true;
           }
           catch (Exception e)
           {
               return false;
           }
       }

   }
}
