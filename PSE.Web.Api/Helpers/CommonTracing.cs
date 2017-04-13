using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Helpers
{
    public class CommonTracing:ICommonTracing
    {
        private ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;

        public CommonTracing(ILoggerFactory factory)
        {
            _loggerFactory = factory;
        }

        public TResult TracingInvoke<TResult>(Func<TResult> function)
        {
            try
            {
                _logger = _loggerFactory.CreateLogger(function.Target.ToString());
                _logger.LogTrace($"Method {function.Method.Name} invoked");
                return function.Invoke();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return default(TResult);
            }
        }

    }
}
