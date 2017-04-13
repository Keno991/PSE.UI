using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Configuration
{
    public class ApplicationConfig
    {

        private static readonly object _syncLock = new object();

        private static ApplicationConfig _config;

        public static ApplicationConfig Config
        {
            get
            {
                if (_config == null)
                    lock (_syncLock)
                        if (_config == null)
                            _config = new ApplicationConfig();
                return _config;
            }
        }

        private ApplicationConfig()
        {
            _appConfiguration = Startup.Configuration;
        }

        private IConfiguration _appConfiguration;

        public T GetValue<T>(string key)
        {
            try
            {
                return _appConfiguration.GetValue<T>(key);
            }
            catch
            {
                return default(T);
            }
        }

    }
}
