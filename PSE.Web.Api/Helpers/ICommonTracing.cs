using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Helpers
{
    public interface ICommonTracing
    {
         TResult TracingInvoke<TResult>(Func<TResult> function);
    }
}
