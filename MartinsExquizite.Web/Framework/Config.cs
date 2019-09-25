using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.Framework
{
    public static class Config
    {
        private static string GetSettingFromWebConfig(string setting)
        {
            return (string)ConfigurationManager.AppSettings[setting];
        }

        private static bool GetConfigurationItemBool(string configurationItemName)
        {
            try
            {
                return bool.Parse(ConfigurationManager.AppSettings[configurationItemName]);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to read configuration '" + configurationItemName + "' in web.config", ex);
            }
        }

        private static string GetConfigurationItem(string configurationItemName)
        {
            try
            {
                return ConfigurationManager.AppSettings[configurationItemName];
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to read configuration '" + configurationItemName + "' in web.config", ex);
            }
        }

        public static string ContactErrorMessage
        {
            get
            {
                return GetSettingFromWebConfig("ContactErrorMessage");
            }
        }

        public static string ContactFormSuccessMessage
        {
            get
            {
                return GetSettingFromWebConfig("ContactFormSuccessMessage");
            }
        }

        public static string ContactFormRecipientGeneral
        {
            get
            {
                return GetSettingFromWebConfig("ContactFormRecipientGeneral");
            }
        }

        public static string ContactFormRecipientGetQuote
        {
            get
            {
                return GetSettingFromWebConfig("ContactFormRecipientGetQuote");
            }
        }

        public static bool SendEmailWithSsl
        {
            get
            {
                return GetConfigurationItemBool("SendEmailWithSsl");
            }
        }

        public static string EmailUserName
        {
            get
            {
                return GetConfigurationItem("EmailUserName");
            }
        }

        public static string EmailPassword
        {
            get
            {
                return GetConfigurationItem("EmailPassword");
            }
        }

        public static bool RequireSsl { get; internal set; }

        public static string EmailHost
        {
            get
            {
                return GetConfigurationItem("EmailHost");
            }
        }

        public static bool PickupDirectoryFromIis
        {
            get
            {
                return GetConfigurationItemBool("PickupDirectoryFromIis");
            }
        }

        public static string FromAddress
        {
            get
            {
                return GetConfigurationItem("FromAddress");
            }
        }

        public static string FromName
        {
            get
            {
                return GetConfigurationItem("FromName");
            }
        }

        public static bool EmailTestingOn
        {
            get
            {
                return GetConfigurationItemBool("EmailTestingOn");
            }
        }

        public static string TestEmailAddress
        {
            get
            {
                return GetConfigurationItem("TestEmailAddress");
            }
        }
    }
}