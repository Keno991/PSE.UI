using Microsoft.AspNetCore.Mvc;
using PSE.Web.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class PSEBaseController:Controller
    {
        protected readonly ICommonTracing _tracing;

        public PSEBaseController(ICommonTracing tracing)
        {
            _tracing = tracing;
        }

    }
}
