using MartinsExquizite.Data;
using MartinsExquizite.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinsExquizite.Service
{
    public class ConfigurationsService
    {
        eMartinsExquiziteContext context = new eMartinsExquiziteContext();

        #region Define as Singleton
        private static ConfigurationsService _Instance;
        public static ConfigurationsService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ConfigurationsService();
                }

                return (_Instance);
            }
        }

        public ConfigurationsService()
        {

        }

        #endregion

        public Configuration GetConfigurationByKey(string key)
        {
            return context.Configurations.FirstOrDefault(x => x.Key == key);
        }
    }
}
