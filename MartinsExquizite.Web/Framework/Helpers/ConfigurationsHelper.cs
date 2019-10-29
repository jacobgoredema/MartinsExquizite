using MartinsExquizite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MartinsExquizite.Web.Framework.Helpers
{
    public class ConfigurationsHelper
    {
        public static int? _dashboardRecordsSizePerPage { get; set; }
        public static int DashboardRecordsSizePerPage
        {
            get
            {
                if (!_dashboardRecordsSizePerPage.HasValue)
                {
                    var config = ConfigurationsService.Instance.GetConfigurationByKey("DashboardRecordsSizePerPage");
                    if (config != null)
                    {
                        _dashboardRecordsSizePerPage = int.Parse(config.Value);
                    }
                    else _dashboardRecordsSizePerPage = 0;
                }

                return _dashboardRecordsSizePerPage.Value;
            }
        }
    }
}